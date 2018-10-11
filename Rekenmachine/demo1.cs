
using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Rekenmachine
{
    public static class SomFunction
    {
        [FunctionName("SomFunction")]
        public static async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "rekenmachine/som/(g1)/(g2)")]HttpRequest req, int g1, int g2, ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            int som = g1 + g2;
            return new OkObjectResult(som);
        }
    }
}
