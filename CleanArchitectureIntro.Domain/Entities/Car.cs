using CleanArchitectureIntro.Domain.Abstractions;

namespace CleanArchitectureIntro.Domain.Entities;

public sealed class Car : BaseEntity
{
    public string Name { get; set; } = null!;
    public string Model { get; set; } = null!;
    public int EnginePower { get; set; } 
}
