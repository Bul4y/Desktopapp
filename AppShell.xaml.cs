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
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            Routing.RegisterRoute(nameof(Homepage), typeof(Homepage));
            Routing.RegisterRoute(nameof(Facultyuserpage), typeof(Facultyuserpage));
            Routing.RegisterRoute(nameof(EquipmentStatusReport), typeof(EquipmentStatusReport));
            Routing.RegisterRoute(nameof(Inventorypage), typeof(Inventorypage));
            Routing.RegisterRoute(nameof(ReportPage), typeof(ReportPage));
            Routing.RegisterRoute(nameof(ComponentsPage), typeof(ComponentsPage));
            Routing.RegisterRoute(nameof(SystemsSettingsPage), typeof(SystemsSettingsPage));
            Routing.RegisterRoute(nameof(ReportView), typeof(ReportView));
            Routing.RegisterRoute(nameof(StatusSummaryPage), typeof(StatusSummaryPage));
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            SecureStorage.Remove("Token");
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }
    }
}