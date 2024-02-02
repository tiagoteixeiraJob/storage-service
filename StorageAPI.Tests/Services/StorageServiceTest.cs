using Microsoft.Extensions.Options;
using StorageAPI.Models;
using StorageAPI.Services;
using Xunit;

namespace StorageAPI.Tests.Services
{
    public class StorageServiceTest
    {
        private StorageService storageService;
        private readonly IOptions<AppParameters> options;

        public StorageServiceTest()
        {
            AppParameters appParameters = new AppParameters();
            options = Options.Create(appParameters);
        }

        [Fact]
        public void WriteLogInformation_Success()
        {
            //Arrange
            options.Value.LogFileDirectory = "./tmp";
            options.Value.LogFilePath = "./tmp/visitsTesting.log";
            Data data = new Data("https://localhost", "StorageApi.Tests", "127.0.0.1");

            //Act
            storageService = new StorageService(options);
            var result = storageService.WriteLogInformation(data);

            //Assert
            Assert.Null(result.Exception);
        }

        [Fact]
        public void WriteLogInformation_LogFilePathNull()
        {
            //Arrange
            options.Value.LogFilePath = null;
            Data data = new Data("https://localhost", "StorageApi.Tests", "127.0.0.1");

            //Act
            storageService = new StorageService(options);
            var result = storageService.WriteLogInformation(data);

            //Assert
            Assert.NotNull(result.Exception);
            Assert.Contains("Value cannot be null", result.Exception.Message);
        }

        [Fact]
        public void WriteLogInformation_DataNull()
        {
            //Arrange
            options.Value.LogFileDirectory = "./tmp";
            options.Value.LogFilePath = "./tmp/visitsTesting.log";
            Data data = null;

            //Act
            storageService = new StorageService(options);
            var result = storageService.WriteLogInformation(data);

            //Assert
            Assert.NotNull(result.Exception);
            Assert.Contains("NullReferenceException ", result.Exception.Message);
        }
    }
}