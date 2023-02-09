using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OnlineApplicationSystem.Domain.ValueObjects;
[Keyless]
[NotMapped]

public class ApplicationNumber : ValueObject
{
    public long ApplicantNumber { get; }
    public static ApplicationNumber Create(long ApplicantNumber)
    {
        return new ApplicationNumber(ApplicantNumber);
    }
    public ApplicationNumber(long applicantNumber)
    {
        ApplicantNumber = applicantNumber;
    }
    private ApplicationNumber() { }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return ApplicantNumber;
    }
}