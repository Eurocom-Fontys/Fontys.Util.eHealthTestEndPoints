using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using EurocomFontysHealth.Library.Helpers;

namespace EurocomFontysHealth
{
    public static class MedicineDispenserService
    {
        [FunctionName("MedicineDispenserGetAll")]
        public static async Task<IActionResult> GetAll(
             [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "medicinedispenser/")] HttpRequest req,
             ILogger log)
        {
            var res = new DataSource.MedicineDispenserDataSource().GetAll();
            return new OkObjectResult(res);
        }

        [FunctionName("MedicineDispenserGetByID")]
        public static async Task<IActionResult> GetAllGetByID(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "medicinedispenser/{id}/")] HttpRequest req,
            string id,
            ILogger log)
        {
            var guid = GuidHelper.GetFromString(id);
            if (guid == null) { return new BadRequestObjectResult("Invalid GUID"); }
            var res = new DataSource.INRDeviceDataSource().GetByID(guid.Value);
            return res != null ? (IActionResult)new OkObjectResult(res) : (IActionResult)new NotFoundObjectResult("No dispenser device found with ID");
        }
    }
}
