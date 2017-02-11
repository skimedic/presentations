#region copyright
// // Copyright Information
// // ==============================
// // DAL - LoggingInterceptor.cs
// // All samples copyright Philip Japikse 
// // http://www.skimedic.com 2016/08/10
// // See License.txt for more information
// // ==============================
#endregion
using System;
using System.Data.Common;
using System.Data.Entity.Infrastructure.Interception;
using System.Reflection;
using DAL.Helpers;
using log4net;

namespace DAL.EF
{
	public class LoggingInterceptor : IDbCommandInterceptor
	{
		private readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

		public void NonQueryExecuting(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
		{
			LoggingHelper.Log(_logger, LogLevel.Info,
			    $" IsAsync: {interceptionContext.IsAsync}, Command Text: {command.CommandText}", null);
		}

		public void NonQueryExecuted(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
		{
			LoggingHelper.Log(_logger, LogLevel.Info,
			    $" IsAsync: {interceptionContext.IsAsync}, Command Text: {command.CommandText}", null);
		}

		public void ReaderExecuting(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
		{
			LoggingHelper.Log(_logger, LogLevel.Info,
			    $" IsAsync: {interceptionContext.IsAsync}, Command Text: {command.CommandText}", null);
		}

		public void ReaderExecuted(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
		{
			LoggingHelper.Log(_logger, LogLevel.Info,
			    $" IsAsync: {interceptionContext.IsAsync}, Command Text: {command.CommandText}", null);
		}

		public void ScalarExecuting(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
		{
			LoggingHelper.Log(_logger, LogLevel.Info,
			    $" IsAsync: {interceptionContext.IsAsync}, Command Text: {command.CommandText}", null);
		}

		public void ScalarExecuted(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
		{
			LoggingHelper.Log(_logger, LogLevel.Info,
			    $" IsAsync: {interceptionContext.IsAsync}, Command Text: {command.CommandText}", null);
		}
	}
}
