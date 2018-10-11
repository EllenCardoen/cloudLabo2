
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

namespace Project1
{
    public static class History
    {
        [FunctionName("History")]
        public static async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)]HttpRequest req, ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string from = string.Empty;
            string to = string.Empty;

            foreach(var key in req.Query.Keys)
            {
                if (key == "from")
                    from = req.Query["from"];

                if (key == "to")
                    from = req.Query["to"];
            }

            string result = "van" + from + "tot" + to;
            return null;
        }
    }
}
