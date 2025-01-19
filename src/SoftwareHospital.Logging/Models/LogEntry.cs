using SoftwareHospital.Logging.Enums;

namespace SoftwareHospital.Logging.Models;

public class LogEntry
{
    public DateTime Timestamp { get; set; }
    public LogLevel Level { get; set; }
    public string? Message { get; set; }
    public Exception? Exception { get; set; }
    
    public Guid? CreatorId { get; set; }
    public Guid CorrelationId { get; set; }
    public Guid AppSnapshotId { get; set; }
    public Guid? SessionId { get; set; }
}