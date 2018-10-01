using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class HomeController : ApiController
    {
        // GET api/home
        public IHttpActionResult GetAsync()
        {
            throw new SystemException("This method is not implemented to test Global Exception Filter");
        }

        // GET api/home/5
        public async Task<IHttpActionResult> GetAsync(string id)
        {
            int parsedValue;
            if (!int.TryParse(id, out parsedValue))
                throw new ArgumentException("invalid input", "id");

            Student student = new Student
            {
                Id = 1,
                Name = "Student1",
                TotalMarks = 120,
                Address = "TestAddress1"
            };
            var value = await Task.FromResult(student);
            return Ok(value);
        }

        // POST api/home
        public void PostAsync([FromBody]Student student)
        {
            throw new SystemException("This method is not implemented to test Global Exception Filter");
        }

        // PUT api/home/5
        public void PutAsync(int id, [FromBody]Student student)
        {
            throw new SystemException("This method is not implemented to test Global Exception Filter");
        }

        // DELETE api/home/5
        public void DeleteAsync(int id)
        {
            throw new ArgumentException("invalid input", "id");
        }
    }
}
