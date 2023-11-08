using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace CapProject.Pages;

public partial class UserBaseHeader : StackLayout
{
    public UserBaseHeader()
    {
        InitializeComponent();
        DisplayUser();
    }
    async void DisplayUser()
    {
        var token = await SecureStorage.GetAsync("Token");
        if (token != null)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var readtoken = tokenHandler.ReadJwtToken(token);

            var claims = readtoken.Claims;

            var userIdClaim = claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;


            if (userIdClaim != null)
            {
                UserName.Text = userIdClaim;
            }
        }
    }
}