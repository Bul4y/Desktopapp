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
        [ObservableProperty]
        private bool _isstatus = true;
        [ObservableProperty]
        private bool _isequipment = false;


        [RelayCommand]
        private void ViewStatus()
        {
            if (!Isstatus)
            {
                Isstatus = true;
                Isequipment = false;
                return;
            }
            if (Isstatus)
            {
                Isstatus = false;
                Isequipment = true;
                return;
            }
        }
        [RelayCommand]
        private void ViewEquipment()
        {
            if (!Isequipment)
            {
                Isstatus = false;
                Isequipment = true;
                return;
            }
            if (Isequipment)
            {
                Isstatus = true;
                Isequipment = false;
                return;
            }
        }
    }
}
