using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineApplicationSystem.Application.Common.Exceptions;
using OnlineApplicationSystem.Application.Common.Interfaces;
using OnlineApplicationSystem.Domain.Entities;

namespace OnlineApplicationSystem.Application.Preview.Commands;

public class FinalizedCommandHandler : IRequestHandler<FinalizedRequest>
{
    private readonly IApplicationDbContext _context;
    private readonly ICurrentUserService _currentUserService;
    private readonly IIdentityService _identityService;
    private readonly IApplicantRepository _applicantRepository;
    private readonly IEmailSender _emailSender;
    private readonly ISmsSender _smsSender;
    public FinalizedCommandHandler(IApplicationDbContext context, ICurrentUserService currentUserService, IApplicantRepository applicantRepository, IIdentityService identityService, IEmailSender emailSender, ISmsSender smsSender)
    {
        _context = context;
        _currentUserService = currentUserService;
        _identityService = identityService;
        _applicantRepository = applicantRepository;
        _emailSender = emailSender;
        _smsSender = smsSender;
    }
    public async Task<Unit> Handle(FinalizedRequest request, CancellationToken cancellationToken)
    {
        const string sms = "hi";
        const string email = "hello";
        const string? Subject = "TTU Admissions";
        const string? Body = "Your Admission Form has been received.";
        const string? From = "TTU Admissions";
        var userFormDetails = await _identityService.GetApplicationUserDetails(_currentUserService.UserId, cancellationToken);
        var core = new int[8];
        var coreAlt = new int[7];
        var electives = new int[20];
        var applicant = await _context.ApplicantModels
            .FindAsync(new object[] { request.Id }, cancellationToken);
        if (applicant == null)
        {
            throw new NotFoundException(nameof(ApplicantModel), request.Id);
        }
        var qualifiesMatured = await _applicantRepository.QualifiesMature(applicant.Age);
        // go through issue table to see if there are issues to prevent him from finalizing
        //lets create issue flag here
        var applicantIssues = _context.ProgressModels.FirstOrDefault(u => u.ApplicationUserId == _currentUserService.UserId);

        if (applicantIssues != null)
        {
            applicantIssues.Results = true;
            applicantIssues.FormCompletion = true;
            _context.ProgressModels.Update(applicantIssues);
        }
        await _context.SaveChangesAsync(cancellationToken);
        // grade the applicant if hes a wassce or ssce
        if (applicant.FirstQualification == Domain.Enums.EntryQualification.WASSCE || applicant.FirstQualification == Domain.Enums.EntryQualification.SSCE)
        {
            var Core = new List<int>();
            var CoreAlt = new List<int>();
            var Electives = new List<int>();
            var results = _context.ResultUploadModels.Include(g => g.Grade).Include(s => s.Subject).Where(r => r.ApplicantModelID == applicant.Id);
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
            // check results and insert into issue table
            if (_applicantRepository.GradesIssues(Core, CoreAlt, Electives) != null)
            {
                foreach (var arg in _applicantRepository.GradesIssues(Core, CoreAlt, Electives))
                {
                    await _context.ApplicantIssueModels.AddAsync(
                        new ApplicantIssueModel
                        {
                            ApplicantId = applicant.Id,
                            Issue = arg
                        });
                    await _context.SaveChangesAsync(cancellationToken);
                }
            }
        }

        if (applicantIssues.Picture == false || applicantIssues.FormCompletion == false || applicantIssues.Referee == false || applicantIssues.ResearchInformation == false || applicantIssues.AcademicExperience == false)
        {
            // throw new NotFoundException(nameof(ApplicantModel), request.Id);
            throw new NotFoundException("Error finalizing form. Check.", request.Id);
        }
        // update the applicant issues
        applicantIssues.FormCompletion = true;
        applicantIssues.Age = qualifiesMatured;
        _context.ProgressModels.Update(applicantIssues);
        await _context.SaveChangesAsync(cancellationToken);
        await _identityService.Finalized(_currentUserService.UserId);
        await _emailSender.SendEmail(applicant.Email.Value, Subject, Body, From);
        await _smsSender.SendSms(applicant.Phone.Number, sms, applicant.ApplicationNumber.ApplicantNumber, _currentUserService.UserId);
        return Unit.Value;
    }
}