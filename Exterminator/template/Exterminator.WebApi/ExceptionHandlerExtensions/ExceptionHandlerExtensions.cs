using Microsoft.AspNetCore.Builder;

using Microsoft.AspNetCore.Diagnostics;
using Exterminator.Services.Interfaces;
using Exterminator.Models.Exceptions;
using Microsoft.AspNetCore.Http;
using Exterminator.Models;
using System;
using System.Net;

namespace Exterminator.WebApi.ExceptionHandlerExtensions
{
    public static class ExceptionHandlerExtensions
    {
        public static void UseGlobalExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(error => {
                error.Run(async context => {
                    var exceptionHandlerFeature = context.Features.Get<IExceptionHandlerFeature> ();
                    var exception = exceptionHandlerFeature.Error;
                    var statusCode = (int) HttpStatusCode.InternalServerError; 

                    if (exception is ResourceNotFoundException) 
                    {
                        statusCode = (int) HttpStatusCode.NotFound;
                    }
                    else if (exception is ModelFormatException) 
                    {
                        statusCode = (int) HttpStatusCode.PreconditionFailed;
                    } else if (exception is ArgumentOutOfRangeException) 
                    {
                        statusCode = (int) HttpStatusCode.BadRequest;
                    } 
                    context.Response.ContentType = "application/json";
                    context.Response.StatusCode = statusCode;
                    
                    var logService = app.ApplicationServices.GetService(typeof(ILogService)) as ILogService;
                    logService.LogToDatabase(new ExceptionModel{ StatusCode = statusCode, ExceptionMessage = exception.Message, StackTrace = exception.StackTrace});

                    await context.Response.WriteAsync(new ExceptionModel
                    {
                        StatusCode = statusCode,
                        ExceptionMessage = exception.Message,
                        StackTrace = exception.StackTrace
                    }.ToString());
                });
            });
        }
    }
}