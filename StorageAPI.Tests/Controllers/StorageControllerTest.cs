using Microsoft.Extensions.Options;
using StorageAPI.Controllers;
using StorageAPI.Models;
using StorageAPI.Services;
using Xunit;

namespace StorageAPI.Tests.Controllers
{
    public class StorageControllerTest
    {
        private readonly IOptions<AppParameters> options;

        public StorageControllerTest()
        {
            AppParameters appParameters = new AppParameters();
            options = Options.Create(appParameters);
        }

        [Fact]
        public void Track_Success()
        {
            // Arrange
            var storageService = new StorageService(options);
            var controller = new StorageController(storageService);

            options.Value.LogFileDirectory = "./tmp";
            options.Value.LogFilePath = "./tmp/visitsTesting.log";
            Data data = new Data("https://localhost", "StorageApi.Tests", "127.0.0.1");

            // Act
            var result = controller.Write(data);

            // Assert
            Assert.Null(result.Exception);
        }

        [Fact]
        public void Track_Error()
        {
            // Arrange
            var storageService = new StorageService(options);
            var controller = new StorageController(storageService);

            options.Value.LogFilePath = null;
            Data data = null;

            // Act
            var result = controller.Write(data);

            // Assert
            Assert.NotNull(result.Exception);
        }
    }
}