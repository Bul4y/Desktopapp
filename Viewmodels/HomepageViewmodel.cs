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
        private Thread thread;
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
            thread = new Thread(LoadEquipment);
            thread.Start();
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
        public Axis[] Yaxes { get; set; } =
        {
            new Axis
            {
                LabelsPaint = new SolidColorPaint(SKColors.White),
            }

        };
        public async void DisplayItemList()
        {
            List<HistoryModel> hold = await _Dataservice.GetHistoryLog();
            HistoryLog = hold.Take(10).ToList();
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
        public async void DisplayStatusNameList()
        {
            var statuslist = await _Dataservice.GetStatusCount();
            if(statuslist != null)
            {
                StatusNames = statuslist.Select(x => x.StatusName).ToArray();
                StatusCount = statuslist.Select(x => x.Count).ToArray();

                StatusNameArray = new Axis[]
                {
                new() {
                    Labels = StatusNames,
                    LabelsPaint = new SolidColorPaint(SKColors.White),
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
        private async void LoadEquipment()
        {
            EquipmentList = await _Dataservice.GetItemList();
            var _lastFetchedItemDate = EquipmentList.LastOrDefault().DateCreated;
            while (true)
            {
                List<UniFiedList> newEquipmentList = await _Dataservice.GetItemList();
                if(newEquipmentList != null)
                {
                    UniFiedList latestAddedItem = newEquipmentList.LastOrDefault();

                    if (latestAddedItem != null && latestAddedItem.DateCreated != _lastFetchedItemDate)
                    {
                        EquipmentList.Add(latestAddedItem);

                        _lastFetchedItemDate = latestAddedItem.DateCreated;
                    }
                    Thread.Sleep(1000);
                }
            }
        }
    }
}
