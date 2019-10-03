using AutomationTest.Core.ViewModels;
using FluentAssertions;
using FluentAssertions.Execution;
using MvvmCross.Navigation;
using MvvmCross.Tests;
using NSubstitute;
using Xunit;

namespace AutomationTest.UnitTests.ViewModels
{
    public class MenuViewModelTests : MvxIoCSupportingTest
    {
        public MenuViewModelTests()
        {
            Setup();
        }

        protected override void AdditionalSetup()
        {
            var navigationService = Substitute.For<IMvxNavigationService>();
            Ioc.RegisterSingleton(navigationService);
        }

        [Fact]
        public void CreateInstance_DependenciesProvided_CreatedWithCommands()
        {
            // Act
            var viewModel = Ioc.IoCConstruct<MenuViewModel>();

            // Assert
            using (new AssertionScope())
            {
                viewModel.Should().NotBeNull();
                viewModel.ShowPackageDimmsCommand.Should().NotBeNull();
                viewModel.ShowPackageDimmsCommand.CanExecute().Should().BeTrue();
                viewModel.ShowPackageListCommand.Should().NotBeNull();
                viewModel.ShowPackageListCommand.CanExecute().Should().BeTrue();
            }
        }

        [Fact]
        public void ShowDimsExecute_CommandInvoked_NavigatedToDimms()
        {
            // Arrange
            var navigationService = Ioc.Resolve<IMvxNavigationService>();
            var viewModel = Ioc.IoCConstruct<MenuViewModel>();

            // Act
            viewModel.ShowPackageDimmsCommand.Execute();

            // Assert
            navigationService.Received(1).Navigate<PackageDimmsViewModel>();
        }

        [Fact]
        public void ShowListExecute_CommandInvoked_NavigatedToList()
        {
            // Arrange
            var navigationService = Ioc.Resolve<IMvxNavigationService>();
            var viewModel = Ioc.IoCConstruct<MenuViewModel>();

            // Act
            viewModel.ShowPackageListCommand.Execute();

            // Assert
            navigationService.Received(1).Navigate<PackageListViewModel>();
        }
    }
}
