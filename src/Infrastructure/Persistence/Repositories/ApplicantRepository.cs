using OnlineApplicationSystem.Application.Common.Interfaces;
using OnlineApplicationSystem.Domain.Entities;

namespace OnlineApplicationSystem.Infrastructure.Persistence.Repositories;

public class ApplicantRepository : IApplicantRepository
{

    private readonly IApplicationDbContext _context;

    public ApplicantRepository(IApplicationDbContext context)
    {
        _context = context;

    }

    Task<int> IApplicantRepository.checkFailed(IEnumerable<int> GradeValues)
    {
        throw new NotImplementedException();
    }

    Task<int> IApplicantRepository.checkPassed(IEnumerable<int> GradeValues)
    {
        throw new NotImplementedException();
    }

    Task<bool> IApplicantRepository.ContainsDuplicates(int[] a)
    {
        throw new NotImplementedException();
    }

    Task<int> IApplicantRepository.GetAge(DateTime dateOfBirth)
    {
        throw new NotImplementedException();
    }

    Task<string> IApplicantRepository.GetApplicantCodeFromId(int id)
    {
        throw new NotImplementedException();
    }

    Task<ApplicantModel> IApplicantRepository.GetApplicantIdFromFormNo(string id)
    {
        throw new NotImplementedException();
    }

    Task<ConfigurationModel?> IApplicantRepository.GetConfiguration()
    {
        throw new NotImplementedException();
    }

    public async Task<string> GetFormNo()
    {
        var configuration = _context.ConfigurationModels.OrderByDescending(b => b.Id)
            .FirstOrDefault();
        var formNumber = _context.FormNoModels.First(n => n.Year == configuration.Year);
        return formNumber.No.ToString();
    }

    Task<double> IApplicantRepository.GetHallFee(int hall)
    {
        throw new NotImplementedException();
    }

    Task<string> IApplicantRepository.GetHallName(int hall)
    {
        throw new NotImplementedException();
    }

    Task<string> IApplicantRepository.GetProgrammeName(int id)
    {
        throw new NotImplementedException();
    }

    Task<IEnumerable<ApplicantModel>> IApplicantRepository.GetResults(ApplicantModel applicant, CancellationToken cancellationToken)
    {

        /* return await _repositoryContext.MountedCourses
                .AsNoTracking()
                .Where(a => a.COURSE_SEMESTER == semester)
                .Where(a => a.PROGRAMME == programme)
                .Where(a => a.COURSE_LEVEL == level)
                .Where(a => a.COURSE_YEAR == years)
                .OrderBy(c => c.Courses.COURSE_NAME)
                .OrderBy(c => c.COURSE_TYPE)
                .Include(a => a.Courses)
                .ToListAsync(cancellationToken); */
        throw new NotImplementedException();
    }

    Task<int> IApplicantRepository.GetTotalAggregate(int[] Cores, int[] CoreAlt, int[] Electives)
    {
        throw new NotImplementedException();
    }

    Task<string[]> IApplicantRepository.GradesIssues(int[] Cores, int[] CoreAlt, int[] Electives)
    {
        throw new NotImplementedException();
    }

    Task<bool> IApplicantRepository.QualifiesMature(int age)
    {
        throw new NotImplementedException();
    }

    Task IApplicantRepository.SendEmailNotification(string Email, string Message)
    {
        throw new NotImplementedException();
    }

    Task<int> IApplicantRepository.SendFileToServer(string host, int port, string username, string password, string filePath)
    {
        throw new NotImplementedException();
    }

    Task IApplicantRepository.SendSMSNotification(string PhoneNumber, string Message)
    {
        throw new NotImplementedException();
    }

    public async Task<int> UpdateFormNo(CancellationToken cancellationToken)
    {
        var configuration = _context.ConfigurationModels.OrderByDescending(b => b.Id).FirstOrDefault();
        var update = _context.FormNoModels.First(n => n.Year == configuration.Year);
        update.No += 1;
        return await _context.SaveChangesAsync(cancellationToken);
    }
}