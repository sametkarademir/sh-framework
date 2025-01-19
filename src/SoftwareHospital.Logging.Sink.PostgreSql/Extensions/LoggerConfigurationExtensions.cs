using SoftwareHospital.Logging.Configurations;
using SoftwareHospital.Logging.Sink.PostgreSql.Services;

namespace SoftwareHospital.Logging.Sink.PostgreSql.Extensions;

public static class LoggerConfigurationExtensions
{
    public static LoggerConfiguration WriteToPostgreSql(this LoggerConfiguration configuration, string connectionString)
    {
        configuration.AddOutput(new PostgreSqlOutput(connectionString));
        return configuration;
    }
}