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

namespace EurocomFontysHealth.MedicineSchema
{
    public static class MedicineSchemaService
    {


        [FunctionName("MedicineSchemaGetForClient")]
        public static async Task<IActionResult> GetMedicineSchemasForClient(
             [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "clients/{clientId}/medicinecalendar/")] HttpRequest req,
             string clientId,
             ILogger log)
        {
            log.LogInformation($"Get med.schema for client: {clientId} called");
            //TODO: Filter on clients
            return new OkObjectResult(new MedicineSchemaDataSource().GetAll());
        }

        [FunctionName("MedicineSchemaGetById")]
        public static async Task<IActionResult> GetMedicineSchemaForClient(
             [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "clients/{clientId}/medicinecalendar/{id}")] HttpRequest req,
             string clientId,
             string id,
             ILogger log)
        {
            var guid = GuidHelper.GetFromString(id);
            log.LogInformation($"Get med.schema {id} for client: {clientId} called");
            //TODO: Validate clientID
            return new OkObjectResult(new MedicineSchemaDataSource().GetByID(guid.Value));
           
        }
    }

}
