using OnlineApplicationSystem.Domain.Entities;
using OnlineApplicationSystem.Application.Common.Mappings;
namespace OnlineApplicationSystem.Application.Common.Dtos;
public record HallDto : IMapFrom<HallModel>
{
    public int? Id { set; get; }
    public string? Name { set; get; }
    public int BankAcc { set; get; }
    public double Fees { set; get; }
}