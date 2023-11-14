using CapProject.Services.DataService;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ModelsAndDTOs.DTO;
using System.Collections.ObjectModel;

namespace CapProject.Viewmodels
{
    public partial class FacultypageViewmodel : ObservableObject
    {
        private readonly IDataService _Dataservice;
        public ObservableCollection<string> Options { get; }

        [ObservableProperty]
        private string _role;
        [ObservableProperty]
        private string _name;
        [ObservableProperty]
        private string _username;
        [ObservableProperty]
        private string _password;
        [ObservableProperty]
        private string _conpassword;


        [ObservableProperty]
        private bool _isrole = false;
        [ObservableProperty]
        private bool _isname = false;
        [ObservableProperty]
        private bool _isusername = false;
        [ObservableProperty]
        private bool _ispassword = false;
        [ObservableProperty]
        private bool _isconpassword = false;
        [ObservableProperty]
        private bool _passwordmismatch = false;
        [ObservableProperty]
        private List<ViewUserListDTO> _Users;
        public bool valid { get; set; } = true;
        public FacultypageViewmodel(IDataService dataService)
        {
            _Dataservice = dataService;
            Options = new ObservableCollection<string>
            {
                "Admin",
                "Technical Staff",
                "Faculty",
                "Property Custodian",
            };
            LoadUserList();
        }
        [RelayCommand]
        public async Task AddAccount()
        {
            var valid = IsNotEmpty();
            if (valid)
            {
                Passwordmismatch = false;
                AddUserDTO account = new()
                {
                    Name = Name,
                    Username = Username,
                    HashPassword = Password,
                    Role = Role,
                };

                if (Password.Equals(Conpassword))
                {
                    Passwordmismatch = false;
                    var message = await _Dataservice.CreateNewAccount(account);

                    await Application.Current.MainPage.DisplayAlert("Action Result", $"{message}", "Ok");
                    LoadUserList();
                }
                else if (!Password.Equals(Conpassword))
                {
                    Passwordmismatch = true;
                    await Application.Current.MainPage.DisplayAlert("Password Mismatch", "The Password Doesnt Match", "Ok");
                }
            }
        }
        [RelayCommand]
        public Task DeleteUser(int userId)
        {
            var userToRemove = Users.FirstOrDefault(u => u.Id == userId);
            if (userToRemove != null)
            {
                LoadUserList();
            }
        }
        async void LoadUserList()
        {
            Users = await _Dataservice.GetUserList();
        }
        public bool IsNotEmpty()
        {
            Isrole = false;
            Isname = false;
            Isusername = false;
            Ispassword = false;
            Isconpassword = false;
            bool itsvalid = true;
            if (string.IsNullOrEmpty(Name))
            {
                itsvalid = false;
                Isname = true;
            }
            if (string.IsNullOrEmpty(Username))
            {
                itsvalid = false;
                Isusername = true;
            }
            if (string.IsNullOrEmpty(Password))
            {
                itsvalid = false;
                Ispassword = true;
            }
            if (string.IsNullOrEmpty(Conpassword))
            {
                itsvalid = false;
                Isconpassword = true;
            }
            if (string.IsNullOrEmpty(Role))
            {
                itsvalid = false;
                Isrole = true;
            }

            return itsvalid;
        }

    }
}
