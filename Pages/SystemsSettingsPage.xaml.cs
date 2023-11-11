using Desktopapp.Viewmodels;

namespace Desktopapp.Pages;

public partial class SystemsSettingsPage : ContentPage
{
	public SystemsSettingsPage(SystemSettingsPageViewmodel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}