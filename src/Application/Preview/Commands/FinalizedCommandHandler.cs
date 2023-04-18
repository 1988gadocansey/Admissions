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
        var applicantIssues = _context.ApplicantIssueModels.FirstOrDefault(u => u.ApplicationUserId == _currentUserService.UserId);
        //lets do our processings
        // check issue with results uploaded
        // calculate total aggregate
        // calculate totalfailed, total passed
        // check if qualified for admission
        // lets send sms 
        // lets send email
        // lets scan through all the processes.. if issues logged them in the issue table
        // finally send preview form as pdf
        // do this result check for undergraduates only
        if (userFormDetails.Category == "Undergraduates")
        {
            var resultsData = _context.ResultUploadModels.Include(g => g.Grade)
                .Include(s => s.Subject)
                .Where(r => r.ApplicantModelID == applicant.Id);
            var totalUploaded = resultsData.Count();

            foreach (var score in resultsData)
            {
                switch (score.Subject.Type)
                {
                    case "core":
                        Array.Fill(core, Convert.ToInt32(score.Grade.Value));
                        break;
                    case "core_alt":
                        Array.Fill(coreAlt, Convert.ToInt32(score.Grade.Value));
                        break;
                    case "elective":
                        Array.Fill(electives, Convert.ToInt32(score.Grade.Value));
                        break;
                }
            }
            if (applicantIssues.Results == false || applicantIssues.Picture == false || applicantIssues.Biodata == false)
            {
                throw new NotFoundException("Error finalizing form. Error results has not been uploaded.", request.Id);
            }
            if (core.Length >= 2 && coreAlt.Length >= 1 && electives.Length >= 3)
            {
                var gradeValues = new List<int>();
                gradeValues.AddRange(core);
                gradeValues.AddRange(coreAlt);
                gradeValues.AddRange(electives);
                var resultsArray = gradeValues.ToArray();
                var failed = _applicantRepository.CheckFailed(resultsArray);
                var passed = _applicantRepository.CheckPassed(resultsArray);
                await _applicantRepository.GradesIssues(core, coreAlt, electives);
                var totalGrade = await _applicantRepository.GetTotalAggregate(core, coreAlt, electives);
                applicantIssues.Age = qualifiesMatured;
                applicantIssues.FormCompletion = true;
                _context.ApplicantIssueModels.Update(applicantIssues);
                await _context.SaveChangesAsync(cancellationToken);
                await _identityService.Finalized(_currentUserService.UserId);
                var applicantData =
                    await _context.ApplicantModels.FirstOrDefaultAsync(a => a.ApplicationUserId == _currentUserService.UserId, cancellationToken: cancellationToken);
                if (applicantData != null)
                {
                    applicantData.Grade = totalGrade;
                    applicantData.Results = "Total Failed: " + failed + ", Total Passed " + passed;
                }
                await _context.SaveChangesAsync(cancellationToken);
            }
            else
            {
                throw new NotFoundException("Incomplete results. Three cores and three electives are required for admissions.", request.Id);
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
        _context.ApplicantIssueModels.Update(applicantIssues);
        await _context.SaveChangesAsync(cancellationToken);
        await _identityService.Finalized(_currentUserService.UserId);
        await _emailSender.SendEmail(applicant.Email.Value, Subject, Body, From);
        await _smsSender.SendSms(applicant.Phone.Number, sms, applicant.ApplicationNumber.ApplicantNumber, _currentUserService.UserId);
        return Unit.Value;
    }
}