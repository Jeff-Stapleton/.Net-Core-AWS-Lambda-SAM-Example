using System.Collections.Generic;
using System.Net;

using Amazon.Lambda.Core;
using Amazon.Lambda.APIGatewayEvents;
using Newtonsoft.Json;

using DebuggingExample.Interfaces;
using DebuggingExample.Services;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace DebuggingExample
{
    public class Functions
    {
        private readonly ITimeService _TimeService = new TimeService();
        private readonly IGuidService _GuidService = new GuidService();


        public APIGatewayProxyResponse GetTime(APIGatewayProxyRequest request, ILambdaContext context)
        {
            var result = _TimeService.CurrentTimeUTC();

            {
                var statusCode = (result != null) ? (int)HttpStatusCode.OK : (int)HttpStatusCode.InternalServerError;
                var body = (result != null) ? JsonConvert.SerializeObject(result) : string.Empty;

                var response = new APIGatewayProxyResponse
                {
                    StatusCode = statusCode,
                    Body = body,
                    Headers = new Dictionary<string, string>
                    {
                        { "Content-Type", "application/json" },
                        { "Access-Control-Allow-Origin", "*" }
                    }
                };

                return response;
            }
        }

        public APIGatewayProxyResponse GetGuid(APIGatewayProxyRequest request, ILambdaContext context)
        {
            var result = _GuidService.GenerateGuid();

            {
                var statusCode = (result != null) ? (int)HttpStatusCode.OK : (int)HttpStatusCode.InternalServerError;
                var body = (result != null) ? JsonConvert.SerializeObject(result) : string.Empty;

                var response = new APIGatewayProxyResponse
                {
                    StatusCode = statusCode,
                    Body = body,
                    Headers = new Dictionary<string, string>
                    {
                        { "Content-Type", "application/json" },
                        { "Access-Control-Allow-Origin", "*" }
                    }
                };

                return response;
            }
        }
    }
}