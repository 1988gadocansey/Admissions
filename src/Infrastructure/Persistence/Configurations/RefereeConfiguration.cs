using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructure.Persistence.Configurations;

public class RefereeConfiguration: IEntityTypeConfiguration<RefereeModel>
{
    public void Configure(EntityTypeBuilder<RefereeModel> builder)
    {
        builder.Property(p => p.Name).IsRequired();
        builder.Property(p => p.Email).IsRequired();
        builder.Property(p => p.Position).IsRequired();
        builder.Property(p => p.Institution).IsRequired();
    }
}