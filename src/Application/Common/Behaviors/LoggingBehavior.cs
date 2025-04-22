using System.Diagnostics;
using System.Text.Json;
using Application.Extensions;
using Microsoft.Extensions.Logging;

namespace Application.Common.Behaviors;

public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;

    public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger) =>
        _logger = logger;

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken
    )
    {
        var requestName = typeof(TRequest).Name;
        var stopwatch = Stopwatch.StartNew();

        // Serialize input parameters (optional: customize with a filter for sensitive data)
        var requestJson = JsonSerializer.Serialize(
            request,
            new JsonSerializerOptions
            {
                WriteIndented = false,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            }
        );

        _logger.LogInformation(
            "Handling {RequestName} with parameters: {Request}",
            requestName,
            requestJson
        );

        TResponse response;

        try
        {
            response = await next();
        }
        finally
        {
            stopwatch.Stop();
            _logger.LogInformation(
                "Handled {RequestName} in {ElapsedMilliseconds}ms",
                requestName,
                stopwatch.ElapsedMilliseconds
            );
        }

        return response;
    }
}
//        _logger.LogInformation(
//            "Handling command {CommandName} ({@Command})",
//            request.GetGenericTypeName(),
//            request
//        );
//        var response = await next();
//        _logger.LogInformation(
//            "Command {CommandName} handled - response: {@Response}",
//            request.GetGenericTypeName(),
//            response
//        );

//        return response;
//    }
//}
