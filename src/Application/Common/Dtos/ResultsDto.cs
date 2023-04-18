using OnlineApplicationSystem.Application.Common.Mappings;
using OnlineApplicationSystem.Domain.Entities;

namespace OnlineApplicationSystem.Application.Common.Dtos;

public record ResultsDto : IMapFrom<ResultUploadModel>
{
    public int SubjectID { set; get; }
    public string ExamType { set; get; }
    public int GradeID { set; get; }
    public int? GradeOld { set; get; }
    public string? GradeValueOld { set; get; }
    public string IndexNo { set; get; }
    public string Sitting { set; get; }
    public string Month { set; get; }
    public int Form { set; get; }
    public string Center { set; get; }
    public string Year { set; get; }
    public string? OldSubject { set; get; }
    public string? InstitutionName { set; get; }
    public int ApplicantModelID { set; get; }

    public virtual ApplicantModel ApplicantModel { get; set; }

    public virtual SubjectModel Subject { get; set; }

    public virtual GradeModel Grade { get; set; }


}
