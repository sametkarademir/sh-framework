using SoftwareHospital.Logging.Configurations;
using SoftwareHospital.Logging.Sink.File.Services;

namespace SoftwareHospital.Logging.Sink.File.Extensions;

public static class LoggerConfigurationExtensions
{
    public static LoggerConfiguration WriteToFile(this LoggerConfiguration configuration, string filePath)
    {
        configuration.AddOutput(new FileOutput(filePath));
        return configuration;
    }
}