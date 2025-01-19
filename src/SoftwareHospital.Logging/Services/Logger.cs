using SoftwareHospital.Logging.Enums;
using SoftwareHospital.Logging.Models;

namespace SoftwareHospital.Logging.Services;

public class Logger
{
    private readonly List<ILogSink> _logSinks;
    private readonly LogLevel _minimumLevel;

    public Logger(List<ILogSink> logSinks, LogLevel minimumLevel)
    {
        _logSinks = logSinks;
        _minimumLevel = minimumLevel;
    }
    
    public void Log(LogEntry logEntry)
    {
        if (logEntry.Level < _minimumLevel) return;
        
        foreach (var output in _logSinks)
        {
            output.Write(logEntry);
        }
    }

    public void Verbose(LogEntry logEntry) => Log(logEntry);
    public void Information(LogEntry logEntry) => Log(logEntry);
    public void Debug(LogEntry logEntry) => Log(logEntry);
    public void Warning(LogEntry logEntry) => Log(logEntry);
    public void Error(LogEntry logEntry) => Log(logEntry);
    public void Fatal(LogEntry logEntry) => Log(logEntry);
}