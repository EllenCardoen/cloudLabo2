
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

//namespace Project1
//{
//    public static class DoelFunction
//    {
//        [FunctionName("DoelFunction")]
//        public static async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "rekenmachine/doel/(g1)/(g2)")]HttpRequest req, int g1, int g2, ILogger log)
//        {
//            try
//            {
//                if (g2 == 0)
//                    return new BadRequestObjectResult("0 niet toegelaten");

//                decimal verschil = g1 / g2;
//                return new OkObjectResult(verschil);
//            } 
//            catch (System.Exception ex)
//            {
//                return new StatusCodeResult(500);
//            }

            
//        }
//    }
//}
