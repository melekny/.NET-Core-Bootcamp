using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace Homework_2.Middlewares
{
    public class AppVersionControlMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _config;
        private enum Time { Earlier, Same, Later };
        // "Time" enum is used to compare versions.

        public AppVersionControlMiddleware(RequestDelegate next, IConfiguration config)
        {
            _next = next;
            _config = config;
        }

        public Task Invoke(HttpContext context)
        {
            // Version information from "appsettings.json" file.
            var defaultVersion = new Version(_config.GetValue<string>("AppVersion"));

            // Version information from Swagger Header's parameter "app-version".
            context.Request.Headers.TryGetValue("app-version", out var versionFromRequest);
            var requestVersion = new Version(versionFromRequest.ToString());

            // Comparison of versions.

            Time versionTime;

            if (requestVersion.CompareTo(defaultVersion) < 0)
            {
                versionTime = Time.Earlier;
            }
            else if (requestVersion.CompareTo(defaultVersion) == 0)
            {
                versionTime = Time.Same;
            }
            else
            {
                versionTime = Time.Later;
            }

            // Continue to work if Request Path doesn't end with "Login" or "Register".
            if (!(context.Request.Path.Value.EndsWith("Login") || context.Request.Path.Value.EndsWith("Register")))
            {
                if (versionTime == Time.Later)
                {
                    // Return an error exception if the version from request is later than the default version.
                    return ErrorException(context, "Eror! Version from Request is later than the default app version.");
                }
            }

            return _next(context);
        }

        private async Task ErrorException(HttpContext context, String errorMessage)
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            await context.Response.WriteAsync(errorMessage);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class AppVersionControlMiddlewareExtensions
    {
        public static IApplicationBuilder UseAppVersionControlMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AppVersionControlMiddleware>();
        }
    }

}

                
   
