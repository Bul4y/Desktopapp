namespace CapProject.Services.Storage
{
    public class Token
    {

        public static string StoreToken()
        {
            try
            {
                return SecureStorage.GetAsync("id").Result;
            }
            catch (Exception ex)
            {
                // Handle any exceptions (e.g., KeyNotFoundException)
                Console.WriteLine($"Error retrieving JWT token: {ex.Message}");
                return null;
            }
        }
    }
}
