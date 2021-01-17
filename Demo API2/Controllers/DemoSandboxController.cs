using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo_API2.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo_API2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoSandboxController : ControllerBase
    {
        DemoSandboxService Srv = new DemoSandboxService();

        // GET: api/DemoSandbox
        [HttpGet]
        public IEnumerable<UserDTO> Get()
        {
            return Srv.GetAll();
        }

        // GET: api/DemoSandbox/5
        [HttpGet("{id}", Name = "Get")]
        public UserDTO Get(int id)
        {
            return Srv.GetOneById(id);
        }

        // POST: api/DemoSandbox
        [HttpPost]
        public UserDTO Post([FromBody] UserDTO value)
        {
            return Srv.AddUser(value);
        }

        // PUT: api/DemoSandbox/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public CustomResponse Delete(int id)
        {
            return Srv.DeleteUser(id);
        }
    }
}
