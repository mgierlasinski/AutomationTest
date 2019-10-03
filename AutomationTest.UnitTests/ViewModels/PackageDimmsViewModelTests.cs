using AutomationTest.Core.Services;
using AutomationTest.Core.Validation.Rules;
using AutomationTest.Core.ViewModels;
using AutomationTest.UnitTests.Assertions;
using FluentAssertions;
using FluentAssertions.Execution;
using MvvmCross.Tests;
using NSubstitute;
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
    }
}
