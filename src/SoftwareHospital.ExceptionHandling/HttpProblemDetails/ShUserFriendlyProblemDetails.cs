using Microsoft.AspNetCore.Http;
using SoftwareHospital.ExceptionHandling.Abstracts;

namespace SoftwareHospital.ExceptionHandling.HttpProblemDetails;

public class ShUserFriendlyProblemDetails : AppProblemDetails
{
    public ShUserFriendlyProblemDetails(string errorCode, string detail, string typeUrl) 
        : base(errorCode, detail, StatusCodes.Status400BadRequest, typeUrl)
    {
    }
}