using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using SoftwareHospital.ExceptionHandling.HttpProblemDetails;
using SoftwareHospital.ExceptionHandling.Models;
using SoftwareHospital.Logging.Configurations;
using SoftwareHospital.Logging.Enums;
using SoftwareHospital.Logging.Services;
using SoftwareHospital.Logging.Sink.Console.Extensions;
using SoftwareHospital.Logging.Sink.File.Extensions;
using SoftwareHospital.Logging.Sink.MSSqlServer.Extensions;
using SoftwareHospital.Logging.Sink.PostgreSql.Extensions;

namespace SoftwareHospital.ExceptionHandling.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddExceptionHandlingServices(this IServiceCollection services,
        Action<LoggerOptions> setLoggerOptions)
    {
        var loggerOptions = new LoggerOptions();
        setLoggerOptions(loggerOptions);
        services.Configure(setLoggerOptions);

        services.AddSingleton<Logger>(sp =>
        {
            var options = sp.GetRequiredService<IOptions<LoggerOptions>>().Value;
            var loggerConfig = new LoggerConfiguration()
                .MinimumLevel(options.MinimumLevel);

            if (options.UseConsole)
                loggerConfig.WriteToConsole();

            if (options.UseFile && !string.IsNullOrEmpty(options.FilePath))
                loggerConfig.WriteToFile(options.FilePath);

            if (options.UseMsSql && !string.IsNullOrEmpty(options.MsSqlConnectionString))
                loggerConfig.WriteToMSSqlServer(options.MsSqlConnectionString);

            if (options.UsePostgreSql && !string.IsNullOrEmpty(options.PostgreSqlConnectionString))
                loggerConfig.WriteToPostgreSql(options.PostgreSqlConnectionString);

            return loggerConfig.CreateLogger();
        });

        return services;
    }
}