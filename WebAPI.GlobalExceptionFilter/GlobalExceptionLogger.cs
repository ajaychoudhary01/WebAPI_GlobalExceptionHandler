using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.ExceptionHandling;

namespace WebAPI.GlobalExceptionFilter
{
	/// <summary>
    /// This is global exception logger for Web API which will handle logging of all application exceptions
	/// </summary>
    public class GlobalExceptionLogger : IExceptionLogger
    {
        private readonly ILogger logger;

        private readonly bool isLoggingEnabled;
        public GlobalExceptionLogger(ILogger logger, bool isLoggingEnabled)
        {
            this.logger = logger;
            this.isLoggingEnabled = isLoggingEnabled;
        }
        
        /// <summary>
        /// This is customize implementation of default Exception Logger
        /// </summary>
        /// <param name="context"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task LogAsync(ExceptionLoggerContext context, System.Threading.CancellationToken cancellationToken)
        {
            if (isLoggingEnabled)
                logger.LogException(context.Exception);
            return Task.FromResult(0);
        }
    }
}
