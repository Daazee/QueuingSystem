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
            var queues = await _queuesService.GetItems();
            var queuesDTO = _mapper.Map<IEnumerable<Queues>, IEnumerable<QueuesDTO>>(queues);
            return Ok(queuesDTO);
        }

        [HttpGet("{id}")]
        public IActionResult GetQueues([FromRoute] string id)
        {

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> PostQueue([FromBody] QueuesDTO queuesDTO)
        {
            if (ModelState.IsValid)
            {
                queuesDTO.QueueId = Guid.NewGuid();
                var queue = _mapper.Map<QueuesDTO, Queues>(queuesDTO);
                var savedQueue = await _queuesService.AddItem(queue);
                queuesDTO = _mapper.Map<Queues, QueuesDTO>(savedQueue);
                return Ok(queuesDTO);
            }
            return BadRequest();
        }

        [HttpPatch]
        public async Task<IActionResult> SetQueueStaus([FromQuery]string id, [FromBody] QueuesDTO queuesDTO)
        {
            if (ModelState.IsValid && !string.IsNullOrEmpty(id))
            {
                queuesDTO.QueueId = Guid.Parse(id);
                var queue = _mapper.Map<QueuesDTO, Queues>(queuesDTO);
                var savedQueue = await _queuesService.UpdateItem(queue);
                queuesDTO = _mapper.Map<Queues, QueuesDTO>(savedQueue);
                return Ok(queuesDTO);
            }
            return BadRequest();
        }

        [HttpGet("GetTodaysQueuesBySatus")]
        public async Task<IActionResult> GetTodaysQueuesBySatus([FromQuery] int status)
        {
            if (ModelState.IsValid)
            {
                var queues = await _queuesService.GetTodaysQueuesBySatus(status);
                var queuesDTO = _mapper.Map<IEnumerable<Queues>, IEnumerable<QueuesDTO>>(queues);
                return Ok(queuesDTO);
            }
            return BadRequest();
        }

        [HttpGet("GetQueuesBySatus")]
        public async Task<IActionResult> GetQueuesBySatus([FromQuery] int status)
        {
            if (ModelState.IsValid)
            {
                var queues = await _queuesService.GetQueuesBySatus(status);
                var queuesDTO = _mapper.Map<IEnumerable<Queues>, IEnumerable<QueuesDTO>>(queues);
                return Ok(queuesDTO);
            }
            return BadRequest();
        }
    }
}