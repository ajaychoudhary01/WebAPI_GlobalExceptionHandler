using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebAPI.GlobalExceptionFilter
{
    /// <summary>
    /// This class is used to create response object from handled exception 
    /// </summary>
    public class HttpErrorResponseResult : IHttpActionResult
    {
        private readonly HttpRequestMessage request;

        private readonly HttpStatusCode statusCode;

        private readonly string message;

        public HttpErrorResponseResult(HttpRequestMessage request, HttpStatusCode statusCode, string message)
        {
            this.request = request;
            this.statusCode = statusCode;
            this.message = message;
        }

        public Task<HttpResponseMessage> ExecuteAsync(System.Threading.CancellationToken cancellationToken)
        {
            var response = request.CreateErrorResponse(statusCode, message);
            return Task.FromResult(response);
        }
    }
}
