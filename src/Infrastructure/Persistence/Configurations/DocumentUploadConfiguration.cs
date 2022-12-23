using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructure.Persistence.Configurations;

public class DocumentUploadConfiguration:IEntityTypeConfiguration<DocumentUploadModel>
{
    public void Configure(EntityTypeBuilder<DocumentUploadModel> builder)
    {
        builder.Property(d => d.Name).IsRequired();
        builder.Property(d => d.Type).IsRequired();
    }
}