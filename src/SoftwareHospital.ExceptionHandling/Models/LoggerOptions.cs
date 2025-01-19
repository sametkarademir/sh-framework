using SoftwareHospital.Logging.Enums;

namespace SoftwareHospital.ExceptionHandling.Models;

public class LoggerOptions
{
    public LogLevel MinimumLevel { get; set; } = LogLevel.Information;
    public bool UseConsole { get; set; } = true;
    public bool UseFile { get; set; } = false;
    public string? FilePath { get; set; }
    public bool UseMsSql { get; set; } = false;
    public string? MsSqlConnectionString { get; set; }
    public bool UsePostgreSql { get; set; } = false;
    public string? PostgreSqlConnectionString { get; set; }
    public ExceptionTypes ExceptionType { get; set; } = new ExceptionTypes();
}