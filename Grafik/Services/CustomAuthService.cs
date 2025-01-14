using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace Grafik.Services;

public interface ICustomAuthService 
{
    ClaimsPrincipal User { get; }

    Task<bool> IsUserAuthenticated();
    Task<bool> IsAdministrator();
    Task<string> GetLoggedUserName();
}

public class CustomAuthService : ICustomAuthService
{
    private const string ADMINISTRATOR_ROLE = "Administrator";

    private AuthenticationStateProvider authenticationStateProvider;

    public ClaimsPrincipal User => (authenticationStateProvider.GetAuthenticationStateAsync().Result).User;

    public CustomAuthService(AuthenticationStateProvider authenticationStateProvider)
    {
        this.authenticationStateProvider = authenticationStateProvider;
    }

    public async Task<bool> IsUserAuthenticated()
    {
        var authState = await authenticationStateProvider.GetAuthenticationStateAsync();
        return authState.User.Identity?.IsAuthenticated ?? false;
    }

    public async Task<bool> IsAdministrator()
    {
        var authState = await authenticationStateProvider.GetAuthenticationStateAsync();
        return authState.User.IsInRole(ADMINISTRATOR_ROLE);
    }

    public async Task<string> GetLoggedUserName()
    {
        var authState = await authenticationStateProvider.GetAuthenticationStateAsync();
        return authState.User.Identity?.Name ?? "";
    }
}
