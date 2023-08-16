using CleanArchitectureIntro.Application.Features.CarFeatures.Commands.CreateCar;
using CleanArchitectureIntro.Application.Features.CarFeatures.Queries.GetAllCar;
using CleanArchitectureIntro.Domain.Dtos;
using CleanArchitectureIntro.Domain.Entities;

namespace CleanArchitectureIntro.Application.Services;

public interface ICarService
{
    Task CreateAsync(CreateCarCommand request,CancellationToken cancellationToken);
    Task<PaginationResult<Car>> GetAllAsync(GetAllCarQuery request,CancellationToken cancellationToken);
}
