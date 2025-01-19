using Microsoft.AspNetCore.Http;
using SoftwareHospital.ExceptionHandling.Abstracts;
using SoftwareHospital.ExceptionHandling.Models;

namespace SoftwareHospital.ExceptionHandling.HttpProblemDetails;

public class ShValidationProblemDetails : AppProblemDetails
{
    public IEnumerable<ValidationExceptionModel> Errors { get; init; }

    public ShValidationProblemDetails(IEnumerable<ValidationExceptionModel> errors, string typeUrl)
        : base("VALIDATION_ERROR", "One or more validation errors occurred.", StatusCodes.Status400BadRequest, typeUrl)
    {
        Errors = errors;
    }
}