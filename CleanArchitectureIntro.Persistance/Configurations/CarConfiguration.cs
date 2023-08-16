using CleanArchitectureIntro.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System.Reflection.Emit;

namespace CleanArchitectureIntro.Persistance.Configurations;

public sealed class CarConfiguration : IEntityTypeConfiguration<Car>
{
    public void Configure(EntityTypeBuilder<Car> builder)
    {
        builder.ToTable("Cars");
        builder.HasKey(x => x.Id);
        builder.HasIndex(x => x.Name);
    }
}
