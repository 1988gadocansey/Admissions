using MediatR;
using OnlineApplicationSystem.Domain.Enums;
using OnlineApplicationSystem.Domain.ValueObjects;

namespace OnlineApplicationSystem.Application.ProgrammeInformation.Commands;
public record ProgrammeInfoRequest : IRequest<int>
{

    public int? Id;

    public Session? EntryMode { get; init; }
    public string? FirstQualification { get; init; }
    public string? SecondQualification { get; init; }
    public int? FirstChoiceId { get; init; }
    public int? SecondChoiceId { get; init; }
    public int? ThirdChoiceId { get; init; }
    public bool? Awaiting { get; init; }
    public int? Grade { get; init; }
    public int? LastYearInSchool { get; init; }



}