using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Context;

namespace AirbBNB.API.Attributes
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<LoggingMiddleware> _logger;

        public LoggingMiddleware(ILogger<LoggingMiddleware> logger, RequestDelegate next)
        {
            _logger = logger;
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            LogRequest(context);
            
            await _next(context);

            LogResponse(context);
        }

        private async Task LogRequest(HttpContext context)
        {
            var requestBodyStream = context.Request.Body;
            requestBodyStream.Position = 0;
            
            string requestBody = String.Empty;

            using (var sr = new StreamReader(requestBodyStream))
            {
                requestBody = await sr.ReadToEndAsync();
            }

            using (LogContext.PushProperty("Content", requestBody))
                Log.Information("[Request - {path}])", context.Request.Path);
        }
        
        private async Task LogResponse(HttpContext context)
        {
            var responseBodyStream = context.Response.Body;
            responseBodyStream.Position = 0;
            
            string responseBody = String.Empty;

            using (var sr = new StreamReader(responseBodyStream))
            {
                responseBody = await sr.ReadToEndAsync();
            }
            
            using (LogContext.PushProperty("Content", responseBody))
                Log.Information("[Request - {path}])", context.Request.Path);
        }
    }
}