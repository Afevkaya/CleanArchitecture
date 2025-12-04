using System.Net;
using CleanArchitecture.Application;
using Microsoft.AspNetCore.Diagnostics;

namespace CleanArchitecture.API.ExceptionHandlers;

public class GlobalExceptionHandler:IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        var errorAsDto = ServiceResult.Failed(exception.Message,HttpStatusCode.InternalServerError);
        httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        httpContext.Response.ContentType = "application/json";
        await httpContext.Response.WriteAsJsonAsync(errorAsDto, cancellationToken);
        return true;
    }
}