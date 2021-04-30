using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StopLightManagement.Context;
using StopLightManagement.Models;

namespace StopLightManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeetingsController : ControllerBase
    {
        private readonly TierMeetingContext _context;

        public MeetingsController(TierMeetingContext context)
        {
            _context = context;
        }

        // GET: api/Meetings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Meeting>>> GetMeetings()
        {
            return await _context.Meetings.ToListAsync();
        }

        

        private static string GetSitecode(string sitecode)
        {
            return sitecode;
        }

        // GET: api/Meetings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Meeting>> GetMeeting(int id)
        {
            var meeting = await _context.Meetings.FindAsync(id);

            if (meeting == null)
            {
                return NotFound();
            }

            return meeting;
        }

        // PUT: api/Meetings/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMeeting(int id, Meeting meeting)
        {
            if (id != meeting.ID)
            {
                return BadRequest();
            }

            _context.Entry(meeting).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MeetingExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Meetings
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Meeting>> PostMeeting(Meeting meeting)
        {
            _context.Meetings.Add(meeting);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMeeting", new { id = meeting.ID }, meeting);
        }

        // DELETE: api/Meetings/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Meeting>> DeleteMeeting(int id)
        {
            var meeting = await _context.Meetings.FindAsync(id);
            if (meeting == null)
            {
                return NotFound();
            }

            _context.Meetings.Remove(meeting);
            await _context.SaveChangesAsync();

            return meeting;
        }

        private bool MeetingExists(int id)
        {
            return _context.Meetings.Any(e => e.ID == id);
        }
    }
}
