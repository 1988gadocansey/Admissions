using MediatR;

namespace OnlineApplicationSystem.Application.Preview.Commands;

public class FinalizedRequest : IRequest
{ 
    public string Id { get; set; }
}