using CapProject.Services.DataService;
using CommunityToolkit.Mvvm.ComponentModel;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using ModelsAndDTOs.DTO;
using ModelsAndDTOs.Models;
using SkiaSharp;

namespace CapProject.Viewmodels
{
    public partial class HomepageViewmodel : ObservableObject
    {
        private readonly IDataService _Dataservice;
        private static readonly SKColor s_blue = new(51, 225, 237);
        [ObservableProperty]
        private string _role;
        [ObservableProperty]
        private string _userCount;
        [ObservableProperty]
        private string _equipmentCount;
        [ObservableProperty]
        private string _title;
        [ObservableProperty]
        private List<UniFiedList> _equipmentList;
        [ObservableProperty]
        private List<HistoryModel> _historyLog;
        [ObservableProperty]
        public int[] _datalist;
        [ObservableProperty]
        public int[] _statusCount;
        [ObservableProperty]
        public string[] _statusNames;
        [ObservableProperty]
        public ISeries[] _colser;

        private bool isInternetConnected = false;
        public HomepageViewmodel(IDataService dataService)
        {
            _Dataservice = dataService;
            DisplayItemList();
            DisplayStatusNameList();

        }
        [ObservableProperty]
        public ISeries[] _series;
        [ObservableProperty]
        public Axis[] _statusNameArray;
        public Axis[] XAxis { get; set; } =
        {
            new Axis
            {
                Labels = new []
                {
                    "January",
                    "Febuary",
                    "March",
                    "April",
                    "May",
                    "June",
                    "July",
                    "August",
                    "September",
                    "October",
                    "November",
                    "December",
                },
                LabelsPaint = new SolidColorPaint(SKColors.White),
                TextSize = 12
            }

        };
        public async Task DisplayItemList()
        {
            EquipmentList = await _Dataservice.GetItemList();
            HistoryLog = await _Dataservice.GetHistoryLog();
            var userCount = await _Dataservice.GetTotalUserCount();
            var equipmentCount = await _Dataservice.GetTotalEquipmentCount();



            UserCount = userCount.ToString();
            EquipmentCount = equipmentCount.ToString();

            var data = await _Dataservice.GetByCurrentMonthCountData();

            Datalist = data;


            Series = new ISeries[]
            {
                new LineSeries<int>
                {
                    Values = Datalist,
                    LineSmoothness = 0,
                }
            };

        }
        public async Task DisplayStatusNameList()
        {
            var statuslist = await _Dataservice.GetStatusCount();
            StatusNames = statuslist.Select(x => x.StatusName).ToArray();
            StatusCount = statuslist.Select(x => x.Count).ToArray();

            StatusNameArray = new Axis[]
            {
                new() {
                    Labels = StatusNames,
                }
            };
            Colser = new ISeries[]
            {
                new ColumnSeries<int>
                {
                    Values = StatusCount,
                }
            };
        }

    }
}
