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
using System.Linq;

namespace EurocomFontysHealth.MedicineSchema
{
    public static class MedicineSchemaService
    {

        [FunctionName("MedicineSchemaGetAll")]
        public static async Task<IActionResult> GetAllSchemas(
             [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "debug/medicinecalendar/")] HttpRequest req,
             ILogger log)
        {
            log.LogCritical($"Called GetAllSchemas, this is a debug only function!!");    
            return new OkObjectResult(new MedicineSchemaDataSource().GetAll());
        }

        [FunctionName("MedicineSchemaGetForClient")]
        public static async Task<IActionResult> GetMedicineSchemasForClient(
             [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "clients/{clientId}/medicinecalendar/")] HttpRequest req,
             string clientId,
             ILogger log)
        {
            log.LogInformation($"Get med.schema for client: {clientId} called");

            var clientGuid = GuidHelper.GetFromString(clientId);
            if (clientGuid == null) 
            {
                log.LogWarning($"Client {clientId} did not resolve into a valid Guid"); 
                return new BadRequestObjectResult($"Client {clientId} is not a valid clientid"); 
            }

            // Retrieve the schema's for the client, if no schema's return an empty list
            var schemas = new MedicineSchemaDataSource().GetFiltered((m) => m.ClientId == clientGuid);
            log.LogInformation($"Found {schemas.Count()} schemas for client: {clientId}");
            return new OkObjectResult(schemas);
        }

        [FunctionName("MedicineSchemaGetById")]
        public static async Task<IActionResult> GetMedicineSchemaForClient(
             [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "clients/{clientId}/medicinecalendar/{id}")] HttpRequest req,
             string clientId,
             string id,
             ILogger log)
        {
            log.LogInformation($"Get med.schema {id} for client: {clientId} called");

            var schemaGuid = GuidHelper.GetFromString(id);
            var clientGuid = GuidHelper.GetFromString(clientId);

            if(schemaGuid == null || clientGuid == null) 
            {
                log.LogWarning($"Identifiers for client {clientId} and schema {id} are not valid");
                return new BadRequestObjectResult($"Client {clientId} or schema {id} are not valid identifiers"); 
            }

            // Get the schema and check if it was found and if we are requesting it for the correct user
            var schema = new MedicineSchemaDataSource().GetByID(schemaGuid.Value);
            if (schema == null) 
            { 
                log.LogInformation($"Schema {schemaGuid} was not found");
                return new NotFoundObjectResult($"Schema {schemaGuid} was not found"); 
            }

            if(schema.ClientId != clientGuid) 
            {
                log.LogWarning($"The clientID on the schema (client: {schema.ClientId}) differs from the requested ClientID {clientGuid}!");
                return new NotFoundObjectResult($"Schema {schemaGuid} was not found for client {clientGuid}"); 
            }

            // All is well, return the schema
            return new OkObjectResult(schema);
        }
    }

}
