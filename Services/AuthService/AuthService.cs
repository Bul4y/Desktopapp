using CapProject.Services.DataService;
using ModelsAndDTOs.DTO;

namespace CapProject.Services.AuthService
{
    class AuthService : IAuthService
    {
        private readonly IDataService _dataservice;

        public AuthService(IDataService dataservice)
        {
            _dataservice = dataservice;
        }

        public void Logout()
        {
            SecureStorage.Remove("Token");
        }

        public string SigninWithUsernameAndPassword(string username, string password)
        {
            LoginDTO dto = new()
            {
                Username = username,
                Password = password
            };

            var token = _dataservice.Login(dto);

            return token.ToString();
        }
    }
}
