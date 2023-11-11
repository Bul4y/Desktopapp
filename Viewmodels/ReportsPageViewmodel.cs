using CapProject.Services.DataService;
using CommunityToolkit.Mvvm.ComponentModel;
using ModelsAndDTOs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktopapp.Viewmodels
{
    public partial class ReportsPageViewmodel : ObservableObject
    {
        private readonly IDataService _Dataservice;
        [ObservableProperty]
        private List<ReportModel> _reportList;
        [ObservableProperty]
        private List<HistoryModel> _historyList;
        public ReportsPageViewmodel(IDataService dataservice)
        {
            _Dataservice = dataservice;
            Load();
        }

        async void Load()
        {
            ReportList = await _Dataservice.GetReportList();
            HistoryList = await _Dataservice.GetHistoryLog();
        }
    }
}
