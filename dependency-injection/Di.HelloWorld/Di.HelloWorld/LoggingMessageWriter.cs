using Microsoft.Extensions.Logging;

namespace Di.HelloWorld;

public class LoggingMessageWriter(ILogger<LoggingMessageWriter> logger) : IMessageWriter
{
    public void Write(string message)
    {
        logger.LogInformation("Info: {Msg}", message);
    }
}