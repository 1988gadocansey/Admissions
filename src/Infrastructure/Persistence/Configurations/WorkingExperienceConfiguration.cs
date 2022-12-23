using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructure.Persistence.Configurations;

public class WorkingExperienceConfiguration:IEntityTypeConfiguration<WorkingExperienceModel>
{
    public void Configure(EntityTypeBuilder<WorkingExperienceModel> builder)
    {
        builder.Property(p => p.CompanyAddress).IsRequired();
        builder.Property(p => p.CompanyFrom).IsRequired();
        builder.Property(p => p.CompanyName).IsRequired();
        builder.Property(p => p.CompanyPhone).IsRequired();
        builder.Property(p => p.CompanyPosition).IsRequired();
        builder.Property(p => p.CompanyTo).IsRequired();
    }
}