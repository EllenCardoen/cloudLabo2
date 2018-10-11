
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
using System.Collections.Generic;
using System.Data.SqlClient;

namespace FirstProjectApp
{
    public static class GetDagen
    {
        [FunctionName("GetDagen")]
        public static async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "days")]HttpRequest req, ILogger log)
        {
            //nieuwe lijst die we dan gaan vullen met die 
            List<string> days = new List<string>();
            string connectionString = Environment.GetEnvironmentVariable("ConnectionString");

            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = connectionString;
                //verbindingen met de database openen
                await connection.OpenAsync();
                using(SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT DISTINCT DagWeek FROM [Registraties]";

                    SqlDataReader reader = await command.ExecuteReaderAsync();

                    while (reader.Read())
                    {
                        string day = reader["DagWeek"].ToString();
                        days.Add(day);
                    }
                }
            }

            return new OkObjectResult(days);

            
        }
    }
}
