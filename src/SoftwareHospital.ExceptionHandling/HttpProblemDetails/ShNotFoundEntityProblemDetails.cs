using Microsoft.AspNetCore.Http;
using SoftwareHospital.ExceptionHandling.Abstracts;

namespace SoftwareHospital.ExceptionHandling.HttpProblemDetails;

public class ShNotFoundEntityProblemDetails : AppProblemDetails
{
    public ShNotFoundEntityProblemDetails(string detail, string errorCode, string typeUrl)
        : base(errorCode, detail, StatusCodes.Status404NotFound, typeUrl)
    {
    }
}