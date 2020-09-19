using System.IO;
using System.Text;
using UnityEngine;

static class CustomLog
{
    const int MaxTagSize = 100;

    static readonly StringBuilder Tag = new StringBuilder(capacity: MaxTagSize);

    enum LogLevel
    {
        Info = 0,
        Debug = 1,
        Warning = 2,
        Error = 3
    }

    public static void Log(string message, bool forceStackTrace = false,
        [System.Runtime.CompilerServices.CallerMemberName]
        string memberName = "",
        [System.Runtime.CompilerServices.CallerFilePath]
        string sourceFilePath = "",
        [System.Runtime.CompilerServices.CallerLineNumber]
        int sourceLineNumber = 0)
    {
        LogLevel level = LogLevel.Info;
        FormTag(sourceFilePath, sourceLineNumber);
        LogInternal(level, Tag.ToString(), message, forceStackTrace);
    }

    [System.Diagnostics.Conditional("UNITY_LOG_DEBUG")]
    public static void LogDebug(string message, bool forceStackTrace = false,
        [System.Runtime.CompilerServices.CallerMemberName]
        string memberName = "",
        [System.Runtime.CompilerServices.CallerFilePath]
        string sourceFilePath = "",
        [System.Runtime.CompilerServices.CallerLineNumber]
        int sourceLineNumber = 0)
    {
        LogLevel level = LogLevel.Debug;
        FormTag(sourceFilePath, sourceLineNumber);
        LogInternal(level, Tag.ToString(), message, forceStackTrace);
    }

    public static void LogWarning(string message, bool forceStackTrace = false,
        [System.Runtime.CompilerServices.CallerMemberName]
        string memberName = "",
        [System.Runtime.CompilerServices.CallerFilePath]
        string sourceFilePath = "",
        [System.Runtime.CompilerServices.CallerLineNumber]
        int sourceLineNumber = 0)
    {
        LogLevel level = LogLevel.Warning;
        FormTag(sourceFilePath, sourceLineNumber);
        LogInternal(level, Tag.ToString(), message, forceStackTrace);
    }

    public static void LogError(string message, bool forceStackTrace = false,
        [System.Runtime.CompilerServices.CallerMemberName]
        string memberName = "",
        [System.Runtime.CompilerServices.CallerFilePath]
        string sourceFilePath = "",
        [System.Runtime.CompilerServices.CallerLineNumber]
        int sourceLineNumber = 0)
    {
        LogLevel level = LogLevel.Error;
        FormTag(sourceFilePath, sourceLineNumber);
        LogInternal(level, Tag.ToString(), message, forceStackTrace);
    }


    #region - Internal
    static void LogInternal(LogLevel level, string tag, string message, bool forceStackTrace)
    {
        //here you can use any custom logger that you want
        switch (level) {
            case LogLevel.Debug:
                Debug.Log($"[{tag}] {message}");
                break;
            case LogLevel.Warning:
                Debug.LogWarning($"[{tag}] {message}");
                break;
            case LogLevel.Error:
                Debug.LogError($"[{tag}] {message}");
                break;
            case LogLevel.Info:
                Debug.Log($"[{tag}] {message}");
                break;
            default:
                Debug.Log($"[{tag}] {message}");
                break;
        }
    }

    static void FormTag(string sourceFilePath, int sourceLineNumber)
    {
        Tag.Clear();
        string className = sourceFilePath.Substring(sourceFilePath.LastIndexOf(Path.DirectorySeparatorChar) + 1);
        Tag.Append($"{className}:{sourceLineNumber}");
    }
    #endregion
}