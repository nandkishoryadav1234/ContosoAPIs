using ContosoEventApi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoEventApi.Services
{
    public interface IEvent
    {
        Task<ActionResult<IEnumerable<Event>>> GetEvents();
        Task<ActionResult<Event>> GetEvent(int id);
        Task<bool> PutEvent(int id, Event e);
        Task<bool> PostEvent(Event e);
        Task<bool> DeleteEvent(int id);
       
        bool EventExists(int id);
    }
    public class EventService : IEvent

    {
        private readonly EventContext _context;



        public EventService(EventContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<Event>>> GetEvents()
        {
            return await _context.Events.ToListAsync();
        }

        public async Task<ActionResult<Event>> GetEvent(int id)
        {
            var @event = await _context.Events.FindAsync(id);

            //if (@event == null)
            //{
            //    return NotFound();
            //}

            return @event;
        }

        public async Task<bool> PutEvent(int id, Event @event)
        {
            //if (id != @event.EventId)
            //{
            //    return BadRequest();
            //}

            _context.Entry(@event).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            if (id != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> PostEvent(Event @event)
        {
            _context.Events.Add(@event);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetEvent", new { id = @event.EventId }, @event);
            return true;
        }


        public async Task<bool> DeleteEvent(int id)
        {
            var @event = await _context.Events.FindAsync(id);
            if (@event == null)
            {
                return false;
            }
            else
            {
                _context.Events.Remove(@event);
                await _context.SaveChangesAsync();

                return true;
            }
        }

        public bool EventExists(int id)
        {
            return _context.Events.Any(e => e.EventId == id);
        }
    }
}

