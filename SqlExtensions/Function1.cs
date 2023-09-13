using System;
using System.Collections.Generic;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.Functions.Worker.Extensions.Sql;
using Microsoft.Extensions.Logging;

namespace SqlExtensions
{
    public class Function1
    {
        private readonly ILogger _logger;

        public Function1(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<Function1>();
        }

        [Function("GetToDos")]
        public IEnumerable<Object> GetToDos(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "GetToDos")] HttpRequestData req,
            [SqlInput("SELECT * FROM [dbo].[ToDo]",
            "SqlConnectionString",
            System.Data.CommandType.Text)] IEnumerable<Object> result)
        {
            _logger.LogInformation("C# HTTP trigger with SQL Input Binding function processed a request.");

            return result;
        }
    }
}
