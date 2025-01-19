using SoftwareHospital.ExceptionHandling.Abstracts;

namespace SoftwareHospital.ExceptionHandling.HttpProblemDetails;

public class ShBusinessProblemDetails : AppProblemDetails
{
    public ShBusinessProblemDetails(string errorCode, string detail, int statusCode, string typeUrl)
        : base(errorCode, detail, statusCode, typeUrl)
    {
    }
}