using OnlineApplicationSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineApplicationSystem.Domain.ValueObjects;
using OnlineApplicationSystem.Domain.Enums;

namespace OnlineApplicationSystem.Infrastructure.Persistence.Configurations;

public class ResultUploadConfiguration : IEntityTypeConfiguration<ResultUploadModel>
{
    public void Configure(EntityTypeBuilder<ResultUploadModel> builder)
    {
        /*
         If an Entity contains a collection of Value Objects, we can use the OwnsMany method

         modelBuilder.Entity<Person>().OwnsMany(p => p.PhoneNumbers);
         builder.Entity<Person>().HasKey(x => x.Id);
        builder.Entity<Person>().OwnsOne(p => p.PhoneNumber);
 
        // Or:
        // modelBuilder.Entity<Person>().OwnsOne(typeof(PhoneNumber),
        //    "PhoneNumber");
        // in case PhoneNumber property is private.*/

        /*  builder.ToTable("ApplicantModel");
         builder.HasKey(x => x.Id);
         builder.Property(x => x.Id)
             .HasColumnName("Id")
             .ValueGeneratedNever(); */

        // we are using value object for key read Nick Chamberlain's blog post here: https://buildplease.com/pages/vo-ids/
        builder.ToTable("ResultUploadModels");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
       .HasColumnName("Id");



        builder.Property(x => x.ExamType)
   .HasColumnName("ExamType")

   .HasConversion<string>();



    }


}
