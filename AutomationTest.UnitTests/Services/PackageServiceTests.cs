using AutoFixture.Xunit2;
using AutomationTest.Core.Models;
using AutomationTest.Core.Services;
using AutomationTest.Data.Models;
using AutomationTest.Data.Repositories;
using AutomationTest.UnitTests.Repositories;
using FluentAssertions;
using FluentAssertions.Execution;
using MvvmCross.Tests;
using NSubstitute;
using System;
using System.Linq;
using Xunit;

namespace AutomationTest.UnitTests.Services
{
    public class PackageServiceTests : MvxIoCSupportingTest
    {
        public PackageServiceTests()
        {
            Setup();
        }

        protected override void AdditionalSetup()
        {
            var packageRepository = Substitute.For<IPackageRepository>();
            Ioc.RegisterSingleton(packageRepository);

            Ioc.RegisterType<IMappingService, MappingService>();
        }

        [Theory]
        [AutoData]
        public void AddPackage_ValidData_MapperAndRepositoryInvoked(PackageItem packageItem)
        {
            // Arrange
            var mappingService = Substitute.For<IMappingService>();
            Ioc.RegisterSingleton(mappingService);

            var packageRepository = Ioc.Resolve<IPackageRepository>();
            var packageService = Ioc.IoCConstruct<PackageService>();

            // Act
            packageService.AddPackage(packageItem);

            // Assert
            packageRepository.Received(1).AddPackage(Arg.Any<Package>());
            mappingService.Received(1).MapPackage(packageItem);
        }

        [Fact]
        public void GetPackagesForDay_EmptyRepository_EmptyList()
        {
            // Arrange
            var packageService = Ioc.IoCConstruct<PackageService>();

            // Act
            var result = packageService.GetPackagesForDay(PackageServiceTestsData.TestDate);

            // Assert
            result.Should().BeEmpty();
        }

        [Theory]
        [MemberData(nameof(PackageServiceTestsData.DatesInRange), MemberType = typeof(PackageServiceTestsData))]
        public void GetPackagesForDay_SingleRowInRange_ReturnRow(DateTimeOffset range, DateTimeOffset arg)
        {
            // Arrange
            var entity = new Package
            {
                Barcode = "qwerty",
                Width = 20,
                Height = 15,
                Depth = 30
            };

            var repository = Ioc.Resolve<IPackageRepository>();
            repository.MockRange(range, entity);

            var packageService = Ioc.IoCConstruct<PackageService>();

            // Act
            var result = packageService.GetPackagesForDay(arg).ToList();

            // Assert
            using (new AssertionScope())
            {
                result.Should().HaveCount(1);
                entity.Should().BeEquivalentTo(result[0], options => options.ExcludingMissingMembers());
            }
        }

        [Theory]
        [MemberData(nameof(PackageServiceTestsData.DatesOutOfRange), MemberType = typeof(PackageServiceTestsData))]
        public void GetPackagesForDay_SingleRowOutOfRange_EmptyList(DateTimeOffset range, DateTimeOffset arg)
        {
            // Arrange
            var entity = new Package
            {
                Barcode = "qwerty",
                Width = 20,
                Height = 15,
                Depth = 30
            };

            var repository = Ioc.Resolve<IPackageRepository>();
            repository.MockRange(range, entity);

            var packageService = Ioc.IoCConstruct<PackageService>();

            // Act
            var result = packageService.GetPackagesForDay(arg).ToList();

            // Assert
            result.Should().BeEmpty();
        }
    }
}
