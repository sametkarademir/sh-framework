using Microsoft.AspNetCore.Http;
using SoftwareHospital.ExceptionHandling.Abstracts;

namespace SoftwareHospital.ExceptionHandling.HttpProblemDetails;

public class ShInternalServerErrorProblemDetails : AppProblemDetails
{
    public ShInternalServerErrorProblemDetails(string detail, string typeUrl)
        : base("INTERNAL_SERVER_ERROR", detail, StatusCodes.Status500InternalServerError, typeUrl)
    {
    }
}