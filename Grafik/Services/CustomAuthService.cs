using Grafik.Data;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Grafik.Services;

public interface ICustomAuthService 
{
    ClaimsPrincipal User { get; }

    Task<bool> IsUserAuthenticated();
    Task<bool> IsAdministrator();
    Task<string> GetLoggedUserName();
    Task<bool> AddAdministratorRoleToUser(ApplicationUser user);
}

public class CustomAuthService : ICustomAuthService
{
    private const string ADMINISTRATOR_ROLE = "Administrator";

    private AuthenticationStateProvider authenticationStateProvider;
    private UserManager<ApplicationUser> userManager;

    public ClaimsPrincipal User => (authenticationStateProvider.GetAuthenticationStateAsync().Result).User;

    public CustomAuthService(
        AuthenticationStateProvider authenticationStateProvider,
        UserManager<ApplicationUser> userManager)
    {
        this.authenticationStateProvider = authenticationStateProvider;
        this.userManager = userManager;
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

    public async Task<bool> AddAdministratorRoleToUser(ApplicationUser user)
    {
        var result = await userManager.AddToRoleAsync(user, ADMINISTRATOR_ROLE);
        return result.Succeeded;
    }
}
