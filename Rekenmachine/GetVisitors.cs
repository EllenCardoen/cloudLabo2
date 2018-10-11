
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
using System.Data.SqlClient;
using System.Collections.Generic;
using FirstProjectApp.models;

namespace FirstProjectApp
{
    public static class GetVisitors
    {
        [FunctionName("GetVisitors")]
        public static async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "visitors/(day)")]HttpRequest req, string day, ILogger log)
        {
            string connectionString = Environment.GetEnvironmentVariable("ConnectionString");
            List<Visitor> visits = new List<Visitor>();

            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = connectionString;
                await connection.OpenAsync();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    //Altijd met parameters werken!! @selectedDay is hier parameter
                    command.CommandText = "SELECT * DagWeek FROM [Registraties] where DagWeek = @selectedDay";
                    command.Parameters.AddWithValue("@selectedDay", day);

                    SqlDataReader reader = await command.ExecuteReaderAsync();
                    while (reader.Read())
                    {
                        Visitor v = new Visitor();
                        v.AantalBezoekers = int.Parse(reader["AantalBezoekers"].ToString());
                        v.TijdstipDag = int.Parse(reader["TijdstipDag"].ToString());
                        v.DagWeek = reader["DagWeek"].ToString();

                        visits.Add(v);

                    }


                }

            }
            return new OkObjectResult(visits);
        }
    }
}
