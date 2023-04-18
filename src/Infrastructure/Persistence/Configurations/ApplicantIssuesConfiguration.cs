using OnlineApplicationSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineApplicationSystem.Domain.ValueObjects;
using OnlineApplicationSystem.Domain.Enums;
using OnlineApplicationSystem.Infrastructure.Identity;

namespace OnlineApplicationSystem.Infrastructure.Persistence.Configurations;

public class ApplicantIssuesConfiguration : IEntityTypeConfiguration<ApplicantIssueModel>
{
    public void Configure(EntityTypeBuilder<ApplicantIssueModel> builder)
    {



    }
}