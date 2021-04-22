using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StopLightManagement.Context;
using StopLightManagementWebApp.Models;

namespace StopLightManagementWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeetingDepartmentsController : ControllerBase
    {
        private readonly TierMeetingContext _context;

        public MeetingDepartmentsController(TierMeetingContext context)
        {
            _context = context;
        }

        // GET: api/MeetingDepartments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MeetingDepartment>>> GetMeetingDepartments()
        {
            return await _context.MeetingDepartments.ToListAsync();
        }

        // GET: api/MeetingDepartments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MeetingDepartment>> GetMeetingDepartment(int id)
        {
            var meetingDepartment = await _context.MeetingDepartments.FindAsync(id);

            if (meetingDepartment == null)
            {
                return NotFound();
            }

            return meetingDepartment;
        }

        // PUT: api/MeetingDepartments/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMeetingDepartment(int id, MeetingDepartment meetingDepartment)
        {
            if (id != meetingDepartment.MeetingID)
            {
                return BadRequest();
            }

            _context.Entry(meetingDepartment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MeetingDepartmentExists(id))
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

        // POST: api/MeetingDepartments
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MeetingDepartment>> PostMeetingDepartment(MeetingDepartment meetingDepartment)
        {
            _context.MeetingDepartments.Add(meetingDepartment);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MeetingDepartmentExists(meetingDepartment.MeetingID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMeetingDepartment", new { id = meetingDepartment.MeetingID }, meetingDepartment);
        }

        // DELETE: api/MeetingDepartments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MeetingDepartment>> DeleteMeetingDepartment(int id)
        {
            var meetingDepartment = await _context.MeetingDepartments.FindAsync(id);
            if (meetingDepartment == null)
            {
                return NotFound();
            }

            _context.MeetingDepartments.Remove(meetingDepartment);
            await _context.SaveChangesAsync();

            return meetingDepartment;
        }

        private bool MeetingDepartmentExists(int id)
        {
            return _context.MeetingDepartments.Any(e => e.MeetingID == id);
        }
    }
}
