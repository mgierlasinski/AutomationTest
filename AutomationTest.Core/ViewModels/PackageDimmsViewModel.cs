using AutomationTest.Core.Models;
using AutomationTest.Core.Services;
using MvvmCross.Commands;
using MvvmCross.ViewModels;
using System;
using System.Threading.Tasks;

namespace AutomationTest.Core.ViewModels
{
    public class PackageDimmsViewModel : MvxViewModel
    {
        private readonly IPackageService _packageService;
        private readonly IPopupService _popupService;

        public IMvxCommand SaveCommand { get; set; }

        public IMvxCommand ResetCommand { get; set; }

        private string _barcode;

        public string Barcode
        {
            get => _barcode;
            set => SetProperty(ref _barcode, value);
        }

        private double _width;

        public double Width
        {
            get => _width;
            set => SetProperty(ref _width, value);
        }

        private double _height;

        public double Height
        {
            get => _height;
            set => SetProperty(ref _height, value);
        }

        private double _depth;

        public double Depth
        {
            get => _depth;
            set => SetProperty(ref _depth, value);
        }

        public PackageDimmsViewModel(IPackageService packageService, IPopupService popupService)
        {
            _packageService = packageService;
            _popupService = popupService;

            SaveCommand = new MvxCommand(SaveAction);
            ResetCommand = new MvxCommand(ResetAction);
        }

        private void SaveAction()
        {
            try
            {
                // TODO: validate

                _packageService.AddPackage(new PackageItem
                {
                    Barcode = Barcode,
                    Width = Width,
                    Height = Height,
                    Depth = Depth,
                    Date = DateTimeOffset.Now
                });

                _popupService.ShowToast("Package saved successfully");
            }
            catch (Exception e)
            {
                _popupService.ShowToast($"Error on save: {e.Message}");
            }
        }

        private void ResetAction()
        {
            Barcode = string.Empty;
            Width = 0;
            Height = 0;
            Depth = 0;
        }
    }
}
