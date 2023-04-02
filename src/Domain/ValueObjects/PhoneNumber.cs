using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OnlineApplicationSystem.Domain.ValueObjects;
[Keyless]
[NotMapped]
public class PhoneNumber : ValueObject
{
    private PhoneNumber() { }
    public PhoneNumber(string areaCode, string number)
    {
        AreaCode = areaCode;
        Number = number;
    }
    public static PhoneNumber Create(string areaCode, string number)
    {
        return new PhoneNumber(areaCode, number);
    }
    public string AreaCode { get; private set; }
    public string Number { get; private set; }

    public string FullNumber()
    {
        return $"+{AreaCode} {Number}";
    }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return AreaCode;
        yield return Number;
    }
}