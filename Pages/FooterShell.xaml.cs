using CapProject.Pages;

namespace Desktopapp.Pages;

public partial class FooterShell : StackLayout
{
	public FooterShell()
	{
		InitializeComponent();
	}
    private async void TapGestureRecognizer_Tapped_1(object sender, TappedEventArgs e)
    {
		await Shell.Current.GoToAsync($"//{nameof(Facultyuserpage)}");
		return;
    }

    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync($"//{nameof(SystemsSettingsPage)}");
        return;
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        Shell.Current.FlyoutFooter = null;
        await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        return;
    }
}