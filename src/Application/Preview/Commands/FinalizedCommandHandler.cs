using System.Collections.Generic;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineApplicationSystem.Application.Common.Exceptions;
using OnlineApplicationSystem.Application.Common.Interfaces;
using OnlineApplicationSystem.Domain.Entities;

namespace OnlineApplicationSystem.Application.Preview.Commands;

public class FinalizedCommandHandler : IRequestHandler<FinalizedRequest, int>
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
    public async Task<int> Handle(FinalizedRequest request, CancellationToken cancellationToken)
    {



        const string email = "hello";
        const string? Subject = "TTU Admissions";
        const string? Body = "Your Admission Form has been received.";
        const string? From = "TTU Admissions";
        var userFormDetails = await _identityService.GetApplicationUserDetails(_currentUserService.UserId, cancellationToken);
        var core = new int[8];
        var coreAlt = new int[7];
        var electives = new int[20];
        var applicant = await _context.ApplicantModels.FirstOrDefaultAsync(a => a.ApplicationUserId == _currentUserService.UserId, cancellationToken);
        if (applicant == null)
        {
            throw new NotFoundException(nameof(ApplicantModel), _currentUserService.UserId);
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

        if (applicantIssues.Picture == false || applicantIssues.FormCompletion == false || applicantIssues.Referee == false || applicantIssues.ResearchInformation == false || applicantIssues.AcademicExperience == false)
        {
            // throw new NotFoundException(nameof(ApplicantModel), request.Id);
            //  throw new NotFoundException("Error finalizing form. Check.", request.Id);
            return 0;
        }
        var smsMessage = "Hi " + applicant.ApplicantName.FirstName + " your application has been received. Vist apply.ttuportal.com with " + userFormDetails.UserName + " as serial and " + userFormDetails.Pin + " as pin to check your admission status.";
        var emailMessage = "Hi " + applicant.ApplicantName.FirstName + " your application has been received. Vist apply.ttuportal.com with " + userFormDetails.UserName + " as serial and " + userFormDetails.Pin + " as pin to check your admission status.";
        // update the applicant issues
        applicantIssues.FormCompletion = true;
        applicantIssues.Age = qualifiesMatured;
        _context.ProgressModels.Update(applicantIssues);
        await _context.SaveChangesAsync(cancellationToken);
        await _identityService.Finalized(_currentUserService.UserId);
        var mailData = new MailData(
              new List<string> { applicant.Email.Value },
              "TTU Admissions Forms",
               Body,
              "TTU",
              "TTU",
              "admissions@ttu.edu.gh",
              "TTU Admissions",
               new List<string> { "admissions@ttu.edu.gh" },
               new List<string> { "gadocansey@gmail.com" }
            );

        // await _emailSender.SendEmail(mailData, cancellationToken);
        await _emailSender.SendEmail(applicant.Email.Value, Subject, emailMessage, From);
        await _smsSender.SendSms(applicant.Phone.Number, smsMessage, applicant.ApplicationNumber.ApplicantNumber, _currentUserService.UserId, cancellationToken);
        return 1;
    }
}