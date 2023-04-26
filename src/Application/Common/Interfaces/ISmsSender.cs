using OnlineApplicationSystem.Application.Common.Dtos;
using OnlineApplicationSystem.Application.Common.ViewModels;
using OnlineApplicationSystem.Application.Preview.Commands;
using OnlineApplicationSystem.Domain.Entities;

namespace OnlineApplicationSystem.Application.Common.Interfaces;

public interface ISmsSender
{
    Task SendSms(string phoneNumber, string message, long formNo, string appSender, CancellationToken cancellationToken);
}