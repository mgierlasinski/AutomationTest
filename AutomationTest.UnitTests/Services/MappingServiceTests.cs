using AutoFixture.Xunit2;
using AutomationTest.Core.Models;
using AutomationTest.Core.Services;
using AutomationTest.Data.Models;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace AutomationTest.UnitTests.Services
{
    public class MappingServiceTests
    {
        [Theory]
        [AutoData]
        public void MapPackage_FromDatabaseEntity_CorrectlyMapped(Package entity)
        {
            // Arrange
            var service = new MappingService();

            // Act
            var packageItem = service.MapPackage(entity);

            // Assert
            using (new AssertionScope())
            {
                packageItem.Should().NotBeNull();
                entity.Should().BeEquivalentTo(packageItem, options => options.ExcludingMissingMembers());
            }
        }

        [Theory]
        [AutoData]
        public void MapPackage_ToDatabaseEntity_CorrectlyMapped(PackageItem packageItem)
        {
            // Arrange
            var service = new MappingService();

            // Act
            var entity = service.MapPackage(packageItem);

            // Assert
            entity.Should().NotBeNull().And.BeEquivalentTo(packageItem);
        }
    }
}
