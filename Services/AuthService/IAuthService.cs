namespace CapProject.Services.AuthService
{
    public interface IAuthService
    {
        public string SigninWithUsernameAndPassword(string username, string password);
        public void Logout();
    }
}
