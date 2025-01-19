using Npgsql;
using NpgsqlTypes;
using SoftwareHospital.Logging.Models;
using SoftwareHospital.Logging.Services;

namespace SoftwareHospital.Logging.Sink.PostgreSql.Services;

public class PostgreSqlOutput : ILogSink
{
    private readonly string _connectionString;
    private readonly string _tableName;

    public PostgreSqlOutput(string connectionString, string tableName = "ExceptionLogs")
    {
        _connectionString = connectionString;
        _tableName = tableName;

        EnsureTableExists();
    }

    private void EnsureTableExists()
    {
        using var connection = new NpgsqlConnection(_connectionString);
        connection.Open();

        string createTableQuery = $@"
            CREATE TABLE IF NOT EXISTS ""{_tableName}"" (
                ""Id"" UUID PRIMARY KEY,
                ""Type"" VARCHAR(250) NOT NULL,
                ""Message"" TEXT NOT NULL,
                ""Source"" TEXT NULL,
                ""StackTrace"" TEXT NULL,
                ""SessionId"" UUID NULL,
                ""CorrelationId"" UUID NOT NULL,
                ""AppSnapshotId"" UUID NOT NULL,
                ""CreationTime"" TIMESTAMPTZ NOT NULL,
                ""CreatorId"" UUID NULL,
                ""ExtraProperties"" JSONB NULL,
                ""ConcurrencyStamp"" VARCHAR(250) NOT NULL
        )";

        using var command = new NpgsqlCommand(createTableQuery, connection);
        command.ExecuteNonQuery();
    }

    public void Write(LogEntry logEntry)
    {
        using var connection = new NpgsqlConnection(_connectionString);
        connection.Open();

        string insertQuery = $@"
            INSERT INTO ""{_tableName}"" (""Id"", ""Type"", ""Message"", ""Source"", ""StackTrace"", ""SessionId"", ""CorrelationId"", ""AppSnapshotId"", ""CreationTime"", ""CreatorId"", ""ExtraProperties"", ""ConcurrencyStamp"")
            VALUES (@Id, @Type, @Message, @Source, @StackTrace, @SessionId, @CorrelationId, @AppSnapshotId, @CreationTime, @CreatorId, @ExtraProperties, @ConcurrencyStamp)";

        using var command = new NpgsqlCommand(insertQuery, connection);
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
        command.Parameters.AddWithValue("@ExtraProperties", NpgsqlDbType.Jsonb, "{}");
        command.Parameters.AddWithValue("@ConcurrencyStamp", Guid.NewGuid().ToString("N"));

        command.ExecuteNonQuery();
    }
}