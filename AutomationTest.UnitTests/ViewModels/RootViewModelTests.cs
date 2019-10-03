using AutomationTest.Core.ViewModels;
using MvvmCross.Navigation;
using MvvmCross.Tests;
using NSubstitute;
using Xunit;

namespace AutomationTest.UnitTests.ViewModels
{
    public class RootViewModelTests : MvxIoCSupportingTest
    {
        public RootViewModelTests()
        {
            Setup();
        }

        protected override void AdditionalSetup()
        {
            var navigationService = Substitute.For<IMvxNavigationService>();
            Ioc.RegisterSingleton(navigationService);
        }

        [Fact]
        public void ViewAppeared_MethodInvoked_NavigatedToMenuViewModel()
        {
            // Arrange
            var navigationService = Ioc.Resolve<IMvxNavigationService>();
            var viewModel = Ioc.IoCConstruct<RootViewModel>();

            // Act
            viewModel.ViewAppeared();

            // Assert
            navigationService.Received(1).Navigate<MenuViewModel>();
        }
    }
}
