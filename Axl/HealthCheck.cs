using System;
using System.Net;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Extensions.Logging;

namespace Axl
{
    public static class HealthCheck
    {
        private static string _invocationId;

        [FunctionName("HealthCheck")]
        [OpenApiOperation(operationId: "HealthCheck", tags: new[] { "Function health HealthCheck" })]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(string), Description = "Returns JSON response")]
        public static async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "get", Route = "v1/healthCheck")] HttpRequest req, ExecutionContext executionContext, ILogger log)
        {

            _invocationId = executionContext.InvocationId.ToString();

            HealthCheckResponse HealthCheckResponse = new()
            {
                RequestId = _invocationId,
                Application = "Axl Functions",
                StatusCode = 0,
                Message = "Axl HealthCheck Response",
                CreatedDate = DateTimeOffset.UtcNow
            };

            log.LogInformation("HealthCheck request received: {HealthCheckResponse}", HealthCheckResponse);

            await Task.Yield();

            return (ActionResult)new OkObjectResult(HealthCheckResponse);
        }
    }

    public record HealthCheckResponse
    {
        public string RequestId { get; init; }
        public string Application { get; init; }
        public int StatusCode { get; init; }
        public string Message { get; init; }
        public DateTimeOffset CreatedDate { get; init; }
    }

}