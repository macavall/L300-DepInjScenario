using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace DepInjExample
{
    public class Inject1
    {
        private readonly ILogger _logger;
        private Injection1Class injection1Class;

        public Inject1(ILoggerFactory loggerFactory, Injection1Class _injection1Class)
        {
            _logger = loggerFactory.CreateLogger<Inject1>();
            injection1Class = _injection1Class;
        }

        [Function("Inject1")]
        public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            injection1Class.AddMemory(100);

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            response.WriteString("Welcome to Azure Functions!");

            return response;
        }
    }
}
