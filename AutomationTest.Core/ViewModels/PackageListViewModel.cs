using AutomationTest.Core.Models;
using AutomationTest.Core.Resources;
using AutomationTest.Core.Services;
using MvvmCross.Commands;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AutomationTest.Core.ViewModels
{
    public class PackageListViewModel : MvxViewModel
    {
        private readonly IPackageService _packageService;
        private readonly IPopupService _popupService;

        public IMvxCommand PickDateCommand { get; set; }

        private List<PackageItem> _packages = new List<PackageItem>();

        public List<PackageItem> Packages
        {
            get => _packages;
            set => SetProperty(ref _packages, value);
        }

        private DateTimeOffset _date = DateTimeOffset.Now;

        public DateTimeOffset Date
        {
            get => _date;
            set => SetProperty(ref _date, value, LoadPackages);
        }

        private bool _isListEmpty;

        public bool IsListEmpty
        {
            get => _isListEmpty;
            set => SetProperty(ref _isListEmpty, value);
        }

        private bool _isLoading;

        public bool IsLoading
        {
            get => _isLoading;
            set => SetProperty(ref _isLoading, value);
        }

        public PackageListViewModel(IPackageService packageService, IPopupService popupService)
        {
            _packageService = packageService;
            _popupService = popupService;

            PickDateCommand = new MvxCommand(async () => Date = await _popupService.ShowDatePicker(Date));
        }

        public override void ViewAppeared()
        {
            LoadPackages();
        }

        private void LoadPackages()
        {
            IsLoading = true;
            IsListEmpty = false;

            try
            {
                Packages = _packageService.GetPackagesForDay(Date).ToList();
            }
            catch (Exception e)
            {
                _popupService.ShowToast(string.Format(Strings.PackagesLoadError, e.Message));
            }
            finally
            {
                IsLoading = false;
                IsListEmpty = !Packages.Any();
            }
        }
    }
}
