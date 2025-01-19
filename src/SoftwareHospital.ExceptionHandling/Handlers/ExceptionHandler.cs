using SoftwareHospital.ExceptionHandling.Models;
using SoftwareHospital.ExceptionHandling.Types;

namespace SoftwareHospital.ExceptionHandling.Handlers;

public abstract class ExceptionHandler
{
    public abstract Task HandleException(
        ShAuthenticationFailedException exception,
        ExceptionTypes typeUrl
    );

    public abstract Task HandleException(
        ShForbiddenException exception,
        ExceptionTypes typeUrl
    );

    public abstract Task HandleException(
        ShUnauthorizedAccessException exception,
        ExceptionTypes typeUrl
    );

    public abstract Task HandleException(
        ShNotFoundEntityException exception,
        ExceptionTypes typeUrl
    );

    public abstract Task HandleException(
        ShBusinessException exception,
        ExceptionTypes typeUrl
    );
    
    public abstract Task HandleException(
        ShUserFriendlyException exception,
        ExceptionTypes typeUrl
    );

    public abstract Task HandleException(
        ShValidationException exception,
        ExceptionTypes typeUrl
    );

    public abstract Task HandleException(
        Exception exception,
        ExceptionTypes typeUrl
    );
}