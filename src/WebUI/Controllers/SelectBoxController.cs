using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineApplicationSystem.Application.Common.Dtos;
using OnlineApplicationSystem.Application.SelectBoxItems;

namespace WebUI.Controllers;

[Authorize]
public class SelectBoxController : ApiControllerBase
{
    [HttpGet("religions")]
    public async Task<IEnumerable<ReligionDto>> GetReligions()
    {
        return await Mediator.Send(new GetReligionQuery());
    }
    [HttpGet("regions")]
    public async Task<IEnumerable<RegionDto>> GetRegions()
    {
        return await Mediator.Send(new GetRegionQuery());
    }
    [HttpGet("disabilities")]
    public async Task<IEnumerable<DisabilitiesDto>> GetDisabilities()
    {
        return await Mediator.Send(new DisabilityChoiceQuery());
    }
    
    [HttpGet("denominations")]
    public async Task<IEnumerable<DenominationDto>> GetDenominations()
    {
        return await Mediator.Send(new GetDenominationQuery());
    }
    [HttpGet("languages")]
    public async Task<IEnumerable<LanguageDto>> GetLanguages()
    {
        return await Mediator.Send(new GetLanguageQuery());
    }
    [HttpGet("schools")]
    public async Task<IEnumerable<FormerSchoolDto>> GetSchools()
    {
        return await Mediator.Send(new GetFormerSchoolQuery());
    }
    [HttpGet("districts")]
    public async Task<IEnumerable<DistrictDto>> GetDistricts()
    {
        return await Mediator.Send(new GetDistrictQuery());
    }
    [HttpGet("countries")]
    public async Task<IEnumerable<CountryDto>> GetCountries()
    {
        return await Mediator.Send(new GetCountryQuery());
    }
    [HttpGet("grades")]
    public async Task<IEnumerable<GradeDto>> GetGrades()
    {
        return await Mediator.Send(new GetGradeQuery());
    }
    [HttpGet("exams")]
    public async Task<IEnumerable<ExamDto>> GetExams()
    {
        return await Mediator.Send(new GetExamQuery());
    }
    [HttpGet("subjects")]
    public async Task<IEnumerable<SubjectDto>> GetSubjects()
    {
        return await Mediator.Send(new GetSubjectQuery());
    }
    [HttpGet("shsprogramme")]
    public async Task<IEnumerable<SHSProgrammesDto>> GetSHSProgrammes()
    {
        return await Mediator.Send(new GetSHSProgrammesQuery());
    }
    

}