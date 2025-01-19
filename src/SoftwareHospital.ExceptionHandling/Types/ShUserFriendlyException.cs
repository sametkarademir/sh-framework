namespace SoftwareHospital.ExceptionHandling.Types;

public class ShUserFriendlyException : Exception
{
    public int StatusCode { get; set; }
    public string ErrorCode { get; set; }

    public ShUserFriendlyException() : base("")
    {
        StatusCode = 400;
        ErrorCode = "User_Friendly_Exception";
    }

    public ShUserFriendlyException(string message) : base(message)
    {
        StatusCode = 400;
        ErrorCode = "User_Friendly_Exception";
    }
    
    public ShUserFriendlyException(string message, string errorCode) : base(message)
    {
        StatusCode = 400;
        ErrorCode = errorCode;
    }
    
    public ShUserFriendlyException(string message, string errorCode, Exception innerException) : base(message, innerException)
    {
        StatusCode = 400;
        ErrorCode = errorCode;
    }
}