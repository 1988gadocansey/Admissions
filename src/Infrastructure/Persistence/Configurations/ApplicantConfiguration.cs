using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Enums;
using CleanArchitecture.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructure.Persistence.Configurations;


public class ApplicantConfiguration : IEntityTypeConfiguration<ApplicantModel>
{
    public void Configure(EntityTypeBuilder<ApplicantModel> builder)
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
        
        builder.ToTable("ApplicantModel");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .HasColumnName("Id")
            .ValueGeneratedNever();
        builder.OwnsOne(x => x.ApplicantName, nameBuilder =>
        {
            nameBuilder.Property(p => p.FirstName).HasColumnName("FirstName").IsRequired();
            nameBuilder.Property(p => p.LastName).HasColumnName("LastName").IsRequired();
            nameBuilder.Property(p => p.Othernames).HasColumnName("Othernames");
        });
        
        builder.Navigation(e => e.ApplicantName).IsRequired();
        
        /*
                 * Rename properties' columns because they'd otherwise be prefixed with 'PreviousName_'
                 */
        builder.OwnsOne(x => x.PreviousName, nameBuilder =>
        {
            nameBuilder.Property(p => p.FirstName).HasColumnName("PreviousFirstName").IsRequired();
            nameBuilder.Property(p => p.LastName).HasColumnName("PreviousLastName").IsRequired();
            nameBuilder.Property(p => p.Othernames).HasColumnName("PreviousOthernames");
        });
        builder.OwnsOne(x => x.HallFeesPaid, nameBuilder =>
        {
            nameBuilder.Property(p => p.Amount).HasColumnName("Amount").IsRequired();
            nameBuilder.Property(p => p.Currency).HasColumnName("Currency").IsRequired();
            
        });
        
        /*builder.OwnsOne(x => x.Address, nameBuilder =>
        {
            nameBuilder.Property(p => p.Box).HasColumnName("Box").IsRequired();
            nameBuilder.Property(p => p.City).HasColumnName("City").IsRequired();
            nameBuilder.Property(p => p.Street).HasColumnName("Street").IsRequired();
            nameBuilder.Property(p => p.HouseNumber).HasColumnName("HouseNumber").IsRequired();
            nameBuilder.Property(p => p.GPRS).HasColumnName("GPRS").IsRequired();
            
        });*/
        
        builder.OwnsOne(x => x.FeesPaid, nameBuilder =>
        {
            nameBuilder.Property(p => p.Amount).HasColumnName("Amount").IsRequired();
            nameBuilder.Property(p => p.Currency).HasColumnName("Currency").IsRequired();
            
        });
        
            
        builder.Property(x => x.Email)
            .HasColumnName("Email")
            .HasConversion(email=> email.Value, value => new EmailAddress(value))
            .IsRequired();
        builder.Property(x => x.Phone)
            .HasColumnName("Phone")
            .HasConversion(phone => phone.FullNumber(),value=>new PhoneNumber(value,value))
            .IsRequired();
        builder.Property(x => x.AltPhone)
            .HasColumnName("AltPhone")
            .HasConversion(phone => phone.FullNumber(),value=>new PhoneNumber(value,value))
            .IsRequired();
        builder.Property(x => x.GuardianPhone)
            .HasColumnName("GuardianPhone")
            .HasConversion(phone => phone.FullNumber(),value=>new PhoneNumber(value,value))
            .IsRequired();
        builder.Property(x => x.EmergencyContact)
            .HasColumnName("EmergencyContact")
            .HasConversion(phone => phone.FullNumber(),value=>new PhoneNumber(value,value))
            .IsRequired();

        builder.Property(x => x.Gender)
            .HasColumnName("Gender")
            .IsRequired()
            .HasConversion<string>();
        builder.Property(x => x.MaritalStatus)
            .HasColumnName("MaritalStatus")
            .IsRequired()
            .HasConversion(
                value=>value.Value,
                converted=>new MaritalStatus()
                );
       
        /*
        builder.OwnsOne(x => x.FeesPaid, nameBuilder =>
        {
            nameBuilder.Property(p => p.Currency).HasColumnName("FeesPaid").IsRequired();
            nameBuilder.Property(p => p.Amount).HasColumnName("FeesPaid").IsRequired();
             
        });
        
        builder.OwnsOne(x => x.HallFeesPaid, nameBuilder =>
        {
            nameBuilder.Property(p => p.Currency).HasColumnName("HallFeesPaid").IsRequired();
            nameBuilder.Property(p => p.Amount).HasColumnName("HallFeesPaid").IsRequired();
             
        });*/
       
        
        builder.Property(x => x.ApplicationNumber)
            .HasColumnName("ApplicationNumber")
            .HasConversion(applicantNumber=> applicantNumber.ApplicantNumber, value => new ApplicationNumber(value))
            .IsRequired();

        //builder.HasMany<ApplicantModel>(applicant => applicant.Phone);
        
    }
    
}