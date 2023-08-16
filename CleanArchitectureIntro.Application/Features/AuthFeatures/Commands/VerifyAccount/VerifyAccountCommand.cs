using CleanArchitectureIntro.Domain.Dtos;

using MediatR;

namespace CleanArchitectureIntro.Application.Features.AuthFeatures.Commands.VerifyAccount
{
    public sealed record VerifyAccountCommand
    (string Username,string Token) : IRequest<MessageResponse>;
}
