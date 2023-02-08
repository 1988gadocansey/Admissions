using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OnlineApplicationSystem.Domain.ValueObjects;
[Keyless]
[NotMapped]
public class EmailAddress : ValueObject
{
    public string Value { get; }
    private EmailAddress() { }
    public EmailAddress(string value)
    {
        if (!value.Contains("@")) throw new Exception("Email is invalid");
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentNullException(nameof(value));
        }

        if (value.Length > 320)
        {
            throw new ArgumentOutOfRangeException("value is too long");
        }
        //more validations
        Value = value;
    }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}