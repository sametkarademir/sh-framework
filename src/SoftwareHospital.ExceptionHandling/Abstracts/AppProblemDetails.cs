using Microsoft.AspNetCore.Mvc;

namespace SoftwareHospital.ExceptionHandling.Abstracts;

public abstract class AppProblemDetails : ProblemDetails
{
    protected AppProblemDetails(string title, string detail, int status, string type)
    {
        Title = title;
        Detail = detail;
        Status = status;
        Type = type;
    }
}