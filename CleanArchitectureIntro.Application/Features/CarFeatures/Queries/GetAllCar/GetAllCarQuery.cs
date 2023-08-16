using CleanArchitectureIntro.Domain.Dtos;
using CleanArchitectureIntro.Domain.Entities;

using MediatR;

namespace CleanArchitectureIntro.Application.Features.CarFeatures.Queries.GetAllCar;

public sealed record GetAllCarQuery(int PageNumber = 1,int PageSize=10,string Search="") : IRequest<PaginationResult<Car>>;
