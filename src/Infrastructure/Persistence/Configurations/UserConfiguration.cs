using OnlineApplicationSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineApplicationSystem.Domain.ValueObjects;
using OnlineApplicationSystem.Domain.Enums;
using OnlineApplicationSystem.Infrastructure.Identity;

namespace OnlineApplicationSystem.Infrastructure.Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.Property(x => x.Type)
      .HasColumnName("Type")
      .IsRequired()
      .HasConversion<string>();
    }
}