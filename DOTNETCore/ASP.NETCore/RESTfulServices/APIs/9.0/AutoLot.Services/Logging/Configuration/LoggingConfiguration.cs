// Copyright Information
// ==================================
// AutoLot9 - AutoLot.Services - LoggingConfiguration.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/11/20
// ==================================

namespace AutoLot.Services.Logging.Configuration;

public static class LoggingConfiguration
{
    public static IServiceCollection RegisterLoggingInterfaces(this IServiceCollection services)
    {
        services.AddScoped<IAppLogging,AppLogging>();
        return services;
    }

    private static readonly string OutputTemplate =
        @"[{Timestamp:yy-MM-dd HH:mm:ss} {Level}]{ApplicationName}:{SourceContext}{NewLine}Message:{Message}{NewLine}in method {MemberName} at {FilePath}:{LineNumber}{NewLine}{Exception}{NewLine}";

    private static readonly ColumnOptions ColumnOptions = new()
    {
        AdditionalColumns = new List<SqlColumn>
        {
            new() { DataType = SqlDbType.VarChar, ColumnName = "ApplicationName" },
            new() { DataType = SqlDbType.VarChar, ColumnName = "MachineName" },
            new() { DataType = SqlDbType.VarChar, ColumnName = "MemberName" },
            new() { DataType = SqlDbType.VarChar, ColumnName = "FilePath" },
            new() { DataType = SqlDbType.Int, ColumnName = "LineNumber" },
            new() { DataType = SqlDbType.VarChar, ColumnName = "SourceContext" },
            new() { DataType = SqlDbType.VarChar, ColumnName = "RequestPath" },
            new() { DataType = SqlDbType.VarChar, ColumnName = "ActionName" }
        }
    };

    public static void ConfigureSerilog(this WebApplicationBuilder builder)
    {
        builder.Logging.ClearProviders();
        var config = builder.Configuration;
        var settings = config.GetSection(nameof(AppLoggingSettings)).Get<AppLoggingSettings>();
        var connectionStringName = settings.MSSqlServer.ConnectionStringName;
        var connectionString = config.GetConnectionString(connectionStringName);
        var tableName = settings.MSSqlServer.TableName;
        var schema = settings.MSSqlServer.Schema;
        string restrictedToMinimumLevel = settings.General.RestrictedToMinimumLevel;
        if (!Enum.TryParse<LogEventLevel>(restrictedToMinimumLevel, out var logLevel))
        {
            logLevel = LogEventLevel.Debug;
        }

        var sqlOptions = new MSSqlServerSinkOptions
        {
            AutoCreateSqlTable = false,
            SchemaName = schema,
            TableName = tableName,
        };
        if (builder.Environment.IsDevelopment())
        {
            sqlOptions.BatchPeriod = new TimeSpan(0, 0, 0, 1);
            sqlOptions.BatchPostingLimit = 1;
        }

        var log = new LoggerConfiguration()
            .MinimumLevel.Is(logLevel)
            .MinimumLevel.Override("Microsoft", LogEventLevel.Error)
            .Enrich.FromLogContext()
            .Enrich.With(new PropertyEnricher(
                "ApplicationName", config.GetValue<string>("ApplicationName")))
            .Enrich.WithMachineName()
            .WriteTo.File(
                path: builder.Environment.IsDevelopment()
                    ? settings.File.FileName
                    : settings.File.FullLogPathAndFileName, // "ErrorLog.txt",
                rollingInterval: RollingInterval.Day,
                restrictedToMinimumLevel: logLevel,
                outputTemplate: OutputTemplate)
            .WriteTo.Console(restrictedToMinimumLevel: logLevel)
            .WriteTo.MSSqlServer(
                connectionString: connectionString,
                sqlOptions,
                restrictedToMinimumLevel: logLevel,
                columnOptions: ColumnOptions);
        if (builder.Environment.IsDevelopment())
        {
            Serilog.Debugging.SelfLog.Enable(msg =>
            {
                Debug.Print(msg);
                Debugger.Break();
            });
        }
        builder.Logging.AddSerilog(log.CreateLogger(), false);
    }
}