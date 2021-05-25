using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Linq;
using EurocomFontysHealth.Library.Helpers;

namespace EurocomFontysHealth.Client
{
    public static class ClientService
    {
        [FunctionName("ClientGetAll")]
        public static async Task<IActionResult> GetAll(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "clients/")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("GetAll() called");

            var results = new ClientDataSource().GetAll();
            return new OkObjectResult(results);
        }

        [FunctionName("ClientGetByID")]
        public static async Task<IActionResult> GetByID(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "clients/{id}/")] HttpRequest req,
            string id,
            ILogger log)
        {
            log.LogInformation("GetSingle() called");

            var guid = GuidHelper.GetFromString(id);
            if(guid == null) { return new BadRequestObjectResult("Invalid guid"); }

            var results = new ClientDataSource().GetFiltered(c => c.ID == guid.Value).FirstOrDefault();
            return results != null ? (IActionResult)new OkObjectResult(results) : (IActionResult)new NotFoundObjectResult("No client found with identifier");
        }
    }
}
