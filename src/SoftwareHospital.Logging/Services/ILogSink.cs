using SoftwareHospital.Logging.Models;

namespace SoftwareHospital.Logging.Services;

public interface ILogSink
{
    void Write(LogEntry logEntry);
}