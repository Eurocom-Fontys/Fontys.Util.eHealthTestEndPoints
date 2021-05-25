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

namespace EurocomFontysHealth.INR
{
    public static class INRMeasuresService
    {
        [FunctionName("INRGetAll")]
        public static async Task<IActionResult> GetAll(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "inr/")] HttpRequest req,
            ILogger log)
        {
            var res = new INRDeviceDataSource().GetAll();
            return new OkObjectResult(res);
        }

        [FunctionName("INRGetByID")]
        public static async Task<IActionResult> GetByID(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "inr/{id}/")] HttpRequest req,
            string id,
            ILogger log)
        {
            var guid = GuidHelper.GetFromString(id);
            if(guid == null) { return new BadRequestObjectResult("Invalid GUID"); }
            var res = new INRDeviceDataSource().GetByID(guid.Value);
            return res != null ? (IActionResult)new OkObjectResult(res) : (IActionResult)new NotFoundObjectResult("No INR device found with ID");
        }

        [FunctionName("INRGetMeasurementsByDeviceID")]
        public static async Task<IActionResult> GetMeasurementsByDeviceID(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "inr/{deviceID}/measurements/")] HttpRequest req,
            string deviceID,
            ILogger log)
        {
            var deviceIDGuid = GuidHelper.GetFromString(deviceID);
            if (deviceIDGuid == null) { return new BadRequestObjectResult("Invalid device GUID"); }
            var device = new INRDeviceDataSource().GetByID(deviceIDGuid.Value);
            if(device == null) { return new NotFoundObjectResult("Unknown INR device"); }

            var res = new INRMeasurementDataSource().GetFiltered(m => m.DeviceID == deviceIDGuid);
            return new OkObjectResult(res);
        }
    }
}
