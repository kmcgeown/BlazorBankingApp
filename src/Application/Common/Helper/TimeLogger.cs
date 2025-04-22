using Microsoft.Extensions.Logging;

namespace Application.Common.Helper;

public static class TimeLogger
{
    public static Microsoft.Extensions.Logging.ILogger? Logger { get; set; }

    private static readonly Action<
        Microsoft.Extensions.Logging.ILogger,
        string,
        string,
        string,
        TimeSpan,
        Exception?
    > traceLoggerMessage = LoggerMessage.Define<string, string, string, TimeSpan>(
        LogLevel.Information,
        0,
        "{Class}.{Method} - {Message} in {Duration}"
    );

    public static void DebugMessageWithLevelCheck(
        Microsoft.Extensions.Logging.ILogger logger,
        string value1,
        string value2,
        string value3,
        TimeSpan value4
    )
    {
        if (logger!.IsEnabled(LogLevel.Information))
            traceLoggerMessage(logger, value1, value2, value3, value4, null);
    }

    public static void Log(MethodBase methodBase, TimeSpan timeSpan, string message) =>
        DebugMessageWithLevelCheck(
            Logger,
            methodBase.DeclaringType!.Name,
            methodBase.Name,
            message,
            timeSpan
        );
}
