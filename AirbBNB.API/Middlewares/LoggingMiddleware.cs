using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
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
            //Todo
            // Melhorar esse log,
            // Quero um para a requisicao logando as informacoes do request
            // Quero outro para resposta logando as informacoes do response
            
            context.Request?.EnableBuffering();
            var requestReader = new StreamReader(context.Request?.Body);
            var body = await requestReader.ReadToEndAsync();
            context.Request.Body.Position = 0;

            await _next(context);

            using (LogContext.PushProperty("Content", body))
            {
                _logger.LogInformation("Request { method } { url } - StatusCode { statusCode }",
                    context.Request?.Method,
                    context.Request?.Path.Value,
                    context.Response.StatusCode);
            }
        }
    }
}