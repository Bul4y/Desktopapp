using Desktopapp.Viewmodels;

namespace CapProject.Pages;

public partial class ReportPage : ContentPage
{
    public ReportPage(ReportsPageViewmodel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}