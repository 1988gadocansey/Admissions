using OnlineApplicationSystem.Application.Common.Mappings;
using OnlineApplicationSystem.Domain.Entities;

namespace OnlineApplicationSystem.Application.Common.Dtos;

public record AddressDto : IMapFrom<Address>
{

    public int Id { set; get; }
    public string Street { set; get; }
    public string HouseNumber { set; get; }
    public string City { set; get; }
    public string GPRS { set; get; }
    public string Box { set; get; }

    private IEnumerable<ApplicantModel>? ApplicantModel { get; set; }

}