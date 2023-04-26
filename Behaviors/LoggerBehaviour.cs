using System;
using System.Diagnostics;
using MediatR;

namespace MideiatrPipelinesApi.Behaviors
{
	public class LoggerBehaviour<TRequest, TResponse>: IPipelineBehavior<TRequest, TResponse>	
	{
        private readonly ILogger<LoggerBehaviour<TRequest, TResponse>> _logger;

        public LoggerBehaviour(ILogger<LoggerBehaviour<TRequest, TResponse>> logger)
		{
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var start = Stopwatch.GetTimestamp();
            var result = await next();
            var end = Stopwatch.GetElapsedTime(start);
            _logger.LogInformation($"Elapsed time {end}");
            return result;
        }
    }
}

