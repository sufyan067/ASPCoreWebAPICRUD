using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace PatientManagement.Middleware
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestLoggingMiddleware> _logger;

        public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            // BEFORE (Request)
            var method = context.Request.Method;
            var path = context.Request.Path;

            // Call next middleware / controller
            await _next(context);                                                                   // _next(context) = pipeline ka next step

            // AFTER (Response)
            var statusCode = context.Response.StatusCode;

            _logger.LogInformation(
                "[{Time}] {Method} {Path} -> {StatusCode}",
                DateTime.Now,
                method,
                path,
                statusCode
            );
        }
    }
}



//using Microsoft.AspNetCore.Http;
//namespace ASPCoreWebAPICRUD.Middleware
//{
//    public class RequestLoggingMiddleware
//    {
//        private readonly RequestDelegate _next;
//        public RequestLoggingMiddleware(RequestDelegate next)
//        {
//            _next = next;
//        }
//        public async Task Invoke(HttpContext context)
//        {
//            //  BEFORE (Request)
//            Console.WriteLine($"Request: {context.Request.Method} {context.Request.Path}");
//            //System.Diagnostics.Debug.WriteLine($"Request: {context.Request.Method} {context.Request.Path}");                //  Console.WriteLine($"Request: {context.Request.Method} {context.Request.Path}");

//            // Call next middleware / controller
//            await _next(context);

//            //  AFTER (Response)
//            Console.WriteLine($"Response Status: {context.Response.StatusCode}");

//            //System.Diagnostics.Debug.WriteLine($"Response: {context.Response.StatusCode}");                                 //  Console.WriteLine($"Response Status: {context.Response.StatusCode}");

//        }
//    }
//}