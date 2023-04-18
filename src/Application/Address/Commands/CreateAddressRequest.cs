using MediatR;
namespace OnlineApplicationSystem.Application.Address.Commands;
public record CreateAddressRequest : IRequest<int>
{

    public int Id { set; get; }
    public string? Street { set; get; }
    public string? HouseNumber { set; get; }
    public string? City { set; get; }
    public string? GPRS { set; get; }
    public string? Box { set; get; }
    public int Applicant { set; get; }


}