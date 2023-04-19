using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineApplicationSystem.Application.Common.Interfaces;
using OnlineApplicationSystem.Domain.Entities;

namespace OnlineApplicationSystem.Application.Results.Commands;

public class CreateResultCommandHandler : IRequestHandler<CreateResultRequest, int>
{
    private readonly IApplicationDbContext _context;
    private readonly IApplicantRepository _applicantRepository;
    private readonly ICurrentUserService _currentUserService;
    private readonly IIdentityService _identityService;

    public CreateResultCommandHandler(IApplicationDbContext context, IApplicantRepository applicantRepository, ICurrentUserService currentUserService, IIdentityService identityService)
    {
        _context = context;
        _applicantRepository = applicantRepository;
        _currentUserService = currentUserService;
        _identityService = identityService;

    }
    public async Task<int> Handle(CreateResultRequest request, CancellationToken cancellationToken)
    {
        var userId = _currentUserService.UserId;
        var userDetails = await _identityService.GetApplicationUserDetails(userId, cancellationToken);
        var formNo = userDetails.FormNo;
        var applicantDetails = await _applicantRepository.GetApplicantForUser(userId, cancellationToken);
        var subject = await _context.SubjectModels.FirstOrDefaultAsync(s => s.Id == request.SubjectId, cancellationToken: cancellationToken);
        var grade = await _context.GradeModels.FirstOrDefaultAsync(s => s.Id == request.GradeID, cancellationToken: cancellationToken);
        if (userDetails.Category != "Undergraduate" || userDetails.Foriegn == true) return 0;

        if (await _context.ResultUploadModels.AnyAsync(c =>
                                 c.Subject == subject && c.Grade == grade && c.Year == request.Year.ToString() &&
                                 c.ExamType == request.ExamType && c.IndexNo == request.IndexNo.ToString() &&
                                 c.Sitting == request.Sitting && c.Month == request.Month.ToString() &&
                                 c.ApplicantModelID == applicantDetails.Id) == true)
        {
            return 400;
        }
        var resultDetails = new ResultUploadModel
        {
            Subject = subject,
            Form = (int)Convert.ToInt64(formNo),
            Sitting = request.Sitting,
            Year = request.Year,
            ApplicantModelID = applicantDetails.Id,
            ExamType = request.ExamType,
            Center = request.Center,
            IndexNo = request.IndexNo,
            Month = request.Month,
            Grade = grade
        };
        await _context.ResultUploadModels.AddAsync(resultDetails, cancellationToken);
        if (await _context.SaveChangesAsync(cancellationToken) == 1)
        {
            // check if result uploaded is 6 and above

            if (_context.ResultUploadModels.Count(a => a.ApplicantModelID == applicantDetails.Id) >= 6)
            {
                var applicantIssues = _context.ProgressModels.FirstOrDefault(u => u.ApplicationUserId == _currentUserService.UserId);
                if (applicantIssues != null)
                {
                    applicantIssues.Results = true;
                    applicantIssues.FormCompletion = true;
                    _context.ProgressModels.Update(applicantIssues);
                }
                await _context.SaveChangesAsync(cancellationToken);
                // grade the applicant if hes a wassce or ssce
                if (applicantDetails.FirstQualification == Domain.Enums.EntryQualification.WASSCE || applicantDetails.FirstQualification == Domain.Enums.EntryQualification.SSCE)
                {
                    var Core = new List<int>();
                    var CoreAlt = new List<int>();
                    var Electives = new List<int>();
                    var results = _context.ResultUploadModels.Include(g => g.Grade).Include(s => s.Subject).Where(r => r.ApplicantModelID == applicantDetails.Id);
                    foreach (var score in results)
                    {
                        switch (score.Subject.Code)
                        {
                            case "core":
                                Core.Add(Convert.ToInt32(score.Grade.Value));
                                break;
                            case "core_alt":
                                CoreAlt.Add(Convert.ToInt32(score.Grade.Value));
                                break;
                            case "elective":
                                Electives.Add(Convert.ToInt32(score.Grade.Value)); ;
                                break;
                        }
                    }
                    var gradeValues = new List<int>();
                    gradeValues.AddRange(Core);
                    gradeValues.AddRange(CoreAlt);
                    gradeValues.AddRange(Electives);
                    int failed = _applicantRepository.CheckFailed(gradeValues);
                    int passed = _applicantRepository.CheckPassed(gradeValues);
                    int totalGrade = _applicantRepository.GetTotalAggregate(Core, CoreAlt, Electives);
                    //Console.Write($"total pass is {passed}, failed is {failed}, grade is {totalGrade}");


                    var applicantData = await _context.ApplicantModels.FirstOrDefaultAsync(a => a.ApplicationUserId == userId);
                    applicantData.Grade = totalGrade;
                    applicantData.Results = "Total Failed: " + failed + ", Total Passed " + passed;
                    await _context.SaveChangesAsync(cancellationToken);
                }
            }

            return 200;
        }
        else
        {
            return 500;
        }

    }
}