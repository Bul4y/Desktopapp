using CapProject.Viewmodels;

namespace CapProject.Pages;

public partial class LoginPage : ContentPage
{
    public LoginPage(LoginpageViewmodel vm)
    {
        InitializeComponent();

        BindingContext = vm;

    }
}