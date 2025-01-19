using Microsoft.AspNetCore.Http;
using SoftwareHospital.ExceptionHandling.Abstracts;

namespace SoftwareHospital.ExceptionHandling.HttpProblemDetails;

public class ShForbiddenProblemDetails : AppProblemDetails
{
    public ShForbiddenProblemDetails(string detail, string errorCode, string typeUrl)
        : base(errorCode, detail, StatusCodes.Status403Forbidden, typeUrl)
    {
    }
}