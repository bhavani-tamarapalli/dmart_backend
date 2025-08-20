//API Key Authentication

//using Microsoft.AspNetCore.Http;

//using System.Threading.Tasks;

//namespace Dmart_web.Auth

//{

//    public class ApiKeyHandler

//    {

//        private readonly RequestDelegate _next;

//        private const string ApiKeyHeaderName = "XApiKey";

//        private const string ApiKey = "Bhavani@123";


//        public ApiKeyHandler(RequestDelegate next)

//        {

//            _next = next;

//        }

//        public async Task InvokeAsync(HttpContext context)

//        {

//            if (!context.Request.Headers.TryGetValue(ApiKeyHeaderName, out var extractedApiKey))

//            {

//                context.Response.StatusCode = 401; // Unauthorized

//                await context.Response.WriteAsync("API Key is missing");

//                return;

//            }

//            if (!ApiKey.Equals(extractedApiKey))

//            {

//                context.Response.StatusCode = 403; // Forbidden

//                await context.Response.WriteAsync("Invalid API Key");

//                return;

//            }

//            await _next(context); // Call the next middleware

//        }

//    }

//}

