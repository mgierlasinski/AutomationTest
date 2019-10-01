using AutomationTest.Core.Models;
using AutomationTest.Core.Services;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutomationTest.Core.ViewModels
{
    public class PackageListViewModel : MvxViewModel
    {
        private readonly IPackageService _packageService;
        private readonly IPopupService _popupService;

        private List<PackageItem> _packages;

        public List<PackageItem> Packages
        {
            get => _packages;
            set => SetProperty(ref _packages, value);
        }

        private bool _isListEmpty;

        public bool IsListEmpty
        {
            get => _isListEmpty;
            set => SetProperty(ref _isListEmpty, value);
        }

        public PackageListViewModel(IPackageService packageService, IPopupService popupService)
        {
            _packageService = packageService;
            _popupService = popupService;
        }

        public override Task Initialize()
        {
            IsListEmpty = false;

            try
            {
                Packages = _packageService.GetPackagesForDay(DateTimeOffset.Now).ToList();
            }
            catch (Exception e)
            {
                _popupService.ShowToast($"Error when loading packages: {e.Message}");
            }
            finally
            {
                IsListEmpty = !Packages.Any();
            }

            return Task.CompletedTask;
        }
    }
}
