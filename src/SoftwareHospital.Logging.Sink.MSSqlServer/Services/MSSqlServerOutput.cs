using Microsoft.Data.SqlClient;
using SoftwareHospital.Logging.Models;
using SoftwareHospital.Logging.Services;

namespace SoftwareHospital.Logging.Sink.MSSqlServer.Services;

public class MSSqlServerOutput : ILogSink
{
    private readonly string _connectionString;
    private readonly string _tableName;

    public MSSqlServerOutput(string connectionString, string tableName = "ExceptionLogs")
    {
        _connectionString = connectionString;
        _tableName = tableName;

        EnsureTableExists();
    }

    private void EnsureTableExists()
    {
        using var connection = new SqlConnection(_connectionString);
        connection.Open();

        string createTableQuery = $@"
            IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='{_tableName}' AND xtype='U')
            CREATE TABLE {_tableName} (
                Id UNIQUEIDENTIFIER PRIMARY KEY,
                Type NVARCHAR(250) NOT NULL,
                Message NVARCHAR(MAX) NOT NULL,
                Source NVARCHAR(MAX) NULL,
                StackTrace NVARCHAR(MAX) NULL,
                SessionId UNIQUEIDENTIFIER NULL,
                CorrelationId UNIQUEIDENTIFIER NOT NULL,
                AppSnapshotId UNIQUEIDENTIFIER NOT NULL,
                CreationTime DATETIME NOT NULL,
                CreatorId UNIQUEIDENTIFIER NULL,
                ExtraProperties NVARCHAR(MAX) NULL,
                ConcurrencyStamp NVARCHAR(250) NOT NULL
            )";

        using var command = new SqlCommand(createTableQuery, connection);
        command.ExecuteNonQuery();
    }

    public void Write(LogEntry logEntry)
    {
        using var connection = new SqlConnection(_connectionString);
        connection.Open();

        string insertQuery = $@"
             INSERT INTO {_tableName} (Id, Type, Message, Source, StackTrace, SessionId, CorrelationId, AppSnapshotId, CreationTime, CreatorId, ExtraProperties, ConcurrencyStamp)
             VALUES (@Id, @Type, @Message, @Source, @StackTrace, @SessionId, @CorrelationId, @AppSnapshotId, @CreationTime, @CreatorId, @ExtraProperties, @ConcurrencyStamp)";

        using var command = new SqlCommand(insertQuery, connection);
        command.Parameters.AddWithValue("@Id", Guid.NewGuid());
        command.Parameters.AddWithValue("@Type", logEntry.Exception?.GetType().Name ?? "Exception");
        command.Parameters.AddWithValue("@Message", logEntry.Message ?? logEntry.Exception?.Message ?? "No message");
        command.Parameters.AddWithValue("@Source", logEntry.Exception?.Source ?? (object)DBNull.Value);
        command.Parameters.AddWithValue("@StackTrace", logEntry.Exception?.StackTrace ?? (object)DBNull.Value);
        command.Parameters.AddWithValue("@SessionId", logEntry.SessionId ?? (object)DBNull.Value);
        command.Parameters.AddWithValue("@CorrelationId", logEntry.CorrelationId);
        command.Parameters.AddWithValue("@AppSnapshotId", logEntry.AppSnapshotId);
        command.Parameters.AddWithValue("@CreationTime", logEntry.Timestamp);
        command.Parameters.AddWithValue("@CreatorId", logEntry.CreatorId ?? (object)DBNull.Value);
        command.Parameters.AddWithValue("@ExtraProperties", "{}");
        command.Parameters.AddWithValue("@ConcurrencyStamp", Guid.NewGuid().ToString("N"));

        command.ExecuteNonQuery();
    }
}