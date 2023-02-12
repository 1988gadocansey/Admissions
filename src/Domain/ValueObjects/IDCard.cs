using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OnlineApplicationSystem.Domain.ValueObjects;
[Keyless]
[NotMapped]
public class IDCard : ValueObject
{

    public IDCard(string nationalIDType, string nationalIDNo)
    {
        if (nationalIDType is null)
        {
            throw new Exception("Invalid IDCard name");
        }
        this.NationalIDType = nationalIDType;
        this.NationalIDNo = nationalIDNo;
    }

    public static IDCard Create(string nationalIDType, string nationalIDNo)
    {
        if (nationalIDType is null)
        {
            throw new Exception("Invalid IDCard name");
        }
        return new IDCard(nationalIDNo, nationalIDType);
    }


    public string NationalIDType { get; set; }
    public string NationalIDNo { get; set; }

    public bool Equals(IDCard other)
    {
        if (object.ReferenceEquals(other, null)) return false;
        if (object.ReferenceEquals(other, this)) return true;
        return this.NationalIDType.Equals(other.NationalIDType) && this.NationalIDNo.Equals(other.NationalIDNo);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return NationalIDNo;
    }

    public override bool Equals(object obj)
    {
        return Equals(obj as IDCard);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(base.GetHashCode(), NationalIDType, NationalIDType);
    }
}