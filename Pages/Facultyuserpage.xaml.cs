using CapProject.Viewmodels;

namespace CapProject.Pages;

public partial class Facultyuserpage : ContentPage
{
    public Facultyuserpage(FacultypageViewmodel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}