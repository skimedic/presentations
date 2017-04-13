#region copyright
// // Copyright Information
// // ==============================
// // DAL - LoggingHelper.cs
// // All samples copyright Philip Japikse 
// // http://www.skimedic.com 2016/08/10
// // See License.txt for more information
// // ==============================
#endregion
using System;
using System.IO;
using System.Runtime.CompilerServices;
using log4net;
using log4net.Appender;
using log4net.Repository;

namespace DAL.Helpers
{
	public enum LogLevel
	{
		Debug,
		Info,
		Warn,
		Error,
		Fatal
	}

	public static class LoggingHelper
	{
		internal static void ClearAppenders(ILoggerRepository repo)
		{
			foreach (IAppender appender in repo.GetAppenders())
			{
			    (appender as BufferingAppenderSkeleton)?.Flush();
			}
		}
		public static void ClearLogCache()
		{
			ClearAppenders(LogManager.GetRepository());
		}
		public static void ClearLogCache(ILog log)
		{
			ClearAppenders(log.Logger.Repository);
		}
		public static void Log(
			ILog logger,
			LogLevel logLevel,
			string message,
			Exception ex,
			[CallerMemberName] string memberName = "",
			[CallerFilePath] string sourceFilePath = "",
			[CallerLineNumber] int sourceLineNumber = 0
		)
		{
			LogicalThreadContext.Properties["MemberName"] = memberName;
			LogicalThreadContext.Properties["FilePath"] = Path.GetFileName(sourceFilePath);
			LogicalThreadContext.Properties["LineNumber"] = sourceLineNumber;
			if (logLevel == LogLevel.Debug && logger.IsDebugEnabled)
			{
				logger.Debug(message, ex);
			}
			if (logLevel == LogLevel.Error && logger.IsErrorEnabled)
			{
				logger.Error(message, ex);
			}
			if (logLevel == LogLevel.Fatal && logger.IsFatalEnabled)
			{
				logger.Fatal(message, ex);
			}
			if (logLevel == LogLevel.Info && logger.IsInfoEnabled)
			{
				logger.Info(message, ex);
			}
			if (logLevel == LogLevel.Warn && logger.IsWarnEnabled)
			{
				logger.Info(message, ex);
			}

		}

	}
}
