using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace CustService.Middleware
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<LoggingMiddleware> _logger;

        public LoggingMiddleware(RequestDelegate next, ILogger<LoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                // Log request
                _logger.LogInformation(FormatRequest(context.Request));

                await _next(context);

                // Log response
                _logger.LogInformation(FormatResponse(context.Response.StatusCode));

            }
            catch (Exception ex)
            {
                // Log error
                // _logger.LogError(ex, ex.Message);

                //allows exception handling middleware to deal with things
                throw;
            }

        }

        private static string FormatRequest(HttpRequest request)
        {
            var messageObjToLog = new { scheme = request.Scheme, host = request.Host, path = request.Path, queryString = request.Query };

            return JsonConvert.SerializeObject(messageObjToLog);
        }

        private static string FormatResponse(int statusCode)
        {
            var messageObjectToLog = new { statusCode = statusCode };

            return JsonConvert.SerializeObject(messageObjectToLog);
        }
    }

}
