using System.Net.Mime;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SoftwareHospital.ExceptionHandling.Handlers;
using SoftwareHospital.ExceptionHandling.Models;
using SoftwareHospital.Logging.Models;
using SoftwareHospital.Logging.Services;
using LogLevel = SoftwareHospital.Logging.Enums.LogLevel;

namespace SoftwareHospital.ExceptionHandling.DependencyInjection;

public class ExceptionMiddleware(RequestDelegate next, Logger logger, IOptions<ExceptionTypes> options)
{
    private readonly HttpExceptionHandler _httpExceptionHandler = new();

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception exception)
        {
            await HandleExceptionAsync(context.Response, exception, options.Value);

            var correlationId = context.Request.Headers["X-Correlation-ID"].FirstOrDefault();
            var snapshotId = context.Request.Headers["X-Snapshot-ID"].FirstOrDefault();
            var sessionId = context.Request.Headers["X-Session-ID"].FirstOrDefault();
            var userId = context.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var message = $"Error occurred. [URL]: {context.Request.Path} [Method]: { context.Request.Method} [QueryString]: {context.Request.QueryString.Value ?? "No Query String"} [User]: {context.User?.Identity?.Name ?? "Anonymous"}";
            logger.Error(new LogEntry
            {
                Timestamp = DateTime.UtcNow,
                Level = LogLevel.Error,
                Message = message,
                Exception = exception,
                CreatorId = userId != null ? Guid.Parse(userId) : null,
                CorrelationId = correlationId != null ? Guid.Parse(correlationId) : Guid.NewGuid(),
                AppSnapshotId = snapshotId != null ? Guid.Parse(snapshotId) : Guid.NewGuid(),
                SessionId = sessionId != null ? Guid.Parse(sessionId) : Guid.NewGuid()
            });
        }
    }
    protected virtual Task HandleExceptionAsync(HttpResponse response, dynamic exception, ExceptionTypes exceptionTypes)
    {
        response.ContentType = MediaTypeNames.Application.Json;
        _httpExceptionHandler.Response = response;
        
        return  _httpExceptionHandler.HandleException(exception, exceptionTypes);
    }
}