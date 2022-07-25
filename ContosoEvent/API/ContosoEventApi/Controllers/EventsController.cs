using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ContosoEventApi.Model;
using ContosoEventApi.Services;

namespace ContosoEventApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IEvent _context;



        public EventsController(IEvent context)
        {
            _context = context;
        }

        // GET: api/Events
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Event>>> GetEvents()
        {
            return await _context.GetEvents();
        }

        // GET: api/Events/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Event>> GetEvent(int id)
        {
            var @event = await _context.GetEvent(id);

            if (@event == null)
            {
                return NotFound();
            }
            else
            {
                return @event;
            }
            
        }

        // PUT: api/Events/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvent(int id, Event @event)
        {
            if (id != @event.EventId)
            {
                return BadRequest();
            }

            else
            {


                bool res = await _context.PutEvent(id, @event);
                if (res)
                {

                    return NoContent();
                }
                else
                {

                    return BadRequest();
                }

            }

    }
    // POST: api/Events
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
        public async Task<ActionResult<Event>> PostEvent(Event @event)
        {
            bool res = await _context.PostEvent(@event);

            
           if (res)
            {
                return CreatedAtAction("GetEvent", new { id = @event.EventId }, @event);
            }
            else
            {
                return BadRequest();
            }


        }

        // DELETE: api/Events/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            
            if (id == 0)
            {
               
                return NotFound();
            }
            else
            {
                bool res = await _context.DeleteEvent(id);
                if (res)
                {
                    return NoContent();
                }
                else
                {
                    return BadRequest();
                }
            }


        }

        private bool EventExists(int id)
        {
            return _context.EventExists(id);
        }
    }
}
