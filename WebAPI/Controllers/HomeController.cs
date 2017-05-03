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
        public async Task<IList<Student>> GetAsync()
        {
            Student student = new Student
            {
                Id = 1,
                Name = "Student1",
                TotalMarks = 120,
                Address = "TestAddress1"
            };
            var response = new List<Student> { student };
            return await Task.FromResult(response);
        }

        // GET api/home/5
        public async Task<Student> GetAsync(int id)
        {
            throw new NotImplementedException("This method is not implemented to test Global Exception Filter");
        }

        // POST api/home
        public async void PostAsync([FromBody]Student student)
        {
            throw new NotImplementedException("This method is not implemented to test Global Exception Filter");
        }

        // PUT api/home/5
        public async void PutAsync(int id, [FromBody]Student student)
        {
            throw new NotImplementedException("This method is not implemented to test Global Exception Filter");
        }

        // DELETE api/home/5
        public async void DeleteAsync(int id)
        {
            throw new NotImplementedException("This method is not implemented to test Global Exception Filter");
        }
    }
}
