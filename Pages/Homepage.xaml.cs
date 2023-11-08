using CapProject.Viewmodels;

namespace CapProject.Pages;

public partial class Homepage : ContentPage
{
    public Homepage(HomepageViewmodel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}