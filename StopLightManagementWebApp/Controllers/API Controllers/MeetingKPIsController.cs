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
    public class MeetingKPIsController : ControllerBase
    {
        private readonly TierMeetingContext _context;

        public MeetingKPIsController(TierMeetingContext context)
        {
            _context = context;
        }

        // GET: api/MeetingKPIs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MeetingKPI>>> GetMeetingKPI()
        {
            return await _context.MeetingKPI.ToListAsync();
        }

        // GET: api/MeetingKPIs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MeetingKPI>> GetMeetingKPI(int id)
        {
            var meetingKPI = await _context.MeetingKPI.FindAsync(id);

            if (meetingKPI == null)
            {
                return NotFound();
            }

            return meetingKPI;
        }

        // PUT: api/MeetingKPIs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMeetingKPI(int id, MeetingKPI meetingKPI)
        {
            if (id != meetingKPI.MeetingID)
            {
                return BadRequest();
            }

            _context.Entry(meetingKPI).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MeetingKPIExists(id))
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

        // POST: api/MeetingKPIs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MeetingKPI>> PostMeetingKPI(MeetingKPI meetingKPI)
        {
            _context.MeetingKPI.Add(meetingKPI);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MeetingKPIExists(meetingKPI.MeetingID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMeetingKPI", new { id = meetingKPI.MeetingID }, meetingKPI);
        }

        // DELETE: api/MeetingKPIs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MeetingKPI>> DeleteMeetingKPI(int id)
        {
            var meetingKPI = await _context.MeetingKPI.FindAsync(id);
            if (meetingKPI == null)
            {
                return NotFound();
            }

            _context.MeetingKPI.Remove(meetingKPI);
            await _context.SaveChangesAsync();

            return meetingKPI;
        }

        private bool MeetingKPIExists(int id)
        {
            return _context.MeetingKPI.Any(e => e.MeetingID == id);
        }
    }
}
