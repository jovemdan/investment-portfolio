using System.Net;
using InvestmentPortfolio.API.Models;
using InvestmentPortfolio.Domain.Models.Exceptions;

namespace InvestmentPortfolio.API.Configurations;

public static class ExceptionHandler
{
    public static async Task DomainExceptionHandleAsync(
        this HttpContext context, DomainException exception, Guid requestId)
    {
        await WriteErrorResponseAsync(context, exception, requestId, 
            "An error occurred in domain validation while processing your request.");
    }

    public static async Task ExceptionHandleAsync(
        this HttpContext context, Exception exception, Guid requestId)
    {
        await WriteErrorResponseAsync(context, exception, requestId, 
            "An unexpected error occurred while processing your request.");
    }

    private static Task WriteErrorResponseAsync(
        HttpContext context, Exception exception, Guid requestId, string contextError)
    {
        var message = CreateMessageError(context, exception);

        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        return context.Response.WriteAsync(new ErrorResponse(
            requestId, 
            context.Response.StatusCode, 
            contextError, 
            message).ToString());
    }

    private static string CreateMessageError(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        return $"Route: {context.Request.Path} - {exception.Message}";
    }
}