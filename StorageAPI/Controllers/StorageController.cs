using Microsoft.AspNetCore.Mvc;
using StorageAPI.Models;
using StorageAPI.Services;

namespace StorageAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StorageController : ControllerBase
    {
        private readonly IStorageService storageService;

        public StorageController(IStorageService storageService)
        {
            this.storageService = storageService;
        }

        [HttpPost]
        [Route("/write")]
        public async Task Write(Data data)
        {
            try
            {
                await this.storageService.WriteLogInformation(data);
            }
            catch (Exception ex) 
            {
                throw new Exception($"Exception [{ex.Message}] in StorageController > Write()", ex);
            }
        }
    }
}