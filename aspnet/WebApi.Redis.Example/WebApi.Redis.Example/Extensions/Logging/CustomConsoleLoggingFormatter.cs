using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Logging.Console;

namespace WebApi.Redis.Example.Extensions.Logging;

/// <summary>
/// </summary>
public class CustomConsoleLoggingFormatter() : ConsoleFormatter(FormatterName)
{
    public const string FormatterName = "Custom";

    /// <inheritdoc />
    public override void Write<TState>(in LogEntry<TState> logEntry, IExternalScopeProvider? scopeProvider,
        TextWriter textWriter)
    {
        textWriter.WriteLine(
            $"{DateTimeOffset.Now:yyy-MM-dd HH:mm:ss.fff} [{logEntry.LogLevel}] {logEntry.Category} - {logEntry.State}");
        textWriter.WriteLine();
        if (logEntry.Exception is null) return;

        textWriter.WriteLine(logEntry.Exception);
        textWriter.WriteLine();
    }
}