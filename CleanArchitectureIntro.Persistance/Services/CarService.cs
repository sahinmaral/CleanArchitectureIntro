using AutoMapper;

using CleanArchitectureIntro.Application.Features.CarFeatures.Commands.CreateCar;
using CleanArchitectureIntro.Application.Features.CarFeatures.Queries.GetAllCar;
using CleanArchitectureIntro.Application.Services;
using CleanArchitectureIntro.Domain.Dtos;
using CleanArchitectureIntro.Domain.Entities;
using CleanArchitectureIntro.Domain.Repositories;
using CleanArchitectureIntro.Persistance.Extensions;

namespace CleanArchitectureIntro.Persistance.Services;

public sealed class CarService : ICarService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICarRepository _carRepository;
    private readonly IMapper _mapper;
    public CarService(IMapper mapper, ICarRepository carRepository, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _carRepository = carRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task CreateAsync(CreateCarCommand request, CancellationToken cancellationToken)
    {
        Car newCar = _mapper.Map<Car>(request);

        await _carRepository.AddAsync(newCar,cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task<PaginationResult<Car>> GetAllAsync(GetAllCarQuery request, CancellationToken cancellationToken)
    {
        return await _carRepository
            .GetWhere(x => x.Name.ToLower().Contains(request.Search.ToLower()))
            .ToPagedListAsync(request.PageSize,request.PageNumber);
    }

}
