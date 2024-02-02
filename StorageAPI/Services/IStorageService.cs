using StorageAPI.Models;

namespace StorageAPI.Services
{
    public interface IStorageService
    {
        Task WriteLogInformation(Data data);
    }
}