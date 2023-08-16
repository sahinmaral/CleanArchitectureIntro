using CleanArchitectureIntro.Domain.Dtos;

using MediatR;

namespace CleanArchitectureIntro.Application.Features.RoleFeatures.Command;

public sealed record CreateRoleCommand(string Name): IRequest<MessageResponse>;
