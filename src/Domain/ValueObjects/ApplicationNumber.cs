namespace CleanArchitecture.Domain.ValueObjects;

public class ApplicationNumber:ValueObject
{
    public  long ApplicantNumber { get; }
    public ApplicationNumber(long applicantNumber)
    { 
        ApplicantNumber = applicantNumber;
    }
    private ApplicationNumber(){}
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return ApplicantNumber;
    }
}