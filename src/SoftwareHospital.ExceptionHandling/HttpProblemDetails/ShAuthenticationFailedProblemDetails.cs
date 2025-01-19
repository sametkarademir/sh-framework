using Microsoft.AspNetCore.Http;
using SoftwareHospital.ExceptionHandling.Abstracts;

namespace SoftwareHospital.ExceptionHandling.HttpProblemDetails;

public class ShAuthenticationFailedProblemDetails : AppProblemDetails
{
    public ShAuthenticationFailedProblemDetails(string errorCode, string detail, string typeUrl) 
        : base(errorCode, detail, StatusCodes.Status401Unauthorized, typeUrl)
    {
    }
}