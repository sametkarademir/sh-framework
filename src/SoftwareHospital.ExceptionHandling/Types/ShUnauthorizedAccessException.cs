namespace SoftwareHospital.ExceptionHandling.Types;

public class ShUnauthorizedAccessException : Exception
{
    public string ErrorCode { get; set; }

    public ShUnauthorizedAccessException() : base("Unauthorized access.")
    {
        ErrorCode = "UNAUTHORIZED_ACCESS";
    }

    public ShUnauthorizedAccessException(string message) : base(message)
    {
        ErrorCode = "UNAUTHORIZED_ACCESS";
    }
    
    public ShUnauthorizedAccessException(string message, string errorCode) : base(message)
    {
        ErrorCode = errorCode;
    }

    public ShUnauthorizedAccessException(string message, string errorCode, Exception innerException) : base(message, innerException)
    {
        ErrorCode = errorCode;
    }
}