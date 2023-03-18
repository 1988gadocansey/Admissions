using System.Net;
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Web;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineApplicationSystem.Application.Common.Interfaces;
using OnlineApplicationSystem.Domain.Entities;
using OnlineApplicationSystem.Application.Common.Dtos;
using OnlineApplicationSystem.Application.Common.ViewModels;
using OnlineApplicationSystem.Infrastructure.Identity;
using RestSharp;

namespace OnlineApplicationSystem.Infrastructure.Persistence.Repositories;

public class ApplicantRepository : IApplicantRepository
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly UserManager<ApplicationUser> _userManager;
    //readonly IRestClient _client;
    //private readonly RestClient _client;
    public ApplicantRepository(IApplicationDbContext context, IMapper mapper, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _mapper = mapper;
        _userManager = userManager;
        // _client = client;
    }
    public int CheckFailed(IEnumerable<int> gradeValues) => gradeValues.Count(values => values > 7);
    public int CheckPassed(IEnumerable<int> gradeValues) => gradeValues.Count(values => values < 7);
    public Task<bool> ContainsDuplicates(IEnumerable<int> results) => results.Count() != results.Distinct().Count() ? Task.FromResult(true) : Task.FromResult(false);

    public Task<int> GetAge(DateOnly dateOfBirth)
    {
        var today = DateTime.Today;
        var a = (today.Year * 100 + today.Month) * 100 + today.Day;
        var b = (dateOfBirth.Year * 100 + dateOfBirth.Month) * 100 + dateOfBirth.Day;
        var age = (a - b) / 10000;
        return Task.FromResult(age);
    }
    public async Task<ApplicantVm> GetApplicant(int Id, CancellationToken cancellationToken)
    {
        var applicant = await _context.ApplicantModels.FirstOrDefaultAsync(a => a.Id == Id, cancellationToken);
        var applicantDetails = _mapper.Map<ApplicantVm>(applicant);
        return applicantDetails;
    }
    public async Task<ApplicantVm> GetApplicantByApplicationNumber(long ApplicationNumber, CancellationToken cancellationToken)
    {
        var applicant = await _context.ApplicantModels.FirstOrDefaultAsync(a => a.ApplicationNumber.ApplicantNumber == ApplicationNumber, cancellationToken);
        var applicantDetails = _mapper.Map<ApplicantVm>(applicant);
        return applicantDetails;
    }

    public async Task<ApplicantVm> GetApplicantForUser(string Id, CancellationToken cancellationToken)
    {
        var applicant = await _context.ApplicantModels.FirstOrDefaultAsync(a => a.ApplicationUserId == Id, cancellationToken);
        var applicantDetails = _mapper.Map<ApplicantVm>(applicant);
        return applicantDetails;
    }

    public async Task<ConfigurationModel?> GetConfiguration()
    {
        return await _context.ConfigurationModels.OrderByDescending(b => b.Id)
            .FirstOrDefaultAsync();
    }

    public async Task<string> GetFormNo()
    {
        var configuration = await _context.ConfigurationModels.OrderByDescending(b => b.Id)
            .FirstOrDefaultAsync();
        var formNumber = await _context.FormNoModels.FirstAsync(n => n.Year == configuration.Year);
        return formNumber.No.ToString();
    }

    public async Task<int> GetTotalAggregate(IEnumerable<int> Cores, IEnumerable<int> CoreAlt, IEnumerable<int> Electives)
    {
        if (Cores.Count() != 2 || !CoreAlt.Any() || Electives.Count() < 3) return await Task.FromResult(0);
        var totalCores = Cores.Sum();
        var totalCoAlt = CoreAlt.Order().Take(1).Sum();
        var totalElective = CoreAlt.Order().Take(3).Sum();
        var total = totalElective + totalCoAlt + totalCores;
        return await Task.FromResult(total);
    }

    public async Task<IEnumerable<string>> GradesIssues(IEnumerable<int> Cores, IEnumerable<int> CoreAlt, IEnumerable<int> Electives)
    {

        //IEnumerable<string> error = new []{ ""} ;
        var error = new[] { "" };
        /*
        var user = await _userManager.FindByIdAsync(userId);
        var applicant = await _context.ApplicantModels.FirstOrDefaultAsync(a => a.ApplicationUserId == userId);
        var results = _context.ResultUploadModels.Where(a => a.ApplicantModelID == applicant.Id);
        */
        if (Cores.Count() + CoreAlt.Count() + Electives.Count() != 6)
        {
            const string msg = "Results not completed.";
            Array.Fill(error, msg);
        }
        else if (Cores.Count() < 2)
        {
            const string msg = "Minimum of two(2) core subjects not met.";
            Array.Fill(error, msg);
        }
        else if (Electives.Count() < 3)
        {
            const string msg = "Minimum of three(3) elective subjects not met.";
            Array.Fill(error, msg);
        }
        else if (!CoreAlt.Any())
        {
            const string msg = "Social or Science required.";
            Array.Fill(error, msg);
        }
        else
        {
            string msg = null;
            Array.Fill(error, msg);
        }

        return error;
    }

    public async Task<bool> QualifiesMature(int age)
    {
        return await Task.FromResult((age >= 25));
    }
    public async Task<int> UpdateFormNo(CancellationToken cancellationToken)
    {
        var configuration = _context.ConfigurationModels.OrderByDescending(b => b.Id).FirstOrDefault();
        var update = _context.FormNoModels.First(n => n.Year == configuration.Year);
        update.No += 1;
        return await _context.SaveChangesAsync(cancellationToken);
    }
    public async Task<IEnumerable<RegionDto>> Regions(CancellationToken cancellationToken)
    {

        var data = await _context.RegionModels.ToListAsync(cancellationToken);
        /* var data = await _context.RegionModels.Select(b =>
        new RegionDto()
        {
            Id = b.Id,
            Name = b.Name,
        }).ToListAsync(cancellationToken: cancellationToken);
        return data; */

        var selectBoxItem = _mapper.Map<IEnumerable<RegionDto>>(data);
        return selectBoxItem;
    }
    public async Task<IEnumerable<ReligionDto>> Religions(CancellationToken cancellationToken)
    {
        var data = await _context.ReligionModels.ToListAsync(cancellationToken);
        var selectBoxItem = _mapper.Map<IEnumerable<ReligionDto>>(data);
        return selectBoxItem;

    }
    public async Task<IEnumerable<SubjectDto>> Subjects(CancellationToken cancellationToken)
    {
        var data = await _context.SubjectModels.ToListAsync(cancellationToken);
        var selectBoxItem = _mapper.Map<IEnumerable<SubjectDto>>(data);
        return selectBoxItem;
    }
    public async Task<IEnumerable<ExamDto>> Exams(CancellationToken cancellationToken)
    {
        var data = await _context.ExamModels.ToListAsync(cancellationToken);
        var selectBoxItem = _mapper.Map<IEnumerable<ExamDto>>(data);
        return selectBoxItem;
    }
    public async Task<IEnumerable<FormerSchoolDto>> Schools(CancellationToken cancellationToken)
    {
        var data = await _context.FormerSchoolModels.ToListAsync(cancellationToken);
        var selectBoxItem = _mapper.Map<IEnumerable<FormerSchoolDto>>(data);
        return selectBoxItem;
    }
    /*  public ProgrammeModel Programmes(string FormType)
     {
         var data = _context.ProgrammeModels.Where(a => a.Type == FormType).Select(p => new { p.Id, p.Name }).ToList().OrderBy(a => a.Name);

     } */
    public async Task<IEnumerable<ProgrammeDto>> Programmes(string FormType)
    {
        var types = new Dictionary<string, string>
            {
                { "DIPLOMA", "DipTECH" },
                { "MTECH", "MTECH" },
                { "BTECH", "DEGREE" },
                { "MATURE", "BTECH" },
                { "TOPUP", "BTECH" },
                { "BRIDGING", "BTECH" },
                 { "CERTIFICATE", "CERT" },
                { "HND", "HND" },
                { "ACCELERATED", "BTECH" }
            };
        var formType = types.FirstOrDefault(x => x.Value == FormType).Value;


        var programme = _context.ProgrammeModels.AsNoTracking()
            .OrderBy(n => n.Name)
            .Where(n => n.Type == formType).
            ToListAsync();

        return _mapper.Map<IEnumerable<ProgrammeDto>>(programme);
    }

    public async Task<IEnumerable<CountryDto>> Countries(CancellationToken cancellationToken)
    {
        var data = await _context.CountryModels
       .ToListAsync(cancellationToken: cancellationToken);
        return _mapper.Map<IEnumerable<CountryDto>>(data);
    }

    public async Task<IEnumerable<DistrictDto>> Districts(CancellationToken cancellationToken)
    {
        var data = await _context.DistrictModels
       .ToListAsync(cancellationToken: cancellationToken);
        return _mapper.Map<IEnumerable<DistrictDto>>(data);
    }

    public async Task<IEnumerable<DenominationDto>> Denominations(CancellationToken cancellationToken)
    {
        var data = await _context.DenominationModels
      .ToListAsync(cancellationToken: cancellationToken);
        return _mapper.Map<IEnumerable<DenominationDto>>(data);

    }

    public async Task<IEnumerable<HallDto>> Halls(CancellationToken cancellationToken)
    {
        var data = await _context.HallModels
    .ToListAsync(cancellationToken: cancellationToken);
        return _mapper.Map<IEnumerable<HallDto>>(data);
    }
    public async Task<IEnumerable<GradeDto>> Grades(CancellationToken cancellationToken)
    {
        var data = await _context.GradeModels
    .ToListAsync(cancellationToken: cancellationToken);
        return _mapper.Map<IEnumerable<GradeDto>>(data);
    }
    public async Task<IEnumerable<SHSProgrammesDto>> SHSProgrammes(CancellationToken cancellationToken)
    {
        var data = await _context.SHSProgrammes
    .ToListAsync(cancellationToken: cancellationToken);
        return _mapper.Map<IEnumerable<SHSProgrammesDto>>(data);
    }
    public async Task<IEnumerable<DisabilitiesDto>> Disabilities(CancellationToken cancellationToken)
    {
        var data = await _context.DistrictModels
    .ToListAsync(cancellationToken: cancellationToken);
        return _mapper.Map<IEnumerable<DisabilitiesDto>>(data);
    }
    public async Task<IEnumerable<LanguageDto>> Languages(CancellationToken cancellationToken)
    {
        var data = await _context.Languages
    .ToListAsync(cancellationToken: cancellationToken);
        return _mapper.Map<IEnumerable<LanguageDto>>(data);
    }
    public async Task<IEnumerable<SHSAttendedDto>> SHSAttendeds(CancellationToken cancellationToken)
    {
        var data = await _context.SHSAttendedModels
    .ToListAsync(cancellationToken: cancellationToken);
        return _mapper.Map<IEnumerable<SHSAttendedDto>>(data);
    }

    public async Task<IEnumerable<UniversityAttendedDto>> UniversityAttended(CancellationToken cancellationToken)
    {
        var data = await _context.UniversityAttendedModels
    .ToListAsync(cancellationToken: cancellationToken);
        return _mapper.Map<IEnumerable<UniversityAttendedDto>>(data);
    }



}