using System;
using System.Collections.Generic;
using System.Data;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using Serilog;
using Serilog.Events;
using Serilog.Sinks.MSSqlServer;

namespace AutoLot.Services.Logging
{
    public static class LoggingConfiguration
    {
        private static readonly string OutputTemplate =
            @"[{Timestamp:yy-MM-dd HH:mm:ss} {Level}]{ApplicationName}:{SourceContext}{NewLine}Message:{Message}{NewLine}in method {MemberName} at {FilePath}:{LineNumber}{NewLine}{Exception}{NewLine}";

        private static readonly ColumnOptions ColumnOptions = new ColumnOptions
        {
            AdditionalColumns = new List<SqlColumn>
            {
                new SqlColumn {DataType = SqlDbType.VarChar, ColumnName = "ApplicationName"},
                new SqlColumn {DataType = SqlDbType.VarChar, ColumnName = "MachineName"},
                new SqlColumn {DataType = SqlDbType.VarChar, ColumnName = "MemberName"},
                new SqlColumn {DataType = SqlDbType.VarChar, ColumnName = "FilePath"},
                new SqlColumn {DataType = SqlDbType.Int, ColumnName = "LineNumber"},
                new SqlColumn {DataType = SqlDbType.VarChar, ColumnName = "SourceContext"},
                new SqlColumn {DataType = SqlDbType.VarChar, ColumnName = "RequestPath"},
                new SqlColumn {DataType = SqlDbType.VarChar, ColumnName = "ActionName"},
            }
        };

        public static IHostBuilder ConfigureSerilog(this IHostBuilder builder)
        {
            builder
                .ConfigureLogging((context, logging) => { logging.ClearProviders(); })
                .UseSerilog((hostingContext, loggerConfiguration) =>
            {
                var config = hostingContext.Configuration;
                var connectionString = config.GetConnectionString("AutoLot").ToString();
                var tableName = config["Logging:MSSQLServer:tableName"].ToString();
                var schema = config["Logging:MSSQLServer:schema"].ToString();
                string restrictedToMinimumLevel =
                    config["Logging:MSSQLServer:restrictedToMinimumLevel"].ToString();
                //LogEventLevel logLevel = log;
                if (!Enum.TryParse<LogEventLevel>(restrictedToMinimumLevel, out var logLevel))
                {
                    logLevel = LogEventLevel.Debug;
                }
                LogEventLevel level = (LogEventLevel)Enum.Parse(typeof(LogEventLevel), restrictedToMinimumLevel);
                loggerConfiguration
                    .Enrich.FromLogContext()
                    .Enrich.WithMachineName()
                    .ReadFrom.Configuration(hostingContext.Configuration)
                    .WriteTo.File(
                        path: "ErrorLog.txt",
                        rollingInterval: RollingInterval.Day,
                        restrictedToMinimumLevel: logLevel,
                        outputTemplate: OutputTemplate)
                    .WriteTo.Console(restrictedToMinimumLevel: logLevel)
                    .WriteTo.MSSqlServer(
                        connectionString: connectionString,
                        new MSSqlServerSinkOptions
                        {
                            AutoCreateSqlTable = false,
                            SchemaName = schema,
                            TableName = tableName,
                            BatchPeriod = new TimeSpan(0, 0, 0, 1)
                        },
                        restrictedToMinimumLevel: level,
                        columnOptions: ColumnOptions);
            });
            return builder;
        }
    }
}
