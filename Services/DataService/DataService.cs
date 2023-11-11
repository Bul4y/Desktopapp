using ModelsAndDTOs.DTO;
using ModelsAndDTOs.Models;
using System.Diagnostics;
using System.Text;
using System.Text.Json;

namespace CapProject.Services.DataService;

public class DataService : IDataService
{
    private readonly HttpClient _Httpclient;
    private readonly string _BaseAddress;
    private readonly string _Url;
    private readonly JsonSerializerOptions _jsonSerializer;

    public DataService()
    {
        _Httpclient = new HttpClient();
        _BaseAddress = "https://equipchek.somee.com";
        _Url = $"{_BaseAddress}/EquipCheckWebApi";
        _jsonSerializer = new JsonSerializerOptions()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
    }

    public async Task<string> CreateNewAccount(AddUserDTO DTO)
    {
        try
        {
            var jsonconvert = JsonSerializer.Serialize(DTO, _jsonSerializer);
            var content = new StringContent(jsonconvert, Encoding.UTF8, "application/json");
            var message = await _Httpclient.PostAsync($"{_Url}/User/AddUser", content);
            string readmessage = await message.Content.ReadAsStringAsync();

            if (message.IsSuccessStatusCode)
            {
                return readmessage;
            }
            else
            {

                return readmessage;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return null;
        }
    }

    public async Task<List<UniFiedList>> GetItemList()
    {
        try
        {
            var message = await _Httpclient.GetAsync($"{_Url}/UnifyList/GetItemList");

            if (message.IsSuccessStatusCode)
            {
                string readmessage = await message.Content.ReadAsStringAsync();

                List<UniFiedList> list = JsonSerializer.Deserialize<List<UniFiedList>>(readmessage, _jsonSerializer);

                return list;
            }
            else
            {

                return null;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return null;
        }
    }

    public async Task<string> Login(LoginDTO login)
    {
        try
        {
            var jsonconvert = JsonSerializer.Serialize(login, _jsonSerializer);
            var content = new StringContent(jsonconvert, Encoding.UTF8, "application/json");
            var message = await _Httpclient.PostAsync($"{_Url}/User/Login", content);
            if (message.IsSuccessStatusCode)
            {
                string readmessage = await message.Content.ReadAsStringAsync();

                return readmessage;
            }
            else
            {

                return "Error";
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return null;
        }
    }
    public async Task<int[]> GetByCurrentMonthCountData()
    {
        try
        {
            var response = await _Httpclient.GetAsync($"{_Url}/UnifyList/GetMonthlyCountByCurrentYear");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var countsList = JsonSerializer.Deserialize<int[]>(json);
                return countsList;
            }
            return null;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return null;
        }
    }

    public async Task<int> GetTotalUserCount()
    {
        try
        {
            var response = await _Httpclient.GetAsync($"{_Url}/User/GetTotalUser");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var countsList = JsonSerializer.Deserialize<int>(json);
                return countsList;
            }
            return 0;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return 0;
        }
    }

    public async Task<int> GetTotalEquipmentCount()
    {
        try
        {
            var response = await _Httpclient.GetAsync($"{_Url}/UnifyList/GetTotalEquipmentCount");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var countsList = JsonSerializer.Deserialize<int>(json);
                return countsList;
            }
            return 0;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return 0;
        }
    }

