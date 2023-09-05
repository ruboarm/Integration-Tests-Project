using IntegrationTestsWebApi.Services;
using TestsRespawn.Setup;

namespace TestsRespawn
{
    public class TestsServiceTests : BaseIntegrationTest
    {
        public TestsServiceTests(IntegrationTestWebAppFactory factory)
            : base(factory)
        {
        }

        [Fact]
        public void GetDataFromDatabase()
        {
            // Arrange
            TestsService.AddData("Test");

            // Act
            var existing = DbContext.DbModels.FirstOrDefault(x => x.Name == "Test");
            var result = TestsService.GetData(existing?.Id ?? 0);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void AddDataIntoDatabase()
        {
            // Arrange

            // Act
            var result = TestsService.AddData("Test");

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void DeleteDataFromDatabase()
        {
            // Arrange

            // Act
            var result = TestsService.DeleteData(1);

            // Assert
            Assert.True(result);
        }
    }
}
