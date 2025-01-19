# Logger Documentation

## Overview

This custom logger implementation provides a flexible and extensible logging solution similar to Serilog. The logger can write logs to multiple sinks such as Console, File, Microsoft SQL Server, and PostgreSQL.

## Installation

1. Clone the repository or include the project in your solution.

2. Ensure the necessary dependencies are available:

    * System.IO for file operations.

    * Microsoft.Data.SqlClient for SQL Server logging.

    * Npgsql for PostgreSQL logging.

## Usage

### Logger Configuration

To set up the logger, use the following configuration:
```
var path = "/logs/myapp.txt";

var logger = new LoggerConfiguration()
    .MinimumLevel(LogLevel.Verbose)
    .WriteToConsole()
    .WriteToFile(path)
    .WriteToMSSqlServer("Server=localhost,1433;Database=TestDB;User Id=sa;Password=Password1*;TrustServerCertificate=true")
    .WriteToPostgreSql("Server=localhost;Port=5432;Database=TestDB;User Id=root;Password=Password1*;")
    .CreateLogger();
```
Alternatively, you can register the logger as a singleton service in Program.cs for use throughout the application:
```
builder.Services.AddSingleton<Logger>(_ => new LoggerConfiguration()
    .MinimumLevel(LogLevel.Verbose)
    .WriteToConsole()
    .WriteToFile("logs/myapp.txt")
    .WriteToMSSqlServer("Server=localhost,1433;Database=TestDB;User Id=sa;Password=Password1*;TrustServerCertificate=true")
    .WriteToPostgreSql("Server=localhost;Port=5432;Database=TestDB;User Id=root;Password=Password1*;")
    .CreateLogger());
```

### Logging Events

To log events, create a LogEntry and pass it to the logger:
```
logger.Information(new LogEntry
{
    Timestamp = DateTime.Now,
    Level = LogLevel.Fatal,
    Message = "Information log",
    Exception = new UnauthorizedAccessException("You are not authorized to access this resource"),
    CreatorId = Guid.NewGuid(),
    CorrelationId = Guid.NewGuid(),
    AppSnapshotId = Guid.NewGuid(),
    SessionId = Guid.NewGuid()
});
```

## Sinks Implementation

### 1. Console Output

The ConsoleOutput class provides colored logging to the console based on the log level.
```
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
```

### 2. File Output

Logs will be written to the specified file path.

```
var path = "logs/myapp.txt";
logger.WriteToFile(path);
```

### 3. MSSQL Server Output

Logs will be written to a SQL Server database.
```
logger.WriteToMSSqlServer("Server=localhost,1433;Database=ShContainLab;User Id=sa;Password=Password1*;TrustServerCertificate=true");
```
### 4. PostgreSQL Output

Logs will be written to a PostgreSQL database.
```
logger.WriteToPostgreSql("Server=localhost;Port=5432;Database=SHContainLabDb;User Id=admin;Password=Pass*600312;");
```
## Log Levels

The following log levels are supported:

* Verbose

* Debug

* Information

* Warning

* Error

* Fatal

## Extending the Logger

To add a new log output, implement the ILogSink interface and provide the Write method.
```
public interface ILogSink
{
    void Write(LogEntry logEntry);
}
```

