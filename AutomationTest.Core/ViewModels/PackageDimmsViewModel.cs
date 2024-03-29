﻿using AutomationTest.Core.Extensions;
using AutomationTest.Core.Models;
using AutomationTest.Core.Resources;
using AutomationTest.Core.Services;
using AutomationTest.Core.Validation;
using MvvmCross.Commands;
using MvvmCross.ViewModels;
using System;

namespace AutomationTest.Core.ViewModels
{
    public class PackageDimmsViewModel : MvxViewModel
    {
        private readonly IPackageService _packageService;
        private readonly IPopupService _popupService;
        private readonly ValidationGroup _validationGroup;

        public IMvxCommand SaveCommand { get; set; }

        public IMvxCommand ResetCommand { get; set; }

        public ValidatedProperty<string> Barcode { get; set; }

        public ValidatedProperty<string> Width { get; set; }

        public ValidatedProperty<string> Height { get; set; }

        public ValidatedProperty<string> Depth { get; set; }
        
        public PackageDimmsViewModel(IPackageService packageService, IPopupService popupService)
        {
            _packageService = packageService;
            _popupService = popupService;

            SaveCommand = new MvxCommand(SaveAction);
            ResetCommand = new MvxCommand(ResetAction);

            Barcode = new ValidatedProperty<string>().IsRequired();
            Width = new ValidatedProperty<string>().IsRequired().IsDouble();
            Height = new ValidatedProperty<string>().IsRequired().IsDouble();
            Depth = new ValidatedProperty<string>().IsRequired().IsDouble();

            _validationGroup = new ValidationGroup(Barcode, Width, Height, Depth);
        }

        private void SaveAction()
        {
            try
            {
                if (!_validationGroup.Validate())
                    return;

                var package = new PackageItem
                {
                    Barcode = Barcode.Value,
                    Width = Width.Value.ToDouble(),
                    Height = Height.Value.ToDouble(),
                    Depth = Depth.Value.ToDouble(),
                    Date = DateTimeOffset.Now
                };

                _packageService.AddPackage(package);
                _popupService.ShowToast(string.Format(Strings.PackageSaveSuccess, 
                    package.Width, 
                    package.Height, 
                    package.Depth, 
                    package.Barcode));

                ResetAction();
            }
            catch (Exception e)
            {
                _popupService.ShowToast(string.Format(Strings.PackageSaveError, e.Message));
            }
        }

        private void ResetAction()
        {
            Barcode.Value = string.Empty;
            Width.Value = string.Empty;
            Height.Value = string.Empty;
            Depth.Value = string.Empty;
        }
    }
}
