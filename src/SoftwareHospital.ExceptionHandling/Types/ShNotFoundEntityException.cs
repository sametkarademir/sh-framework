namespace SoftwareHospital.ExceptionHandling.Types;

public class ShNotFoundEntityException : Exception
{
    public string Type { get; set; }
    public string Id { get; set; }
    public string ErrorCode { get; set; }

    public ShNotFoundEntityException(string type, string id)
        : base($"Entity of type {type} with id {id} not found.")
    {
        Type = type;
        Id = id;
        ErrorCode = "ENTITY_NOT_FOUND";
    }
    
    public ShNotFoundEntityException(string type, string id, string errorCode)
        : base($"Entity of type {type} with id {id} not found.")
    {
        Type = type;
        Id = id;
        ErrorCode = errorCode;
    }

    public ShNotFoundEntityException(string type, string id, string message, string errorCode)
        : base(message)
    {
        Type = type;
        Id = id;
        ErrorCode = errorCode;
    }

    public ShNotFoundEntityException(string type, string id, string message, string errorCode, Exception innerException)
        : base(message, innerException)
    {
        Type = type;
        Id = id;
        ErrorCode = errorCode;
    }
}