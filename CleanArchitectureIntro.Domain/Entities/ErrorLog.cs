using CleanArchitectureIntro.Domain.Abstractions;

namespace CleanArchitectureIntro.Domain.Entities;

public sealed class ErrorLog : BaseEntity
{
    public string ErrorMessage { get; set; } = null!;
    public string? StackTrace { get; set; }
    public string RequestPath { get; set; } = null!;
    public string RequestMethod { get; set; } = null!;
    public DateTime Timestamp { get; set; }
}
