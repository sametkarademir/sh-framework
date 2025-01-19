namespace SoftwareHospital.ExceptionHandling.Models;

public class ExceptionTypes
{
    public string AuthenticationFailedType { get; set; } = "https://example.com/probs/authentication";
    public string BusinessType { get; set; } = "https://example.com/probs/business";
    public string UserFriendlyType { get; set; } = "https://example.com/probs/user-friendly";
    public string ForbiddenType { get; set; } = "https://example.com/probs/forbidden";
    public string NotFoundEntityType { get; set; } = "https://example.com/probs/not-found-entity";
    public string UnauthorizedAccessType { get; set; } = "https://example.com/probs/unauthorized-access";
    public string ValidationType { get; set; } = "https://example.com/probs/validation";
    public string InternalServerErrorType { get; set; } = "https://example.com/probs/internal-server-error";
}