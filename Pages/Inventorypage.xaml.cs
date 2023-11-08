using CapProject.Services.DataService;
using CapProject.Viewmodels;
using ModelsAndDTOs.DTO;

namespace CapProject.Pages;

public partial class Inventorypage : ContentPage
{

    public Inventorypage(InvenotorypageViewmodel vm)
    {
        InitializeComponent();
        BindingContext = vm;

        visibility.IsVisible = false;
        labelVisibility.IsVisible = false;
    }


    private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
    {

        if (e.Item is UniFiedList SelectedItem)
        {
            DataService service = new();
            string CategoryCheck = SelectedItem.Category;
            string PN = SelectedItem.PropertyNumber.ToString();
            if (CategoryCheck != "Computer")
            {
                listview.ItemsSource = null;
                visibility.IsVisible = false;
                labelVisibility.IsVisible = false;

                var GetEquipment = await service.GetEquipmentByPN(PN);
                if (GetEquipment != null)
                {
                    PropertyNumber.Text = GetEquipment.PropertyNumber.ToString();
                    Category.Text = GetEquipment.Category;
                    IssuedTo.Text = GetEquipment.IssuedTo;
                    IssuedBy.Text = GetEquipment.Issuer;
                    Status.Text = GetEquipment.Status;
                    Location.Text = GetEquipment.Location;
                    Unitprice.Text = GetEquipment.UnitPrice.ToString("C", new System.Globalization.CultureInfo("en-PH"));
                    DateCreated.Text = GetEquipment.DateCreated.ToString("yyyy - MM - dd");
                    DateUpdated.Text = GetEquipment.DateUpdated.ToString("yyyy - MM - dd");
                }

                return;
            }
            if (CategoryCheck == "Computer")
            {
                visibility.IsVisible = true;
                labelVisibility.IsVisible = true;

                var GetEquipment = await service.GetComputerDetail(PN);
                if (GetEquipment != null)
                {
                    PropertyNumber.Text = GetEquipment.PN.ToString();
                    Category.Text = GetEquipment.Category;
                    IssuedTo.Text = GetEquipment.IssuedTo;
                    IssuedBy.Text = GetEquipment.IssuedBy;
                    Status.Text = GetEquipment.Status;
                    Location.Text = GetEquipment.Location;
                    Unitprice.Text = GetEquipment.UnitPrice.ToString("C", new System.Globalization.CultureInfo("en-PH"));
                    DateCreated.Text = GetEquipment.DateCreated.ToString("yyyy - MM - dd");
                    listview.ItemsSource = GetEquipment.Components;
                }

                return;
            }
        }
    }
}