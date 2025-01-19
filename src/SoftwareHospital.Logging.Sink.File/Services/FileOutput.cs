using SoftwareHospital.Logging.Models;
using SoftwareHospital.Logging.Services;

namespace SoftwareHospital.Logging.Sink.File.Services;

public class FileOutput : ILogSink
{
    private readonly string _filePath;

    public FileOutput(string filePath)
    {
        _filePath = filePath;
        
        var directory = Path.GetDirectoryName(_filePath);
        if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }
    }

    public void Write(LogEntry logEntry)
    {
        var logMessage = $"[{logEntry.Timestamp:yyyy-MM-dd HH:mm:ss}] [{logEntry.Level}] {logEntry.Message ?? logEntry.Exception?.Message}";
        if (logEntry.Exception != null)
        {
            logMessage += $"\nException: {logEntry.Exception.StackTrace}";
        }

        System.IO.File.AppendAllText(_filePath, logMessage + Environment.NewLine);
    }
}