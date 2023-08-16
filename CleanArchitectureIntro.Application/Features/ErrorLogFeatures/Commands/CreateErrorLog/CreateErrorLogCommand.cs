using CleanArchitectureIntro.Domain.Dtos;

using MediatR;

namespace CleanArchitectureIntro.Application.Features.ErrorLogFeatures.Commands.CreateErrorLog;

public sealed record CreateErrorLogCommand(string ErrorMessage, 
    string? StackTrace, 
    string RequestPath, 
    string RequestMethod, 
    DateTime Timestamp) : IRequest<MessageResponse>;
