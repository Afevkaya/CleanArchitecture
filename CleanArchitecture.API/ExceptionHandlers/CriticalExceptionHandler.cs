using CleanArchitecture.Domain.Exceptions;
using Microsoft.AspNetCore.Diagnostics;

namespace CleanArchitecture.API.ExceptionHandlers;

public class CriticalExceptionHandler:IExceptionHandler
{
    public ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        if(exception is CriticalException)
            Console.WriteLine("Kritik bir hata oluştu. Yetkili kişilere bildirilmesi gerekiyor.");
        return ValueTask.FromResult(false);
    }
}