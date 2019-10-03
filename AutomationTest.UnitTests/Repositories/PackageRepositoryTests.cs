using AutomationTest.Data.Infrastructure;
using AutomationTest.Data.Models;
using FluentAssertions;
using FluentAssertions.Execution;
using MvvmCross.Tests;
using System;
using Xunit;

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

        //[Fact(Skip = "In-memory Realm randomly crashes test runner after assertion")]
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

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
