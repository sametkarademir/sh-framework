using SoftwareHospital.Logging.Enums;
using SoftwareHospital.Logging.Models;
using SoftwareHospital.Logging.Services;

namespace SoftwareHospital.Logging.Sink.Console.Services;

public class ConsoleOutput : ILogSink
{
    public void Write(LogEntry logEntry)
    {
        System.Console.ForegroundColor = GetColorForLogLevel(logEntry.Level);
        System.Console.WriteLine($"[{logEntry.Timestamp:yyyy-MM-dd HH:mm:ss}] [{logEntry.Level}] {logEntry.Message ?? logEntry.Exception?.Message}");
        
        if (logEntry.Exception != null)
        {
            System.Console.WriteLine($"Exception: {logEntry.Exception.StackTrace}");
        }
        
        System.Console.ResetColor();
    }
    
    private ConsoleColor GetColorForLogLevel(LogLevel level)
    {
        return level switch
        {
            LogLevel.Verbose => ConsoleColor.Gray,
            LogLevel.Debug => ConsoleColor.Blue,
            LogLevel.Information => ConsoleColor.Green,
            LogLevel.Warning => ConsoleColor.Yellow,
            LogLevel.Error => ConsoleColor.Red,
            LogLevel.Fatal => ConsoleColor.Magenta,
            _ => ConsoleColor.White,
        };
    }
}