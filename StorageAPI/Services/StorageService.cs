using Microsoft.Extensions.Options;
using StorageAPI.Models;
using System.Globalization;

namespace StorageAPI.Services
{
    public class StorageService : IStorageService
    {
        private readonly IOptions<AppParameters> appParameters;

        public StorageService(IOptions<AppParameters> appParameters)
        {
            this.appParameters = appParameters;
        }

        public async Task WriteLogInformation(Data data)
        {
            try
            {
                string logFileDirectory = appParameters.Value.LogFileDirectory;
                string logFilePath = appParameters.Value.LogFilePath;

                if (!Directory.Exists(logFileDirectory))
                    Directory.CreateDirectory(logFileDirectory);

                if (Directory.Exists(logFileDirectory) && logFilePath != null)
                {
                    string dateUtcFormat = DateTime.UtcNow.ToString("o", CultureInfo.InvariantCulture);

                    string referer = String.IsNullOrEmpty(data.Referrer) ? "null" : data.Referrer;
                    string userAgent = String.IsNullOrEmpty(data.UserAgent) ? "null" : data.UserAgent;
                    string ipAddress = String.IsNullOrEmpty(data.IpAddress) ? "null" : data.IpAddress;

                    using (StreamWriter outputFile = new StreamWriter(Path.Combine(logFilePath), true))
                    {
                        outputFile.WriteLine($"{dateUtcFormat}|{referer}|{userAgent}|{ipAddress}");
                    }
                }
            }
            catch (NullReferenceException ex)
            {
                throw new Exception($"NullReferenceException [{ex.Message}] in StorageService > WriteLogInformation()", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"Exception [{ex.Message}] in StorageService > WriteLogInformation() method", ex);
            }
        }
    }
}