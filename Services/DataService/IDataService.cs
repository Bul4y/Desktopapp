using ModelsAndDTOs.DTO;
using ModelsAndDTOs.Models;

namespace CapProject.Services.DataService
{
    public interface IDataService
    {
        public Task<string> Login(LoginDTO login);
        public Task<string> CreateNewAccount(AddUserDTO DTO);
        public Task<int> GetTotalUserCount();
        public Task<int> GetTotalEquipmentCount();
        public Task<int[]> GetByCurrentMonthCountData();
        public Task<ComputerDetailDTO> GetComputerDetail(string PN);
        public Task<List<HistoryModel>> GetHistoryLog();
        public Task<List<StatusCount>> GetStatusCount();
        public Task<List<ViewingComputerDTO>> GetComputerList();
        public Task<List<UniFiedList>> GetItemList();
        public Task<List<ViewUserListDTO>> GetUserList();
        public Task<List<ViewComponentListDTO>> GetComponentList();
        public Task<GetEquipmentListDTO> GetEquipmentByPN(string PN);
        public Task<List<string>> GetstatusList();
        public Task<List<string>> GetCategoryList();
        public Task<List<string>> GetIssuersNameList();
        public Task<List<string>> GetLocationList();
    }
}
