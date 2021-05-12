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
    public class KPIsController : ControllerBase
    {
        private readonly TierMeetingContext _context;

        public KPIsController(TierMeetingContext context)
        {
            _context = context;
        }

        // GET: api/KPIs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<KPI>>> GetKPIS()
        {
            return await _context.KPIS.ToListAsync();
        }

        // GET: api/KPIs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<KPI>> GetKPI(int id)
        {
            var kPI = await _context.KPIS.FindAsync(id);

            if (kPI == null)
            {
                return NotFound();
            }

            return kPI;
        }

        // PUT: api/KPIs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKPI(int id, KPI kPI)
        {
            if (id != kPI.ID)
            {
                return BadRequest();
            }

            _context.Entry(kPI).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KPIExists(id))
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

        // POST: api/KPIs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<KPI>> PostKPI(KPI kPI)
        {
            _context.KPIS.Add(kPI);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKPI", new { id = kPI.ID }, kPI);
        }

        // DELETE: api/KPIs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<KPI>> DeleteKPI(int id)
        {
            var kPI = await _context.KPIS.FindAsync(id);
            if (kPI == null)
            {
                return NotFound();
            }

            _context.KPIS.Remove(kPI);
            await _context.SaveChangesAsync();

            return kPI;
        }

        private bool KPIExists(int id)
        {
            return _context.KPIS.Any(e => e.ID == id);
        }
    }
}
