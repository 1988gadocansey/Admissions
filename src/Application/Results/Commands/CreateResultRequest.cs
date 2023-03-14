using MediatR;

namespace OnlineApplicationSystem.Application.Results.Commands;
public record CreateResultRequest : IRequest<int>
{

    public int Applicant { set; get; }
    public int SubjectID { set; get; }
    public string ExamType { set; get; }
    public int GradeID { set; get; }
    public int GradeOld { set; get; }
    public string GradeValueOld { set; get; }
    public string IndexNo { set; get; }
    public string Sitting { set; get; }
    public string Month { set; get; }
    public int Form { set; get; }
    public string Center { set; get; }
    public string Year { set; get; }
    public string OldSubject { set; get; }
    public string InstitutionName { set; get; }
    public int ApplicantModelID { set; get; }


}