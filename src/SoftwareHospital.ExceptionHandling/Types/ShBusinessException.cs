using SoftwareHospital.Logging.Enums;

namespace SoftwareHospital.ExceptionHandling.Types;

public class ShBusinessException : Exception
{
    public int StatusCode { get; set; }
    public LogLevel LogLevel { get; set; }
    public string ErrorCode { get; set; }

    public ShBusinessException() : base("An error occurred.")
    {
        StatusCode = 500;
        LogLevel = LogLevel.Error;
        ErrorCode = "INTERNAL_SERVER_ERROR";
    }
    
    public ShBusinessException(string message) : base(message)
    {
        StatusCode = 500;
        LogLevel = LogLevel.Error;
        ErrorCode = "INTERNAL_SERVER_ERROR";
    }
    
    public ShBusinessException(int statusCode) : base("An error occurred.")
    {
        StatusCode = statusCode;
        LogLevel = LogLevel.Error;
        ErrorCode = "INTERNAL_SERVER_ERROR";
    }
    
    public ShBusinessException(LogLevel logLevel) : base("An error occurred.")
    {
        StatusCode = 500;
        LogLevel = logLevel;
        ErrorCode = "INTERNAL_SERVER_ERROR";
    }
    
    public ShBusinessException(int statusCode, LogLevel logLevel) : base("An error occurred.")
    {
        StatusCode = statusCode;
        LogLevel = logLevel;
        ErrorCode = "INTERNAL_SERVER_ERROR";
    }
    
       
    public ShBusinessException(string message, int statusCode, LogLevel logLevel) : base(message)
    {
        StatusCode = statusCode;
        LogLevel = logLevel;
        ErrorCode = "INTERNAL_SERVER_ERROR";
    }
    
    public ShBusinessException(int statusCode, LogLevel logLevel, string errorCode) : base("An error occurred.")
    {
        StatusCode = statusCode;
        LogLevel = logLevel;
        ErrorCode = errorCode;
    }
    
    public ShBusinessException(string message, int statusCode, LogLevel logLevel, string errorCode) : base(message)
    {
        StatusCode = statusCode;
        LogLevel = logLevel;
        ErrorCode = errorCode;
    }

    public ShBusinessException(string message, int statusCode, LogLevel logLevel, string errorCode, Exception innerException) : base(message, innerException)
    {
        StatusCode = statusCode;
        LogLevel = logLevel;
        ErrorCode = errorCode;
    }
}
