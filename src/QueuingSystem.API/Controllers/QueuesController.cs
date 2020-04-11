using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QueuingSystem.Abstractions.Service;

namespace QueuingSystem.API.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class QueuesController : ControllerBase
    {
        private IQueuesService _queuesService;
        public QueuesController(IQueuesService queuesService)
        {
            _queuesService = queuesService;       
        }
        public async Task<IActionResult> GetQueues()
        {
            var queues =await  _queuesService.GetItems();
            return  Ok(queues);
        }

        [HttpGet("{id}")]
        public IActionResult GetQueues([FromRoute] string id)
        {

            return Ok();
        }

        [HttpPost]
        public IActionResult PostQueue([FromBody] Object Obj)
        {

            return Ok();
        }
    }
}