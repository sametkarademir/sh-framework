using Microsoft.AspNetCore.Http;
using SoftwareHospital.ExceptionHandling.Abstracts;

namespace SoftwareHospital.ExceptionHandling.HttpProblemDetails;

public class ShUnauthorizedAccessProblemDetails : AppProblemDetails
{
    public ShUnauthorizedAccessProblemDetails(string detail, string errorCode, string typeUrl)
        : base(errorCode, detail, StatusCodes.Status401Unauthorized, typeUrl)
    {
    }
}