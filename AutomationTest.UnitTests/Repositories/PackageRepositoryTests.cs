using AutomationTest.Data.Infrastructure;
using AutomationTest.Data.Models;
using AutomationTest.Data.Resources;
using FluentAssertions;
using FluentAssertions.Execution;
using MvvmCross.Tests;
using System;
using System.Linq;
using Xunit;
using static AutomationTest.UnitTests.Repositories.PackageRepositoryTestsData;

namespace AutomationTest.UnitTests.Repositories
{
    public class PackageRepositoryTests : MvxIoCSupportingTest, IDisposable
    {
        private PackageRepositoryDisposable _repository;

        public PackageRepositoryTests()
        {
            Setup();
        }

        protected override void AdditionalSetup()
        {
            Ioc.RegisterType<IDatabaseProvider, InMemoryDatabaseProvider>();

            _repository = Ioc.IoCConstruct<PackageRepositoryDisposable>();
        }

        [Fact]
        public void AddPackage_ValidData_PackageAddedToDatabase()
        {
            // Arrange
            var package = new Package
            {
                Barcode = "qwerty",
                Width = 20,
                Height = 15,
                Depth = 30
            };

            // Act
            _repository.AddPackage(package);

            // Assert
            using (new AssertionScope())
            {
                package.IsManaged.Should().BeTrue();
                package.Realm.Should().NotBeNull();
            }
        }

        [Fact]
        public void AddPackage_DuplicatedBarcode_ArgumentExceptionThrown()
        {
            // Arrange
            _repository.AddPackage(new Package
            {
                Barcode = "qwerty",
                Width = 20,
                Height = 15,
                Depth = 30
            });

            var duplicated = new Package
            {
                Barcode = "qwerty",
                Width = 30,
                Height = 18,
                Depth = 3.5
            };

            // Act
            Action action = () => _repository.AddPackage(duplicated);

            // Assert
            var expectedMessage = string.Format(ErrorMessages.PackageAlreadyExists, duplicated.Barcode);
            action.Should().Throw<ArgumentException>().WithMessage(expectedMessage);
        }

        [Fact]
        public void GetPackagesForDay_EmptyRepository_EmptyList()
        {
            // Act
            var result = _repository.GetPackagesForRange(TestDate, TestDate);

            // Assert
            result.Should().BeEmpty();
        }

        [Theory]
        [MemberData(nameof(DatesInRange), MemberType = typeof(PackageRepositoryTestsData))]
        public void GetPackagesForDay_SingleRowInRange_ReturnRow(DateTimeOffset from, DateTimeOffset to, DateTimeOffset date)
        {
            // Arrange
            var entity = new Package
            {
                Barcode = "qwerty",
                Width = 20,
                Height = 15,
                Depth = 30,
                Date = date
            };

            _repository.AddPackage(entity);

            // Act
            var result = _repository.GetPackagesForRange(from, to).ToList();

            // Assert
            using (new AssertionScope())
            {
                result.Should().HaveCount(1);
                entity.Should().BeEquivalentTo(result[0], options => options.ExcludingMissingMembers());
            }
        }

        [Theory]
        [MemberData(nameof(DatesOutOfRange), MemberType = typeof(PackageRepositoryTestsData))]
        public void GetPackagesForDay_SingleRowOutOfRange_EmptyList(DateTimeOffset from, DateTimeOffset to, DateTimeOffset date)
        {
            // Arrange
            var entity = new Package
            {
                Barcode = "qwerty",
                Width = 20,
                Height = 15,
                Depth = 30,
                Date = date
            };

            _repository.AddPackage(entity);

            // Act
            var result = _repository.GetPackagesForRange(from, to).ToList();

            // Assert
            result.Should().BeEmpty();
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
