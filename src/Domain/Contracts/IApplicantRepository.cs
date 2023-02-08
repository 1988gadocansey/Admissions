namespace OnlineApplicationSystem.Domain.Contracts;

public interface IApplicantRepository
{
    public Task<IEnumerable<ApplicantModel>> GetResults(ApplicantModel applicant, CancellationToken cancellationToken);
}