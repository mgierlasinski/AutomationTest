using AutomationTest.Data.Repositories;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System.Threading.Tasks;

namespace AutomationTest.Core.ViewModels
{
    public class RootViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;
        private readonly IPackageRepository _packageRepository;

        public RootViewModel(IMvxNavigationService navigationService, IPackageRepository packageRepository)
        {
            _navigationService = navigationService;
            _packageRepository = packageRepository;
        }

        public override Task Initialize()
        {
            return _packageRepository.InitializeAsync();
        }

        public override void ViewAppeared()
        {
            _navigationService.Navigate<MenuViewModel>();
        }
    }
}
