using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebAPI.GlobalExceptionFilter
{
    /// <summary>
    /// This class is used to create response object from handled exception 
    /// </summary>
    public class ErrorResult : IHttpActionResult
    {
        public HttpRequestMessage  Request { get; set; }

        public HttpStatusCode StatusCode { get; set; }

        public string ErrorMessage { get; set; }

        public Task<HttpResponseMessage> ExecuteAsync(System.Threading.CancellationToken cancellationToken)
        {
            var response = Request.CreateResponse(StatusCode, ErrorMessage);
            return Task.FromResult(response);
        }
    }
}
