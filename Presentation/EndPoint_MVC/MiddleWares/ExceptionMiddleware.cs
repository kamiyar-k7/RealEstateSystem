
using Application.Exceptions;
using Serilog.Context;
using System.Diagnostics;
using System.Text.Json;

namespace EndPoint_MVC.MiddleWares;


public class ExceptionMiddleware
{

    #region Ctor

    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;

    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }
    #endregion

    public async Task Invoke(HttpContext httpContext)
    {

        var timeSpent = Stopwatch.StartNew();


        try
        {
            await _next(httpContext);

        }
        catch (InternalException ex)
        {
            timeSpent.Stop();

            

            using (LogContext.PushProperty("RequestDurationMs", timeSpent.ElapsedMilliseconds))
            {




                httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                httpContext.Response.ContentType = "application/json";


                var response = new
                {
                    message = ex.Message,
                    RrquestDurationMs = timeSpent,
                    statusCode = 500


                };


                _logger.LogError(ex,
                    "InternalException after {RequestDurationMs} ms",
                    timeSpent.ElapsedMilliseconds);

                var json = JsonSerializer.Serialize(response);
                await httpContext.Response.WriteAsync(json);
            }
        }
    }
}


