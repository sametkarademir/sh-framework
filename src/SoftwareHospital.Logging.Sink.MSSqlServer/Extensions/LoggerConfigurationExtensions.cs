using SoftwareHospital.Logging.Configurations;
using SoftwareHospital.Logging.Sink.MSSqlServer.Services;

namespace SoftwareHospital.Logging.Sink.MSSqlServer.Extensions;

public static class LoggerConfigurationExtensions
{
    public static LoggerConfiguration WriteToMSSqlServer(this LoggerConfiguration configuration, string connectionString)
    {
        configuration.AddOutput(new MSSqlServerOutput(connectionString));
        return configuration;
    }
}