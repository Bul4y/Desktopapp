using CapProject.Pages;

namespace Desktopapp.Pages;

public partial class custodianfooter : StackLayout
{
	public custodianfooter()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
        Shell.Current.FlyoutFooter = null;
        await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        return;
    }
}