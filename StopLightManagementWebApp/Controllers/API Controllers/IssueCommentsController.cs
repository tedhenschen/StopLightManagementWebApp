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
    public class IssueCommentsController : ControllerBase
    {
        private readonly TierMeetingContext _context;

        public IssueCommentsController(TierMeetingContext context)
        {
            _context = context;
        }

        // GET: api/IssueComments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IssueComment>>> GetIssueComments()
        {
            return await _context.IssueComments.ToListAsync();
        }

        // GET: api/IssueComments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IssueComment>> GetIssueComment(int id)
        {
            var issueComment = await _context.IssueComments.FindAsync(id);

            if (issueComment == null)
            {
                return NotFound();
            }

            return issueComment;
        }

        // PUT: api/IssueComments/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIssueComment(int id, IssueComment issueComment)
        {
            if (id != issueComment.Id)
            {
                return BadRequest();
            }

            _context.Entry(issueComment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IssueCommentExists(id))
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

        // POST: api/IssueComments
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<IssueComment>> PostIssueComment(IssueComment issueComment)
        {
            _context.IssueComments.Add(issueComment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIssueComment", new { id = issueComment.Id }, issueComment);
        }

        // DELETE: api/IssueComments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<IssueComment>> DeleteIssueComment(int id)
        {
            var issueComment = await _context.IssueComments.FindAsync(id);
            if (issueComment == null)
            {
                return NotFound();
            }

            _context.IssueComments.Remove(issueComment);
            await _context.SaveChangesAsync();

            return issueComment;
        }

        private bool IssueCommentExists(int id)
        {
            return _context.IssueComments.Any(e => e.Id == id);
        }
    }
}
