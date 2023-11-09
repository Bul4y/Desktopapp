using CapProject.Pages;
using Desktopapp.Pages;

namespace Desktopapp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(LoadingPage), typeof(LoadingPage));
            Routing.RegisterRoute(nameof(HistoryPage), typeof(HistoryPage));
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            Routing.RegisterRoute(nameof(Homepage), typeof(Homepage));
            Routing.RegisterRoute(nameof(Facultyuserpage), typeof(Facultyuserpage));
            Routing.RegisterRoute(nameof(Adminpage), typeof(Adminpage));
            Routing.RegisterRoute(nameof(Inventorypage), typeof(Inventorypage));
            Routing.RegisterRoute(nameof(ReportPage), typeof(ReportPage));
            Routing.RegisterRoute(nameof(ComponentsPage), typeof(ComponentsPage));
            Routing.RegisterRoute(nameof(SystemsSettingsPage), typeof(SystemsSettingsPage));
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            SecureStorage.Remove("Token");
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }
    }
}