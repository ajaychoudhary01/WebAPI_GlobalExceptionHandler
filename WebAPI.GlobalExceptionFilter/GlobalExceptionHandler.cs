using System;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.ExceptionHandling;

namespace WebAPI.GlobalExceptionFilter
{
    /// <summary>
    /// This is global exception filter for Web API which will handle all exeptions in the application and generate response 
    /// </summary>
    public class GlobalExceptionHandler : IExceptionHandler
    {
        /// <summary>
        /// This is customize implementation of Exception Handler
        /// </summary>
        /// <param name="context"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task HandleAsync(ExceptionHandlerContext context, System.Threading.CancellationToken cancellationToken)
        {            
            HttpStatusCode statusCode;
            var exception = context.Exception;
            var isClientMistake = IsClientMistake(exception, out statusCode);
            string message = isClientMistake ? exception.Message : HttpStatusCode.InternalServerError.ToString();
            HttpErrorResponseResult result = new HttpErrorResponseResult(context.Request, statusCode, message);
            context.Result = result;
            return Task.FromResult(0);                
        }

        /// <summary>
        /// This method will check exception type
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        private bool IsClientMistake(Exception exception, out HttpStatusCode httpStatusCode)
        {
            var isClientMistake = false;
            if(exception is UnauthorizedAccessException)
            {
                httpStatusCode = HttpStatusCode.Unauthorized;
                isClientMistake = true;
            }
            if(exception is ArgumentOutOfRangeException)
            {
                httpStatusCode = HttpStatusCode.NotFound;
                isClientMistake = true;
            }
            else if(exception is ArgumentException  || exception is SerializationException || exception is NotSupportedException
                || exception is HttpRequestException)
            {
                httpStatusCode = HttpStatusCode.BadRequest;
                isClientMistake = true;
            }
            else 
            {
                httpStatusCode = HttpStatusCode.InternalServerError;
            }
            return isClientMistake;
        }
    }
}
