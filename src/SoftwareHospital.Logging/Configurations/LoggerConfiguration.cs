using SoftwareHospital.Logging.Enums;
using SoftwareHospital.Logging.Services;

namespace SoftwareHospital.Logging.Configurations;

public class LoggerConfiguration
{
    private LogLevel _minimumLevel = LogLevel.Information;
    private readonly List<ILogSink> _outputs = new();
    
    public LoggerConfiguration MinimumLevel(LogLevel level)
    {
        _minimumLevel = level;
        return this;
    }
    
    public LoggerConfiguration AddOutput(ILogSink output)
    {
        _outputs.Add(output);
        return this;
    }
    
    public Logger CreateLogger()
    {
        return new Logger(_outputs, _minimumLevel);
    }
}