using AutomationTest.Core.Models;
using AutomationTest.Core.Resources;
using AutomationTest.Core.Services;
using AutomationTest.Core.Validation.Rules;
using AutomationTest.Core.ViewModels;
using AutomationTest.UnitTests.Assertions;
using FluentAssertions;
using FluentAssertions.Execution;
using MvvmCross.Tests;
using NSubstitute;
using System;
using Xunit;

namespace AutomationTest.UnitTests.ViewModels
{
    public class PackageDimmsViewModelTests : MvxIoCSupportingTest
    {
        public PackageDimmsViewModelTests()
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
            var viewModel = Ioc.IoCConstruct<PackageDimmsViewModel>();

            // Assert
            using (new AssertionScope())
            {
                viewModel.Should().NotBeNull();
                viewModel.SaveCommand.ShouldBe().Available();
                viewModel.ResetCommand.ShouldBe().Available();
                viewModel.Barcode.ShouldBe().Empty();
                viewModel.Width.ShouldBe().Empty();
                viewModel.Height.ShouldBe().Empty();
                viewModel.Depth.ShouldBe().Empty();

                viewModel.Barcode.Rules.Should().ContainSingle(x => x is IsRequiredRule);

                viewModel.Width.Rules.Should()
                    .ContainSingle(x => x is IsRequiredRule).And
                    .ContainSingle(x => x is IsDoubleRule);

                viewModel.Height.Rules.Should()
                    .ContainSingle(x => x is IsRequiredRule).And
                    .ContainSingle(x => x is IsDoubleRule);

                viewModel.Depth.Rules.Should()
                    .ContainSingle(x => x is IsRequiredRule).And
                    .ContainSingle(x => x is IsDoubleRule);
            }
        }

        [Fact]
        public void ResetCommand_CommandExecuted_FormFieldsEmpty()
        {
            // Arrange
            var viewModel = Ioc.IoCConstruct<PackageDimmsViewModel>();
            InitializeViewModelWithValues(viewModel);

            // Act
            viewModel.ResetCommand.Execute();

            // Assert
            AssertFormIsEmpty(viewModel);
        }

        [Fact]
        public void SaveCommand_CommandExecuted_PackedSaveFormFieldsEmpty()
        {
            // Arrange
            var packageService = Ioc.Resolve<IPackageService>();
            var popupService = Ioc.Resolve<IPopupService>();

            var viewModel = Ioc.IoCConstruct<PackageDimmsViewModel>();
            InitializeViewModelWithValues(viewModel);

            // Act
            viewModel.SaveCommand.Execute();

            // Assert
            var expectedMessage = string.Format(Strings.PackageSaveSuccess, 5, 16, 3.5, "123qwerty");
            popupService.Received(1).ShowToast(Arg.Is(expectedMessage));
            packageService.Received(1).AddPackage(Arg.Is<PackageItem>(x => x.Barcode == "123qwerty"));

            AssertFormIsEmpty(viewModel);
        }

        [Fact]
        public void SaveCommand_ServiceThrownException_DisplayErrorAsToast()
        {
            // Arrange
            var popupService = Ioc.Resolve<IPopupService>();

            var packageService = Ioc.Resolve<IPackageService>();
            packageService.When(x => x.AddPackage(Arg.Any<PackageItem>()))
                .Do(x => throw new Exception("Ooops"));

            var viewModel = Ioc.IoCConstruct<PackageDimmsViewModel>();
            InitializeViewModelWithValues(viewModel);

            // Act
            viewModel.SaveCommand.Execute();

            // Assert
            var expectedError = string.Format(Strings.PackageSaveError, "Ooops");
            popupService.Received(1).ShowToast(Arg.Is(expectedError));
        }

        // TODO: test validation failed

        private void InitializeViewModelWithValues(PackageDimmsViewModel viewModel)
        {
            viewModel.Barcode.Value = "123qwerty";
            viewModel.Width.Value = "5";
            viewModel.Height.Value = "16";
            viewModel.Depth.Value = "3.5";
        }

        private void AssertFormIsEmpty(PackageDimmsViewModel viewModel)
        {
            using (new AssertionScope())
            {
                viewModel.Barcode.Value.Should().BeEmpty();
                viewModel.Width.Value.Should().BeEmpty();
                viewModel.Height.Value.Should().BeEmpty();
                viewModel.Depth.Value.Should().BeEmpty();
            }
        }
    }
}
