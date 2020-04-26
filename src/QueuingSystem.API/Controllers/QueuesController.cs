using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QueuingSystem.Abstractions.Service;
using QueuingSystem.Models;
using QueuingSystem.Models.DTOs;

namespace QueuingSystem.API.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class QueuesController : ControllerBase
    {
        private IQueuesService _queuesService;
        private readonly IMapper _mapper;
        public QueuesController(IQueuesService queuesService, IMapper mapper)
        {
            _queuesService = queuesService;
            _mapper = mapper;
        }
        public async Task<IActionResult> GetQueues()
        {
            var queues =await  _queuesService.GetItems();
            var queuesDTO = _mapper.Map<IEnumerable<Queues>, IEnumerable<QueuesDTO>>(queues);
            return  Ok(queuesDTO);
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