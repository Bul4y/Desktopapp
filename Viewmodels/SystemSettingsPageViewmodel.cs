using CapProject.Services.DataService;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.IdentityModel.Tokens;
using ModelsAndDTOs.DTO;

namespace Desktopapp.Viewmodels
{
    public partial class SystemSettingsPageViewmodel : ObservableObject
    {
        private readonly IDataService _Dataservice;
        [ObservableProperty]
        private List<CategoryDTO> _categoryList;
        [ObservableProperty]
        private List<StatusDTO> _statusList;
        [ObservableProperty]
        private List<LocationDTO> _locationList;
        [ObservableProperty]
        private List<IssuerDTO> _IsserList;
        public SystemSettingsPageViewmodel(IDataService dataservice)
        {
            _Dataservice = dataservice;
            Load();
        }

        [RelayCommand]
        public async Task DeleteCategory(int Id)
        {
            var response = await _Dataservice.DeleteStatus(Id);
            await Application.Current.MainPage.DisplayAlert("Action Result", response, "Ok");
            CategoryList = await _Dataservice.GetCategoryList();
            return;
        }
        [RelayCommand]
        public async Task AddCategory()
        {
            if (Connectivity.Current.NetworkAccess == NetworkAccess.Internet)
            {
                bool confirm = false;

                while (!confirm)
                {

                    var result = await Application.Current.MainPage.DisplayPromptAsync("Add Equipment Category", "Please Enter the new Equipment Category", "Add", "Cancel");
                    if (string.IsNullOrEmpty(result))
                    {
                        break;
                    }
                    else
                    {
                        confirm = await Application.Current.MainPage.DisplayAlert("Saving", $"Adding new Equipment Category: {result}", "Yes", "No");
                        if (confirm)
                        {
                            var response = await _Dataservice.AddCategory(result);
                            await Application.Current.MainPage.DisplayAlert("Reponse", response, "Ok");
                            CategoryList = await _Dataservice.GetCategoryList();
                            break;
                        }
                    }
                }
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Network", "Internet Connection is Required", "Ok");
            }
        }


        [RelayCommand]
        public async Task DeleteStatus(int Id)
        {
            var response = await _Dataservice.DeleteStatus(Id);
            await Application.Current.MainPage.DisplayAlert("Action Result", response, "Ok");
            StatusList = await _Dataservice.GetstatusList();
            return;
        }
        [RelayCommand]
        public async Task AddStatus()
        {
            if (Connectivity.Current.NetworkAccess == NetworkAccess.Internet)
            {
                bool confirm = false;

                while (!confirm)
                {

                    var result = await Application.Current.MainPage.DisplayPromptAsync("Add Status", "Please Enter new Status Option", "Add", "Cancel");
                    if (string.IsNullOrEmpty(result))
                    {
                        break;
                    }
                    else
                    {
                        confirm = await Application.Current.MainPage.DisplayAlert("Saving", $"Adding new Status Option: {result}", "Yes", "No");
                        if (confirm)
                        {
                            var response = await _Dataservice.AddStatus(result);
                            await Application.Current.MainPage.DisplayAlert("Reponse", response, "Ok");
                            StatusList = await _Dataservice.GetstatusList();
                            break;
                        }
                    }
                }
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Network", "Internet Connection is Required", "Ok");
            }
        }


        [RelayCommand]
        public async Task DeleteIssuer(int Id)
        {
            var response = await _Dataservice.DeleteIssuers(Id);
            await Application.Current.MainPage.DisplayAlert("Action Result", response, "Ok");
            IsserList = await _Dataservice.GetIssuersNameList();
            return;
        }
        [RelayCommand]
        public async Task AddIssuer()
        {
            if (Connectivity.Current.NetworkAccess == NetworkAccess.Internet)
            {
                bool confirm = false;

                while (!confirm)
                {

                    var result = await Application.Current.MainPage.DisplayPromptAsync("Add Issuer", "Please Enter Issuer Name", "Add", "Cancel");
                    if (string.IsNullOrEmpty(result))
                    {
                        break;
                    }
                    else
                    {
                        confirm = await Application.Current.MainPage.DisplayAlert("Saving", $"Adding new Issuer {result}", "Yes", "No");
                        if (confirm)
                        {
                            var response = await _Dataservice.AddIssuer(result);
                            await Application.Current.MainPage.DisplayAlert("Reponse", response, "Ok");
                            IsserList = await _Dataservice.GetIssuersNameList();
                            break;
                        }
                    }
                }
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Network", "Internet Connection is Required", "Ok");
            }
        }


        [RelayCommand]
        public async Task DeleteLocation(int Id)
        {
            var response = await _Dataservice.DeleteLocation(Id);
            await Application.Current.MainPage.DisplayAlert("Action Result", response, "Ok");
            LocationList = await _Dataservice.GetLocationList();
            return;
        }
        [RelayCommand]
        public async Task AddLocation()
        {
            if (Connectivity.Current.NetworkAccess == NetworkAccess.Internet)
            {
                bool confirm = false;

                while (!confirm)
                {
                    var result = await Application.Current.MainPage.DisplayPromptAsync("Add Location", "Please Enter new Location Option.", "Add", "Cancel");
                    if (string.IsNullOrEmpty(result))
                    {
                        break;
                    }
                    else
                    {
                        confirm = await Application.Current.MainPage.DisplayAlert("Saving", $"Adding new Location Option {result}", "Yes", "No");
                        if (confirm)
                        {
                            var response = await _Dataservice.AddLocation(result);
                            await Application.Current.MainPage.DisplayAlert("Reponse", response, "Ok");
                            LocationList = await _Dataservice.GetLocationList();
                            break;
                        }
                    }
                }
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Network", "Internet Connection is Required", "Ok");
            }
        }

        async void Load()
        {
            CategoryList = await _Dataservice.GetCategoryList();
            LocationList = await _Dataservice.GetLocationList();
            StatusList = await _Dataservice.GetstatusList();
            IsserList = await _Dataservice.GetIssuersNameList();
            return;
        }
    }
}
