using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OnlineApplicationSystem.Domain.ValueObjects;
[Keyless]
[NotMapped]
public class PhoneNumber : ValueObject
{

    public string AreaCode { get; }
    public string Number { get; }
    private PhoneNumber() { }
    public PhoneNumber(string number)
    {
        // AreaCode = areaCode;
        Number = number;
    }
    public static PhoneNumber Create(string number)
    {
        return new PhoneNumber(number);
    }
    /*   public string AreaCode { get; private set; }
      public string Number { get; private set; } */

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