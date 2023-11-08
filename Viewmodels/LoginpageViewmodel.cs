using CapProject.Pages;
using CapProject.Services.DataService;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ModelsAndDTOs.DTO;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace CapProject.Viewmodels
{
    public partial class LoginpageViewmodel : ObservableObject
    {
        private readonly IDataService _Dataservice;
        [ObservableProperty]
        private string _usernamecred;
        [ObservableProperty]
        private string _passwordcred;
        public LoginpageViewmodel(IDataService dataservice)
        {
            _Dataservice = dataservice;
        }

        [RelayCommand]
        private async Task Login()
        {
            LoginDTO creds = new()
            {
                Username = Usernamecred,
                Password = Passwordcred,
            };

            var token = await _Dataservice.Login(creds);

            if (token != "Error")
            {

                var tokenHandler = new JwtSecurityTokenHandler();
                var readtoken = tokenHandler.ReadJwtToken(token);

                var claims = readtoken.Claims;

                var userIdClaim = claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;

                if (userIdClaim == "Admin")
                {
                    await SecureStorage.SetAsync("Token", token);
                    await Shell.Current.GoToAsync(nameof(LoadingPage));
                    return;
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("User Authorization", "You are Unauthorized to log in", "ok");
                    return;
                }
            }
            await Application.Current.MainPage.DisplayAlert("Login Error", "User is not Recognize", "Retry");
            return;
        }
    }
}
