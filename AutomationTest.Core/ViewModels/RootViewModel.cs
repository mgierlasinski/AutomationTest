using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace AutomationTest.Core.ViewModels
{
    public class RootViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;

        public RootViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public override void ViewAppeared()
        {
            _navigationService.Navigate<MenuViewModel>();
        }
    }
}
