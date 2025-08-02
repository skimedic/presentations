﻿// Copyright Information
// ==================================
// AutoLot70 - AutoLot.Services - AppLogging.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2023/07/31
// ==================================

namespace AutoLot.Services.Logging;

public class AppLogging<T> : IAppLogging<T>
{
    private readonly ILogger<T> _logger;

    public AppLogging(ILogger<T> logger)
    {
        _logger = logger;
    }

    internal static void LogWithException(string memberName, string sourceFilePath,
        int sourceLineNumber, Exception ex, string message,
        Action<Exception, string, object[]> logAction)
    {
        var list = new List<IDisposable>
        {
            LogContext.PushProperty("MemberName", memberName),
            LogContext.PushProperty("FilePath", sourceFilePath),
            LogContext.PushProperty("LineNumber", sourceLineNumber),
        };
        logAction(ex, message, null);
        foreach (var item in list)
        {
            item.Dispose();
        }
    }

    internal static void LogWithoutException(string memberName, string sourceFilePath,
        int sourceLineNumber, string message, Action<string, object[]> logAction)
    {
        var list = new List<IDisposable>
        {
            LogContext.PushProperty("MemberName", memberName),
            LogContext.PushProperty("FilePath", sourceFilePath),
            LogContext.PushProperty("LineNumber", sourceLineNumber),
        };
        logAction(message, null);
        foreach (var item in list)
        {
            item.Dispose();
        }
    }

    public void LogAppError(Exception exception, string message,
        [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "",
        [CallerLineNumber] int sourceLineNumber = 0)
    {
        LogWithException(memberName, sourceFilePath, sourceLineNumber,
            exception, message, _logger.LogError);
    }

    public void LogAppError(string message, [CallerMemberName] string memberName = "",
        [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
    {
        LogWithoutException(memberName, sourceFilePath, sourceLineNumber, message, _logger.LogError);
    }

    public void LogAppCritical(Exception exception, string message,
        [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "",
        [CallerLineNumber] int sourceLineNumber = 0)
    {
        LogWithException(memberName, sourceFilePath, sourceLineNumber, exception, message,
            _logger.LogCritical);
    }

    public void LogAppCritical(string message, [CallerMemberName] string memberName = "", 
	    [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
    {
        LogWithoutException(memberName, sourceFilePath, sourceLineNumber, message, _logger.LogCritical);
    }

    public void LogAppDebug(string message, [CallerMemberName] string memberName = "",
        [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
    {
        LogWithoutException(memberName, sourceFilePath, sourceLineNumber, message, _logger.LogDebug);
    }

    public void LogAppTrace(string message, [CallerMemberName] string memberName = "", 
	[CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
    {
        LogWithoutException(memberName, sourceFilePath, sourceLineNumber, message, _logger.LogTrace);
    }

    public void LogAppInformation(string message, [CallerMemberName] string memberName = "",
        [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
    {
        LogWithoutException(memberName, sourceFilePath, sourceLineNumber, message,
            _logger.LogInformation);
    }

    public void LogAppWarning(string message, [CallerMemberName] string memberName = "",
        [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
    {
        LogWithoutException(memberName, sourceFilePath, sourceLineNumber, message, _logger.LogWarning);
    }
}