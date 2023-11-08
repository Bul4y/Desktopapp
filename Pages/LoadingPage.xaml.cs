using CapProject.Viewmodels;

namespace CapProject.Pages;

public partial class LoadingPage : ContentPage
{
    public LoadingPage(LoadingViewmodel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}