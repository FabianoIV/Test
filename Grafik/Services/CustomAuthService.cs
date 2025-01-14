using Microsoft.AspNetCore.Components.Authorization;

namespace Grafik.Services;

public interface ICustomAuthService 
{
    Task<bool> IsAuthenticated();
    Task<bool> IsAdministrator();
}

public class CustomAuthService : ICustomAuthService
{
    private const string ADMINISTRATOR_ROLE = "Administrator";

    private AuthenticationStateProvider authenticationStateProvider;

    public CustomAuthService(AuthenticationStateProvider authenticationStateProvider)
    {
        this.authenticationStateProvider = authenticationStateProvider;
    }

    public async Task<bool> IsAuthenticated()
    {
        var authState = await authenticationStateProvider.GetAuthenticationStateAsync();
        return authState.User.Identity?.IsAuthenticated ?? false;
    }

    public async Task<bool> IsAdministrator()
    {
        var authState = await authenticationStateProvider.GetAuthenticationStateAsync();
        return authState.User.IsInRole(ADMINISTRATOR_ROLE);
    }
}
