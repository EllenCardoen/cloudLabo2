
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

namespace FirstProjectApp.models
{
    public class SomModel
    {
        public int Getal1 { get; set; }
        public int Getal2 { get; set; }
    }

    public class SomResultaat
    {
        public int Resultaat { get; set; }
    }
}
