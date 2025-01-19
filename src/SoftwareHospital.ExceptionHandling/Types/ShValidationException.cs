using SoftwareHospital.ExceptionHandling.Models;

namespace SoftwareHospital.ExceptionHandling.Types;

public class ShValidationException : System.Exception
{
    public IEnumerable<ValidationExceptionModel> Errors { get; }

    public ShValidationException()
        : base()
    {
        Errors = Array.Empty<ValidationExceptionModel>();
    }

    public ShValidationException(string? message)
        : base(message)
    {
        Errors = Array.Empty<ValidationExceptionModel>();
    }

    public ShValidationException(string? message, System.Exception? innerException)
        : base(message, innerException)
    {
        Errors = Array.Empty<ValidationExceptionModel>();
    }

    public ShValidationException(IEnumerable<ValidationExceptionModel> errors)
        : base(BuildErrorMessage(errors))
    {
        Errors = errors;
    }

    private static string BuildErrorMessage(IEnumerable<ValidationExceptionModel> errors)
    {
        IEnumerable<string> arr = errors.Select(x =>
            $"{Environment.NewLine} -- {x.Property}: {string.Join(Environment.NewLine, values: x.Errors ?? Array.Empty<string>())}"
        );
        return $"Validation failed: {string.Join(string.Empty, arr)}";
    }
}