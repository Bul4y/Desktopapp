using CapProject.Pages;

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
            if (!string.IsNullOrEmpty(token))
            {
                Shell.Current.FlyoutHeader = new UserBaseHeader();
                await Shell.Current.GoToAsync($"//{nameof(Homepage)}");
            }
            else
            {
                await Shell.Current.GoToAsync(nameof(LoginPage));
            }
        }
    }

}
