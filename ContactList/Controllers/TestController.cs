using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using ContactList.Models;
using Swashbuckle.Swagger.Annotations;

namespace ContactList.Controllers
{
    public class TestController : ApiController
    {
        private async Task<IEnumerable<TestStuff>> GetTestStuff()
        {
            List<TestStuff> testData = new List<TestStuff>();
            testData.Add(new TestStuff {Id = 1, TestData = "Test1"});
            testData.Add(new TestStuff { Id = 2, TestData = "Test2" });

            return testData;
        }

        [HttpGet]
        [SwaggerResponse(HttpStatusCode.OK,
            Description = "OK",
            Type = typeof(IEnumerable<TestStuff>))]
        [SwaggerResponse(HttpStatusCode.NotFound,
            Description = "Contact not found",
            Type = typeof(IEnumerable<TestStuff>))]
        [SwaggerOperation("GetTestStuffById")]
        [Route("~/test/{id}")]
        public async Task<TestStuff> Get([FromUri] int id)
        {
            var contacts = await GetTestStuff();
            return contacts.FirstOrDefault(x => x.Id == id);
        }
    }
}
