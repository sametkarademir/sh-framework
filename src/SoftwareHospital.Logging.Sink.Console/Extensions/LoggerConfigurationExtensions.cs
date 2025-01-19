using SoftwareHospital.Logging.Configurations;
using SoftwareHospital.Logging.Sink.Console.Services;

namespace SoftwareHospital.Logging.Sink.Console.Extensions;

public static class LoggerConfigurationExtensions
{
    public static LoggerConfiguration WriteToConsole(this LoggerConfiguration configuration)
    {
        configuration.AddOutput(new ConsoleOutput());
        return configuration;
    }
}