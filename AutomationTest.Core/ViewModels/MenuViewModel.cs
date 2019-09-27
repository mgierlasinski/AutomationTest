using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace AutomationTest.Core.ViewModels
{
    public class MenuViewModel : MvxViewModel
    {
        public IMvxCommand ShowPackageDimmsCommand { get; set; }

        public IMvxCommand ShowPackageListCommand { get; set; }

        public MenuViewModel(IMvxNavigationService navigationService)
        {
            ShowPackageDimmsCommand = new MvxCommand(() => navigationService.Navigate<PackageDimmsViewModel>());

            ShowPackageListCommand = new MvxCommand(() => navigationService.Navigate<PackageListViewModel>());
        }
    }
}
