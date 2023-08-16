using CleanArchitectureIntro.Domain.Entities;
using CleanArchitectureIntro.Domain.Repositories;
using CleanArchitectureIntro.Persistance.Context;

namespace CleanArchitectureIntro.Infrastructure.Repositories;

public sealed class CarRepository : GenericRepository<Car, AppDbContext> , ICarRepository
{
    public CarRepository(AppDbContext context) : base(context)
    {
    }
}
