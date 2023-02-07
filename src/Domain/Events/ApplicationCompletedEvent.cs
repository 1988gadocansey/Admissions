namespace OnlineApplicationSystem.Domain.Events;

public class ApplicationCompletedEvent : BaseEvent
{
    public ApplicationCompletedEvent(ApplicantModel applicant)
    {
        applicantModel = applicant;
    }

    private ApplicantModel applicantModel { get; }
}