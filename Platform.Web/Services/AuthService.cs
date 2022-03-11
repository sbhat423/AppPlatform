using Microsoft.AspNetCore.Components.Authorization;
using Platform.Web.Services.Interfaces;

namespace Platform.Web.Services
{
    public class AuthService : IAuthService
    {
        private readonly AuthenticationStateProvider _authStateProvider;

        public AuthService(AuthenticationStateProvider authenticationStateProvider)
        {
            _authStateProvider = authenticationStateProvider;
        }

        public async Task<Guid> GetUserId()
        {
            var authState = await _authStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;
            var claim = user.Claims.FirstOrDefault(c => c.Type.Contains("nameidentifier"));
            if (claim == null)
            {
                throw new Exception("Invalid user");
            }
            return new Guid(claim.Value);
        }
    }
}
