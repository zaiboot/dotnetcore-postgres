namespace Prizes.Api.Filters
{
    using System;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using Microsoft.Extensions.Logging;

    public class GlobalExceptionFilter : IExceptionFilter, IDisposable
    {
        private readonly ILogger<GlobalExceptionFilter> _logger;

        public GlobalExceptionFilter(ILogger<GlobalExceptionFilter> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public void OnException(ExceptionContext context)
        {

            _logger.LogError(context.Exception, "Global error catched");

            context.Result = new ObjectResult("An error has ocurred")
            {
                StatusCode = 500,
                DeclaredType = typeof(string)
            };

            
        }

        public void Dispose()
        {
            
        }
    }
}
