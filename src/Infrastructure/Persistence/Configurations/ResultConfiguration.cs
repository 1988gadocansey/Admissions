using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructure.Persistence.Configurations;

public class ResultConfiguration: IEntityTypeConfiguration<ResultUploadModel>
{
    

    public void Configure(EntityTypeBuilder<ResultUploadModel> builder)
    {
        builder.Property(t => t.Applicant)
            .IsRequired();
        builder.Property(t => t.Sitting)
            .IsRequired();
        builder.Property(t => t.GradeID)
            .IsRequired();
        builder.Property(t => t.ExamType)
            .IsRequired();
        builder.Property(t => t.Month)
            .IsRequired();
        builder.Property(t => t.Center)
            .IsRequired();
        builder.Property(t => t.SubjectID)
            .IsRequired();
    }
}