    public async Task<List<HistoryModel>> GetHistoryLog()
    {
        try
        {
            var response = await _Httpclient.GetAsync($"{_Url}/UnifyList/GetHistory");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                List<HistoryModel> historylist = JsonSerializer.Deserialize<List<HistoryModel>>(json, _jsonSerializer);
                return historylist;
            }
            return null;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return null;
        }
    }

    public async Task<List<StatusCount>> GetStatusCount()
    {
        try
        {
            var response = await _Httpclient.GetAsync($"{_Url}/UnifyList/GetItemCountByStatus");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                List<StatusCount> StatusCountList = JsonSerializer.Deserialize<List<StatusCount>>(json, _jsonSerializer);
                return StatusCountList;
            }
            return null;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return null;
        }
    }

    public async Task<List<ViewingComputerDTO>> GetComputerList()
    {
        try
        {
            var response = await _Httpclient.GetAsync($"{_Url}/Computer/GetComputerList");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                List<ViewingComputerDTO> ComputerList = JsonSerializer.Deserialize<List<ViewingComputerDTO>>(json, _jsonSerializer);
                return ComputerList;
            }
            return null;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return null;
        }
    }

    public async Task<ComputerDetailDTO> GetComputerDetail(string PN)
    {
        try
        {
            var response = await _Httpclient.GetAsync($"{_Url}/Computer/ViewComputerDetail/{PN}");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                ComputerDetailDTO ComputerList = JsonSerializer.Deserialize<ComputerDetailDTO>(json, _jsonSerializer);
                return ComputerList;
            }
            return null;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return null;
        }
    }

    public async Task<List<ViewUserListDTO>> GetUserList()
    {
        try
        {
            var response = await _Httpclient.GetAsync($"{_Url}/User/GetUserList");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                List<ViewUserListDTO> UserList = JsonSerializer.Deserialize<List<ViewUserListDTO>>(json, _jsonSerializer);
                return UserList;
            }
            return null;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return null;
        }
    }

    public async Task<GetEquipmentListDTO> GetEquipmentByPN(string PN)
    {
        try
        {
            var response = await _Httpclient.GetAsync($"{_Url}/Equipment/GetEquipmentByPN/{PN}");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                GetEquipmentListDTO EquipmentDetail = JsonSerializer.Deserialize<GetEquipmentListDTO>(json, _jsonSerializer);
                return EquipmentDetail;
            }
            return null;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return null;
        }
    }

    public async Task<List<ViewComponentListDTO>> GetComponentList()
    {
        try
        {
            var response = await _Httpclient.GetAsync($"{_Url}/ComputerComponent/GetComponentList");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                List<ViewComponentListDTO> EquipmentDetail = JsonSerializer.Deserialize<List<ViewComponentListDTO>>(json, _jsonSerializer);
                return EquipmentDetail;
            }
            return null;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return null;
        }
    }

    public async Task<List<StatusDTO>> GetstatusList()
    {
        try
        {
            var response = await _Httpclient.GetAsync($"{_Url}/UnifyList/GetStatusList");
            if (response.IsSuccessStatusCode)
            {
                string readmessage = await response.Content.ReadAsStringAsync();
                List<StatusDTO> result = JsonSerializer.Deserialize<List<StatusDTO>>(readmessage, _jsonSerializer);
                return result;
            }
            return null;
        }
        catch (Exception ex)
        {
            var message = ex.Message;
            Debug.WriteLine(message);
            return null;
        }
    }

    public async Task<List<CategoryDTO>> GetCategoryList()
    {
        try
        {
            var response = await _Httpclient.GetAsync($"{_Url}/UnifyList/GetCategoryList");
            if (response.IsSuccessStatusCode)
            {
                string readmessage = await response.Content.ReadAsStringAsync();
                List<CategoryDTO> result = JsonSerializer.Deserialize<List<CategoryDTO>>(readmessage, _jsonSerializer);
                return result;
            }
            return null;
        }
        catch (Exception ex)
        {
            var message = ex.Message;
            Debug.WriteLine(message);
            return null;
        }
    }
    public async Task<List<IssuerDTO>> GetIssuersNameList()
    {
        try
        {
            var response = await _Httpclient.GetAsync($"{_Url}/UnifyList/GetIssuerList\r\n");
            if (response.IsSuccessStatusCode)
            {
                string readmessage = await response.Content.ReadAsStringAsync();
                List<IssuerDTO> result = JsonSerializer.Deserialize<List<IssuerDTO>>(readmessage, _jsonSerializer);
                return result;
            }
            return null;
        }
        catch (Exception ex)
        {
            var message = ex.Message;
            Debug.WriteLine(message);
            return null;
        }
    }
    public async Task<List<LocationDTO>> GetLocationList()
    {
        try
        {
            var response = await _Httpclient.GetAsync($"{_Url}/UnifyList/GetLocationList");
            if (response.IsSuccessStatusCode)
            {
                string readmessage = await response.Content.ReadAsStringAsync();
                List<LocationDTO> result = JsonSerializer.Deserialize<List<LocationDTO>>(readmessage, _jsonSerializer);
                return result;
            }
            return null;
        }
        catch (Exception ex)
        {
            var message = ex.Message;
            Debug.WriteLine(message);
            return null;
        }
    }
    public async Task<string> DeleteStatus(int id)
    {
        try
        {
            var response = await _Httpclient.GetAsync($"{_Url}/UnifyList/DeleteStatus/{id}");
            if (response.IsSuccessStatusCode)
            {
                string readmessage = await response.Content.ReadAsStringAsync();
                return readmessage;
            }
            string responsemessage = await response.Content.ReadAsStringAsync();
            return responsemessage;
        }
        catch (Exception ex)
        {
            var message = ex.Message;
            Debug.WriteLine(message);
            return null;
        }
    }
    public async Task<string> DeleteCategory(int id)
    {
        try
        {
            var response = await _Httpclient.GetAsync($"{_Url}/UnifyList/DeleteCategory/{id}");
            if (response.IsSuccessStatusCode)
            {
                string readmessage = await response.Content.ReadAsStringAsync();
                return readmessage;
            }
            string responsemessage = await response.Content.ReadAsStringAsync();
            return responsemessage;
        }
        catch (Exception ex)
        {
            var message = ex.Message;
            Debug.WriteLine(message);
            return null;
        }
    }
    public async Task<string> DeleteIssuers(int id)
    {
        try
        {
            var response = await _Httpclient.GetAsync($"{_Url}/UnifyList/DeleteIssuer/{id}");
            if (response.IsSuccessStatusCode)
            {
                string readmessage = await response.Content.ReadAsStringAsync();
                return readmessage;
            }
            string responsemessage = await response.Content.ReadAsStringAsync();
            return responsemessage;
        }
        catch (Exception ex)
        {
            var message = ex.Message;
            Debug.WriteLine(message);
            return null;
        }
    }
    public async Task<string> DeleteLocation(int id)
    {
        try
        {
            var response = await _Httpclient.GetAsync($"{_Url}/UnifyList/DeleteLocation/{id}");
            if (response.IsSuccessStatusCode)
            {
                string readmessage = await response.Content.ReadAsStringAsync();
                return readmessage;
            }
            string responsemessage = await response.Content.ReadAsStringAsync();
            return responsemessage;
        }
        catch (Exception ex)
        {
            var message = ex.Message;
            Debug.WriteLine(message);
            return null;
        }
    }
    public async Task<List<ReportModel>> GetReportList()
    {
        try
        {
            var response = await _Httpclient.GetAsync($"{_Url}/UnifyList/DisplayReport");
            if (response.IsSuccessStatusCode)
            {
                string readmessage = await response.Content.ReadAsStringAsync();
                List<ReportModel> result = JsonSerializer.Deserialize<List<ReportModel>>(readmessage, _jsonSerializer);
                return result;
            }
            return null;
        }
        catch (Exception ex)
        {
            var message = ex.Message;
            Debug.WriteLine(message);
            return null;
        }
    }

    public async Task<string> AddStatus(string PN)
    {
        try
        {
            var response = await _Httpclient.PostAsync($"{_Url}/Status/AddStatus/{PN}",new StringContent("No Content"));
            if (response.IsSuccessStatusCode)
            {
                string readmessage = await response.Content.ReadAsStringAsync();
                return readmessage;
            }
            string responsemessage = await response.Content.ReadAsStringAsync();
            return responsemessage;
        }
        catch (Exception ex)
        {
            var message = ex.Message;
            Debug.WriteLine(message);
            return null;
        }
    }

    public async Task<string> AddCategory(string PN)
    {
        try
        {
            var response = await _Httpclient.PostAsync($"{_Url}/Category/AddCategory/{PN}", new StringContent("No Content"));
            if (response.IsSuccessStatusCode)
            {
                string readmessage = await response.Content.ReadAsStringAsync();
                return readmessage;
            }
            string responsemessage = await response.Content.ReadAsStringAsync();
            return responsemessage;
        }
        catch (Exception ex)
        {
            var message = ex.Message;
            Debug.WriteLine(message);
            return null;
        }
    }

    public async Task<string> AddLocation(string PN)
    {
        try
        {
            var response = await _Httpclient.PostAsync($"{_Url}/Location/AddLocation/{PN}", new StringContent("No Content"));
            if (response.IsSuccessStatusCode)
            {
                string readmessage = await response.Content.ReadAsStringAsync();
                return readmessage;
            }
            string responsemessage = await response.Content.ReadAsStringAsync();
            return responsemessage;
        }
        catch (Exception ex)
        {
            var message = ex.Message;
            Debug.WriteLine(message);
            return null;
        }
    }

    public async Task<string> AddIssuer(string PN)
    {
        try
        {
            var response = await _Httpclient.PostAsync($"{_Url}/Issuer/AddIssuer/{PN}", new StringContent("No Content"));
            if (response.IsSuccessStatusCode)
            {
                string readmessage = await response.Content.ReadAsStringAsync();
                return readmessage;
            }
            string responsemessage = await response.Content.ReadAsStringAsync();
            return responsemessage;
        }
        catch (Exception ex)
        {
            var message = ex.Message;
            Debug.WriteLine(message);
            return null;
        }
    }
}
