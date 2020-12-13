using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog.Context;

namespace AutoLot.Services.Logging
{
    public class AppLogging<T> : IAppLogging<T>
    {
        private readonly ILogger<T> _logger;
        private readonly IConfiguration _config;
        private readonly string _applicationName;

        public AppLogging(ILogger<T> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
            _applicationName = config.GetValue<string>("ApplicationName");
        }

        internal List<IDisposable> PushProperties(
            string memberName,
            string sourceFilePath,
            int sourceLineNumber)
        {
            List<IDisposable> list = new List<IDisposable>
            {
                LogContext.PushProperty("MemberName", memberName),
                LogContext.PushProperty("FilePath", sourceFilePath),
                LogContext.PushProperty("LineNumber", sourceLineNumber),
                LogContext.PushProperty("ApplicationName", _applicationName)
            };
            return list;
        }

        public void LogAppError(Exception exception, string message,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            var list = PushProperties(memberName, sourceFilePath, sourceLineNumber);
            _logger.LogError(exception, message);
            foreach (var item in list)
            {
                item.Dispose();
            }
        }

        public void LogAppError(string message,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            var list = PushProperties(memberName, sourceFilePath, sourceLineNumber);
            _logger.LogError(message);
            foreach (var item in list)
            {
                item.Dispose();
            }
        }

        public void LogAppCritical(Exception exception, string message,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            var list = PushProperties(memberName, sourceFilePath, sourceLineNumber);
            _logger.LogCritical(exception, message);
            foreach (var item in list)
            {
                item.Dispose();
            }
        }

        public void LogAppCritical(string message,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            var list = PushProperties(memberName, sourceFilePath, sourceLineNumber);
            _logger.LogCritical(message);
            foreach (var item in list)
            {
                item.Dispose();
            }
        }

        public void LogAppDebug(string message,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            var list = PushProperties(memberName, sourceFilePath, sourceLineNumber);
            _logger.LogDebug(message);
            foreach (var item in list)
            {
                item.Dispose();
            }
        }

        public void LogAppTrace(string message,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            var list = PushProperties(memberName, sourceFilePath, sourceLineNumber);
            _logger.LogTrace(message);
            foreach (var item in list)
            {
                item.Dispose();
            }
        }

        public void LogAppInformation(string message,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            var list = PushProperties(memberName, sourceFilePath, sourceLineNumber);
            _logger.LogInformation(message);
            foreach (var item in list)
            {
                item.Dispose();
            }
        }

        public void LogAppWarning(string message,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            var list = PushProperties(memberName, sourceFilePath, sourceLineNumber);
            _logger.LogWarning(message);
            foreach (var item in list)
            {
                item.Dispose();
            }
        }
    }
}