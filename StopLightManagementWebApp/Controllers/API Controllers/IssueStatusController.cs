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
    public class IssueStatusController : ControllerBase
    {
        private readonly TierMeetingContext _context;

        public IssueStatusController(TierMeetingContext context)
        {
            _context = context;
        }

        // GET: api/IssueStatus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IssueStatus>>> GetIssueStatus()
        {
            return await _context.IssueStatus.ToListAsync();
        }

        // GET: api/IssueStatus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IssueStatus>> GetIssueStatus(int id)
        {
            var issueStatus = await _context.IssueStatus.FindAsync(id);

            if (issueStatus == null)
            {
                return NotFound();
            }

            return issueStatus;
        }

        // PUT: api/IssueStatus/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIssueStatus(int id, IssueStatus issueStatus)
        {
            if (id != issueStatus.Id)
            {
                return BadRequest();
            }

            _context.Entry(issueStatus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IssueStatusExists(id))
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

        // POST: api/IssueStatus
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<IssueStatus>> PostIssueStatus(IssueStatus issueStatus)
        {
            _context.IssueStatus.Add(issueStatus);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIssueStatus", new { id = issueStatus.Id }, issueStatus);
        }

        // DELETE: api/IssueStatus/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<IssueStatus>> DeleteIssueStatus(int id)
        {
            var issueStatus = await _context.IssueStatus.FindAsync(id);
            if (issueStatus == null)
            {
                return NotFound();
            }

            _context.IssueStatus.Remove(issueStatus);
            await _context.SaveChangesAsync();

            return issueStatus;
        }

        private bool IssueStatusExists(int id)
        {
            return _context.IssueStatus.Any(e => e.Id == id);
        }
    }
}
