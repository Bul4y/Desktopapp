﻿using CapProject.Services.DataService;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ModelsAndDTOs.DTO;

namespace CapProject.Viewmodels
{
    public partial class InvenotorypageViewmodel : ObservableObject
    {
        [ObservableProperty]
        private List<UniFiedList> _dto;

        [ObservableProperty]
        private List<ViewComponentListDTO> _componentList;

        private bool _equipmentSelected;
        public bool EquipmentSelected
        {
            get => _equipmentSelected;
            set
            {
                _equipmentSelected = value;
                OnPropertyChanged(nameof(EquipmentSelected));
                OnPropertyChanged(nameof(ComponentSelected));
            }
        }
        private bool _componentSelected;
        public bool ComponentSelected
        {
            get => _componentSelected;
            set
            {
                _componentSelected = value;
                OnPropertyChanged(nameof(ComponentSelected));
                OnPropertyChanged(nameof(EquipmentSelected));
            }
        }

        public List<UniFiedList> OriginalDto { get; private set; }

        [ObservableProperty]
        private string _searchText;

        private readonly IDataService _Dataservice;

        public InvenotorypageViewmodel(IDataService dataService)
        {
            _Dataservice = dataService;
            DisplayEquipment();

            EquipmentSelected = true;
            ComponentSelected = false;
        }

        [RelayCommand]
        public async Task DisplayEquipment()
        {
            ComponentSelected = false;

            if(ComponentList !=  null)
            {
                ComponentList.Clear();
            }

            OriginalDto = await _Dataservice.GetItemList();
            Dto = OriginalDto;
            EquipmentSelected = true;
            return;

        }

        [RelayCommand]
        public void FilterData()
        {
            if (OriginalDto == null)
            {
                return;
            }

            if (string.IsNullOrWhiteSpace(SearchText))
            {
                Dto = OriginalDto;
                return;
            }
            else
            {
                Dto = OriginalDto.Where(item =>
                  item.PropertyNumber.Contains(SearchText, StringComparison.OrdinalIgnoreCase) ||
                  item.Category.Contains(SearchText, StringComparison.OrdinalIgnoreCase) ||
                  item.Status.Contains(SearchText, StringComparison.OrdinalIgnoreCase) ||
                  item.Location.Contains(SearchText, StringComparison.OrdinalIgnoreCase) ||
                  item.DateCreated.ToString("yyyy-MM-dd").Contains(SearchText, StringComparison.OrdinalIgnoreCase))
                  .ToList();
                   return;
            }
        }

        [RelayCommand]
        public async Task DisplayComponents()
        {
            ComponentSelected = true;
            EquipmentSelected = false;
            if (Dto != null && OriginalDto != null)
            {
                Dto.Clear();
                OriginalDto.Clear();
            }
            ComponentList = await _Dataservice.GetComponentList();
            return;
        }
    }
}
