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
        public Task<List<ReportModel>> GetReportList();
        public Task<List<ViewComponentListDTO>> GetComponentList();
        public Task<GetEquipmentListDTO> GetEquipmentByPN(string PN);
        public Task<string> AddStatus(string PN);
        public Task<string> AddCategory(string PN);
        public Task<string> AddLocation(string PN);
        public Task<string> AddIssuer(string PN);
        public Task<List<StatusDTO>> GetstatusList();
        public Task<string> DeleteStatus(int id);
        public Task<List<CategoryDTO>> GetCategoryList();
        public Task<string> DeleteCategory(int id);
        public Task<List<IssuerDTO>> GetIssuersNameList();
        public Task<string> DeleteIssuers(int id);
        public Task<List<LocationDTO>> GetLocationList();
        public Task<string> DeleteLocation(int id);

    }
}
