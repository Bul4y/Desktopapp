using ModelsAndDTOs.DTO;
using ModelsAndDTOs.Models;
using System.Diagnostics;
using System.Text;
using System.Text.Json;
using ThreadNetwork;

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

    public async Task<List<string>> GetstatusList()
    {
        try
        {
            var response = await _Httpclient.GetAsync($"{_Url}/Status/GetStatusList");
            if (response.IsSuccessStatusCode)
            {
                string readmessage = await response.Content.ReadAsStringAsync();
                List<string> result = JsonSerializer.Deserialize<List<string>>(readmessage, _jsonSerializer);
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
    public async Task<List<string>> GetCategoryList()
    {
        try
        {
            var response = await _Httpclient.GetAsync($"{_Url}/Category/GetCategory");
            if (response.IsSuccessStatusCode)
            {
                string readmessage = await response.Content.ReadAsStringAsync();
                List<string> result = JsonSerializer.Deserialize<List<string>>(readmessage, _jsonSerializer);
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
    public async Task<List<string>> GetIssuersNameList()
    {
        try
        {
            var response = await _Httpclient.GetAsync($"{_Url}/Issuer/GetIssuer");
            if (response.IsSuccessStatusCode)
            {
                string readmessage = await response.Content.ReadAsStringAsync();
                List<string> result = JsonSerializer.Deserialize<List<string>>(readmessage, _jsonSerializer);
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
    public async Task<List<string>> GetLocationList()
    {
        try
        {
            var response = await _Httpclient.GetAsync($"{_Url}/Location/GetLocationList");
            if (response.IsSuccessStatusCode)
            {
                string readmessage = await response.Content.ReadAsStringAsync();
                List<string> result = JsonSerializer.Deserialize<List<string>>(readmessage, _jsonSerializer);
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
}
