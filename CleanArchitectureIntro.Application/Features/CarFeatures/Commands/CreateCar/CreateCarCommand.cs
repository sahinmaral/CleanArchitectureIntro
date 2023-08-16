using CleanArchitectureIntro.Domain.Dtos;

using MediatR;

namespace CleanArchitectureIntro.Application.Features.CarFeatures.Commands.CreateCar;

public sealed record CreateCarCommand(string Name,string Model,int EnginePower) : IRequest<MessageResponse>;
