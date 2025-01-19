using System.Net;
using Microsoft.AspNetCore.Http;
using SoftwareHospital.ExceptionHandling.Extensions;
using SoftwareHospital.ExceptionHandling.HttpProblemDetails;
using SoftwareHospital.ExceptionHandling.Models;
using SoftwareHospital.ExceptionHandling.Types;

namespace SoftwareHospital.ExceptionHandling.Handlers;

public class HttpExceptionHandler : ExceptionHandler
{
    public HttpResponse Response
    {
        #pragma warning disable S112 // General or reserved exceptions should never be thrown
        get => _response ?? throw new NullReferenceException(nameof(_response));
        #pragma warning restore S112 // General or reserved exceptions should never be thrown
        set => _response = value;
    }
    private HttpResponse? _response;
    
    public override Task HandleException(ShAuthenticationFailedException exception, ExceptionTypes typeUrl)
    {
        var details = new ShAuthenticationFailedProblemDetails(exception.ErrorCode, exception.Message, typeUrl.AuthenticationFailedType).ToJson();
        
        Response.StatusCode = StatusCodes.Status401Unauthorized;
        return Response.WriteAsync(details);
    }

    public override Task HandleException(ShBusinessException exception, ExceptionTypes typeUrl)
    {
        var details = new ShBusinessProblemDetails(exception.ErrorCode,exception.Message, exception.StatusCode, typeUrl.BusinessType).ToJson();
        
        if (Enum.IsDefined(typeof(HttpStatusCode), exception.StatusCode) == false)
        {
            exception.StatusCode = (int)HttpStatusCode.InternalServerError;
        }
        
        Response.StatusCode = exception.StatusCode;
        return Response.WriteAsync(details);
    }

    public override Task HandleException(ShUserFriendlyException exception, ExceptionTypes typeUrl)
    {
       var details = new ShUserFriendlyProblemDetails(exception.ErrorCode, exception.Message, typeUrl.UserFriendlyType).ToJson();
        
        Response.StatusCode = StatusCodes.Status400BadRequest;
        return Response.WriteAsync(details);
    }

    public override Task HandleException(ShForbiddenException exception, ExceptionTypes typeUrl)
    {
        var details = new ShForbiddenProblemDetails(exception.ErrorCode, exception.Message, typeUrl.ForbiddenType).ToJson();
        
        Response.StatusCode = StatusCodes.Status403Forbidden;
        return Response.WriteAsync(details);
    }

    public override Task HandleException(ShNotFoundEntityException exception, ExceptionTypes typeUrl)
    {
        var details = new ShNotFoundEntityProblemDetails(exception.ErrorCode, exception.Message, typeUrl.NotFoundEntityType).ToJson();
        
        Response.StatusCode = StatusCodes.Status404NotFound;
        return Response.WriteAsync(details);
    }

    public override Task HandleException(ShUnauthorizedAccessException exception, ExceptionTypes typeUrl)
    {
        var details = new ShUnauthorizedAccessProblemDetails(exception.ErrorCode, exception.Message, typeUrl.UnauthorizedAccessType).ToJson();
        
        Response.StatusCode = StatusCodes.Status403Forbidden;
        return Response.WriteAsync(details);
    }

    public override Task HandleException(ShValidationException exception, ExceptionTypes typeUrl)
    {
        var details = new ShValidationProblemDetails(exception.Errors, typeUrl.ValidationType).ToJson();
        
        Response.StatusCode = StatusCodes.Status400BadRequest;
        return Response.WriteAsync(details);
    }

    public override Task HandleException(Exception exception, ExceptionTypes typeUrl)
    {
        var details = new ShInternalServerErrorProblemDetails(exception.Message, typeUrl.InternalServerErrorType).ToJson();
        
        Response.StatusCode = StatusCodes.Status500InternalServerError;
        return Response.WriteAsync(details);
    }
}
