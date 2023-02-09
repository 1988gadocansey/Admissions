using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OnlineApplicationSystem.Domain.ValueObjects;
[Keyless]
[NotMapped]
public class ApplicantName : ValueObject
{

    public string FirstName { get; }
    public string LastName { get; }
    public string Othernames { get; }
    private ApplicantName() { }
    public static ApplicantName Create(string FirstName, string LastName, string Othernames)
    {
        return new ApplicantName(FirstName, LastName, Othernames);
    }
    public ApplicantName(string firstName, string lastName, string othernames)
    {
        FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
        LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
        Othernames = othernames;
    }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return FirstName;
        yield return LastName;
        yield return Othernames;
    }




}