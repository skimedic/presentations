// Copyright Information
// ==================================
// AutoLot9 - AutoLot.Services - IAppLogging.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/11/20
// ==================================

namespace AutoLot.Services.Logging.Interfaces;

public interface IAppLogging
{
    void LogAppError(
        Exception exception,
        string message,
        [CallerMemberName]
        string memberName = "",
        [CallerFilePath]
        string sourceFilePath = "",
        [CallerLineNumber]
        int sourceLineNumber = 0);

    void LogAppError(
        string message,
        [CallerMemberName]
        string memberName = "",
        [CallerFilePath]
        string sourceFilePath = "",
        [CallerLineNumber]
        int sourceLineNumber = 0);

    void LogAppCritical(
        Exception exception,
        string message,
        [CallerMemberName]
        string memberName = "",
        [CallerFilePath]
        string sourceFilePath = "",
        [CallerLineNumber]
        int sourceLineNumber = 0);

    void LogAppCritical(
        string message,
        [CallerMemberName]
        string memberName = "",
        [CallerFilePath]
        string sourceFilePath = "",
        [CallerLineNumber]
        int sourceLineNumber = 0);

    void LogAppDebug(
        string message,
        [CallerMemberName]
        string memberName = "",
        [CallerFilePath]
        string sourceFilePath = "",
        [CallerLineNumber]
        int sourceLineNumber = 0);

    void LogAppTrace(
        string message,
        [CallerMemberName]
        string memberName = "",
        [CallerFilePath]
        string sourceFilePath = "",
        [CallerLineNumber]
        int sourceLineNumber = 0);

    void LogAppInformation(
        string message,
        [CallerMemberName]
        string memberName = "",
        [CallerFilePath]
        string sourceFilePath = "",
        [CallerLineNumber]
        int sourceLineNumber = 0);

    void LogAppWarning(
        string message,
        [CallerMemberName]
        string memberName = "",
        [CallerFilePath]
        string sourceFilePath = "",
        [CallerLineNumber]
        int sourceLineNumber = 0);
}