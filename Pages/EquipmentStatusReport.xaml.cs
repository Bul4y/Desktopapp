using Desktopapp.Viewmodels;

namespace Desktopapp.Pages;

public partial class EquipmentStatusReport : ContentPage
{
	public EquipmentStatusReport(EquipmentStatusReportViewmodel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}