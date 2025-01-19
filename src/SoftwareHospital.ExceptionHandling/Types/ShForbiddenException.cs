namespace SoftwareHospital.ExceptionHandling.Types;

public class ShForbiddenException : Exception
{
    public string ErrorCode { get; set; }

    public ShForbiddenException()
    {
        ErrorCode = "ACCESS_FORBIDDEN";
    }
    
    public ShForbiddenException(string errorCode)
    {
        ErrorCode = errorCode;
    }

    public ShForbiddenException(string message, string errorCode) : base(message)
    {
        ErrorCode = errorCode;
    }

    public ShForbiddenException(string message, string errorCode, Exception innerException) : base(message, innerException)
    {
        ErrorCode = errorCode;
    }
}