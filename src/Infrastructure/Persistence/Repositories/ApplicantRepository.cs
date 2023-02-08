using OnlineApplicationSystem.Application.Common.Interfaces;
using OnlineApplicationSystem.Domain.Contracts;
using OnlineApplicationSystem.Domain.Entities;

namespace OnlineApplicationSystem.Application.Persistence.Repositories;

public class ApplicantRepository : IApplicantRepository
{

    private readonly IApplicationDbContext _context;
    private readonly IUnitOfWork _unitOfWork;

    public ApplicantRepository(IApplicationDbContext context, IUnitOfWork unitOfWork)
    {
        _context = context;
        _unitOfWork = unitOfWork;
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
}