namespace CleanArchitecture.Domain.Interface;

public interface ITokenClaimsService
{
    Task<string> GetTokenAsync(string userName);
}
