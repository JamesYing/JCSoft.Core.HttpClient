using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace JCSoft.Core.ApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return $"this is a get request, id is {id}";
        }

        // POST api/values
        [HttpPost]
        public string Post([FromBody] string value)
        {
            return $"this is a post request, value is {value}";
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public string Put(int id, [FromBody] string value)
        {
            return $"this is a put request, id is {id}, value is {value}";
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return $"this is a delete request, id is {id}";
        }
    }
}
