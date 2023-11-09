using CapProject.Pages;
using Desktopapp.Pages;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace CapProject.Viewmodels
{
    public class LoadingViewmodel
    {
        public LoadingViewmodel()
        {
            getUserDets();
        }

        private async Task getUserDets()
        {
            var token = await SecureStorage.GetAsync("Token");
            var tokenHandler = new JwtSecurityTokenHandler();
            var readtoken = tokenHandler.ReadJwtToken(token);

            var claims = readtoken.Claims;

            var userIdClaim = claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            if (userIdClaim == "Admin")
            {
                Shell.Current.FlyoutHeader = new UserBaseHeader();
                Shell.Current.FlyoutFooter = new FooterShell();
                await Shell.Current.GoToAsync($"//{nameof(Homepage)}");
                return;
            }
            if (userIdClaim == "Property Custodian")
            {
                Shell.Current.FlyoutHeader = new UserBaseHeader();
                Shell.Current.FlyoutFooter = new custodianfooter();
                await Shell.Current.GoToAsync($"//{nameof(Homepage)}");
                return;
            }

        }
    }

}
