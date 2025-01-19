namespace SoftwareHospital.ExceptionHandling.Types;

public class ShAuthenticationFailedException : Exception
{
    public string ErrorCode { get; set; }

    public ShAuthenticationFailedException() : base("Authentication failed.")
    {
        ErrorCode = "AUTHENTICATION_FAILED";
    }
    
    public ShAuthenticationFailedException(string message) : base(message)
    {
        ErrorCode = "AUTHENTICATION_FAILED";
    }

    public ShAuthenticationFailedException(string message, string errorCode) : base(message)
    {
        ErrorCode = errorCode;
    }

    public ShAuthenticationFailedException(string message, string errorCode, Exception innerException) : base(message, innerException)
    {
        ErrorCode = errorCode;
    }
}