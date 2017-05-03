using System;
using System.Net;
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
            ErrorResult result = new ErrorResult();
            result.Request = context.Request;
            if (IsBadRequest(context))
            {
                result.StatusCode = HttpStatusCode.BadGateway;
                result.ErrorMessage = "Please Validate Request";
            }
            else
            {
                result.ErrorMessage = "Something Went wrong, please try after some time";
                result.StatusCode = HttpStatusCode.InternalServerError;
            }
            context.Result = result;
            return Task.FromResult(0);                
        }

        /// <summary>
        /// This method will check exception type
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private bool IsBadRequest(ExceptionHandlerContext context)
        {
            return context.Exception is ArgumentException || context.Exception is ArgumentNullException;
        }
    }
}
