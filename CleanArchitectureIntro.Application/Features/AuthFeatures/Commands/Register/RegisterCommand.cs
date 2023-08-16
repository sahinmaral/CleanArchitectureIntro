using CleanArchitectureIntro.Domain.Dtos;

using MediatR;

namespace CleanArchitectureIntro.Application.Features.AuthFeatures.Commands.Register;

public sealed record RegisterCommand
    (string Email,
    string UserName,
    string Password) : IRequest<MessageResponse>;
