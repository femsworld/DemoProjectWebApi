﻿using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace DemoProject;

public class ExceptionMiddleware
{
    private RequestDelegate Next { get;  }

    public ExceptionMiddleware(RequestDelegate next)
    {
        Next = next;
    }

    public async Task Invoke(HttpContext httpContext)
    {
        try
        {
            await Next(httpContext);
        }
        catch (InvalidNameException ex)
        {
            httpContext.Response.ContentType = "application/problen+json";
            httpContext.Response.StatusCode = 400;

            var problemDetails = new ProblemDetails()
            {
                Status = StatusCodes.Status400BadRequest,
                Detail = string.Empty,
                Instance = string.Empty,
                Title = "Name is invalid",
                Type = "Error"
            };

            var problemDetailJson = JsonSerializer.Serialize(problemDetails);
            await httpContext.Response.WriteAsync(problemDetailJson);
        }
        catch (Exception ex) 
        {
            httpContext.Response.ContentType = "application/problen+json";
            httpContext.Response.StatusCode = 500;

            var problemDetails = new ProblemDetails()
            {
                Status = StatusCodes.Status500InternalServerError,
                Detail = ex.Message,
                Instance = string.Empty,
                Title = "Internal Server Error - something went wrong",
                Type = "Error"
            };

            var problemDetailJson = JsonSerializer.Serialize(problemDetails);
            await httpContext.Response.WriteAsync(problemDetailJson);
        }
    }
}
