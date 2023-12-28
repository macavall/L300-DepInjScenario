# First Wiki

``` csharp
        [Function("collect")]
        public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            GC.Collect();

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            response.WriteString("Welcome to Azure Functions!");

            return response;
        }
```

# Resources

[Overview](https://learn.microsoft.com/en-us/dotnet/core/extensions/dependency-injection#service-registration-methods])