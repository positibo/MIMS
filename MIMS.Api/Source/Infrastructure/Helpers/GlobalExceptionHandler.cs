using Microsoft.AspNetCore.Diagnostics;
using MIMS.Api.Source.Domain.BusinessRules.Base;
using Newtonsoft.Json;
using System.Net;

namespace MIMS.Api.Source.Infrastructure.Helpers
{
    public class ErrorDetails
    {
        public int statusCode { get; set; }
        public bool isSuccess { get; set; }
        public string message { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public static class GlobalExceptionHandler
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app, ILogger logger)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        string errorJson;
                        if (contextFeature.Error is BusinessRulesException)
                        {
                            var error = (BusinessRulesException)contextFeature.Error;
                            context.Response.StatusCode = (int)error.StatusCode;
                            errorJson = JsonConvert.SerializeObject(new ErrorDetails()
                            {
                                isSuccess = error.IsSuccess,
                                statusCode = (int)error.StatusCode,
                                message = error.Message
                            });
                            await context.Response.WriteAsync(errorJson);
                        }
                        else
                        {
                            errorJson = JsonConvert.SerializeObject(new ErrorDetails()
                            {
                                statusCode = context.Response.StatusCode,
                                message = contextFeature.Error.InnerException.Message
                            });
                            await context.Response.WriteAsync(errorJson);
                        }
                        logger.LogError(errorJson);
                    }
                });
            });
        }
    }
}
