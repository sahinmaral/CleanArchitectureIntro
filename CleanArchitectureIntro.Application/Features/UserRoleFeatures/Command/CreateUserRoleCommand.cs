using CleanArchitectureIntro.Domain.Dtos;

using MediatR;

namespace CleanArchitectureIntro.Application.Features.AuthFeatures.Commands.Register;

public sealed record CreateUserRoleCommand(string UserId,string RoleId)
    : IRequest<MessageResponse>;