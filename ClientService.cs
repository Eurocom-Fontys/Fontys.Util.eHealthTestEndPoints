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

namespace EurocomFontysHealth
{
    public static class ClientService
    {
        [FunctionName("ClientsGetAll")]
        public static async Task<IActionResult> GetAll(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = "clients/")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("GetAll() called");

            var results = new DataSource.ClientDataSource().GetAll();
            return new OkObjectResult(results);
        }

        [FunctionName("ClientsGetByID")]
        public static async Task<IActionResult> GetByID(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = "clients/{id}/")] HttpRequest req,
            string id,
            ILogger log)
        {
            log.LogInformation("GetSingle() called");

            var guid = GuidHelper.GetFromString(id);
            if(guid == null) { return new BadRequestObjectResult("Invalid guid"); }

            var results = new DataSource.ClientDataSource().GetFiltered(c => c.ID == guid.Value).FirstOrDefault();
            return results != null ? (IActionResult)new OkObjectResult(results) : (IActionResult)new NotFoundObjectResult();
        }
    }
}
