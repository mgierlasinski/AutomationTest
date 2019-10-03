using AutoFixture.Xunit2;
using AutomationTest.Core.Models;
using AutomationTest.Core.Resources;
using AutomationTest.Core.Services;
using AutomationTest.Core.ViewModels;
using FluentAssertions;
using FluentAssertions.Execution;
using MvvmCross.Tests;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using System;
using System.Collections.Generic;
using AutomationTest.UnitTests.Assertions;
using Xunit;

namespace AutomationTest.UnitTests.ViewModels
{
    public class PackageListViewModelTests : MvxIoCSupportingTest
    {
        public PackageListViewModelTests()
        {
            Setup();
        }

        protected override void AdditionalSetup()
        {
            var packageService = Substitute.For<IPackageService>();
            Ioc.RegisterSingleton(packageService);

            var popupService = Substitute.For<IPopupService>();
            Ioc.RegisterSingleton(popupService);
        }

        [Fact]
        public void CreatedInstance_DependenciesProvided_ProperInitialState()
        {
            // Act
            var viewModel = Ioc.IoCConstruct<PackageListViewModel>();

            // Assert
            using (new AssertionScope())
            {
                viewModel.Should().NotBeNull();
                viewModel.PickDateCommand.ShouldBe().Available();
                viewModel.Date.Should().BeCloseTo(DateTimeOffset.Now);
                viewModel.Packages.Should().NotBeNull().And.BeEmpty();
                viewModel.IsLoading.Should().BeFalse();
                viewModel.IsListEmpty.Should().BeFalse();
            }
        }

        [Fact]
        public void ViewAppeared_ServiceReturnedNoData_DisplayNoDataMessage()
        {
            // Arrange
            var viewModel = Ioc.IoCConstruct<PackageListViewModel>();

            // Act
            viewModel.ViewAppeared();

            // Assert
            using (new AssertionScope())
            {
                viewModel.IsLoading.Should().BeFalse();
                viewModel.IsListEmpty.Should().BeTrue();
                viewModel.Packages.Should().BeEmpty();
            }
        }

        [Theory]
        [AutoData]
        public void ViewAppeared_ServiceReturnedData_DisplayListOfPackages(PackageItem package)
        {
            // Arrange
            var packageService = Ioc.Resolve<IPackageService>();

            packageService.GetPackagesForDay(Arg.Any<DateTimeOffset>())
                .Returns(new List<PackageItem> { package });

            var viewModel = Ioc.IoCConstruct<PackageListViewModel>();

            // Act
            viewModel.ViewAppeared();

            // Assert
            using (new AssertionScope())
            {
                viewModel.IsLoading.Should().BeFalse();
                viewModel.IsListEmpty.Should().BeFalse();
                viewModel.Packages.Should().HaveCount(1);
                viewModel.Packages[0].Should().BeEquivalentTo(package);
            }
        }

        [Fact]
        public void ViewAppeared_ServiceThrownException_DisplayErrorAsToast()
        {
            // Arrange
            var popupService = Ioc.Resolve<IPopupService>();
            var packageService = Ioc.Resolve<IPackageService>();
            
            packageService.GetPackagesForDay(Arg.Any<DateTimeOffset>())
                .Throws(new Exception("Ooops"));

            var viewModel = Ioc.IoCConstruct<PackageListViewModel>();

            // Act
            viewModel.ViewAppeared();

            // Assert
            var expectedError = string.Format(Strings.PackagesLoadError, "Ooops");

            using (new AssertionScope())
            {
                viewModel.IsLoading.Should().BeFalse();
                viewModel.IsListEmpty.Should().BeTrue();
                viewModel.Packages.Should().BeEmpty();

                popupService.Received(1).ShowToast(Arg.Is(expectedError));
            }
        }

        [Fact]
        public void ShowDatePickerExecute_CommandInvoked_PopupShownDateUpdated()
        {
            // Arrange
            var viewModel = Ioc.IoCConstruct<PackageListViewModel>();

            var initialDate = viewModel.Date;
            var chosenDate = new DateTimeOffset(2019, 10, 01, 15, 30, 00, TimeSpan.Zero);

            var popupService = Ioc.Resolve<IPopupService>();
            popupService.ShowDatePicker(Arg.Any<DateTimeOffset>()).Returns(chosenDate);

            // Act
            viewModel.PickDateCommand.Execute();

            // Assert
            using (new AssertionScope())
            {
                popupService.Received(1).ShowDatePicker(Arg.Is(initialDate));
                viewModel.Date.Should().Be(chosenDate);
            }
        }
    }
}
