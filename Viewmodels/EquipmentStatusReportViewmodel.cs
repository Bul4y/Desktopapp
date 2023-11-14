using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Desktopapp.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktopapp.Viewmodels
{
    public partial class EquipmentStatusReportViewmodel : ObservableObject
    {
        public EquipmentStatusReportViewmodel()
        {
            
        }

        [RelayCommand]
        private async Task GotoGenerateReport()
        {
            await Shell.Current.GoToAsync(nameof(ReportView));
            return;
        }
    }
}
