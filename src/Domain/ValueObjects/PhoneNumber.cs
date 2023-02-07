namespace OnlineApplicationSystem.Domain.ValueObjects;

public class PhoneNumber : ValueObject
{
    private PhoneNumber() { }
    public PhoneNumber(string areaCode, string number)
    {
        AreaCode = areaCode;
        Number = number;
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