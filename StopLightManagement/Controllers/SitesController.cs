﻿using System;
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
    public class SitesController : ControllerBase
    {
        private readonly TierMeetingContext _context;

        public SitesController(TierMeetingContext context)
        {
            _context = context;
        }

        // GET: api/Sites
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Site>>> GetSites()
        {
            return await _context.Sites.ToListAsync();
        }

        // GET: api/Sites/5
        [HttpGet("{siteCode}/{organizationID}")]
        public async Task<ActionResult<Site>> GetSite(string siteCode, int organizationID)
        {
            var site = await _context.Sites.FindAsync(siteCode, organizationID);

            if (site == null)
            {
                return NotFound();
            }

            return site;
        }
        // GET: api/Sites/GetSiteMeeting/SiteCode
        [HttpGet("GetSiteMeeting/{siteCode}")]
        public ActionResult<Site> GetSiteMeeting(string siteCode)
        
        {
            var site = _context.Sites
                .Include(site => site.Meetings)
                .Where(site => site.SiteCode == siteCode)
                .FirstOrDefault();

            if (site == null)
            {
                return NotFound();
            }

            return site;
        }
        // PUT: api/Sites/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSite(string id, Site site)
        {
            if (id != site.SiteCode)
            {
                return BadRequest();
            }

            _context.Entry(site).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SiteExists(id))
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

        // POST: api/Sites
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Site>> PostSite(Site site)
        {
            _context.Sites.Add(site);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SiteExists(site.SiteCode))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSite", new { id = site.SiteCode }, site);
        }

        // DELETE: api/Sites/5
        [HttpDelete("{siteCode}/{organizationID:int}")]
        public async Task<ActionResult<Site>> DeleteSite(string siteCode,int organizationID )
        {
            
            var site = await _context.Sites.FindAsync(siteCode, organizationID);


            if (site == null)
            {
                return NotFound();
            }

            _context.Sites.Remove(site);
            await _context.SaveChangesAsync();

            return site;
        }

        private bool SiteExists(string id)
        {
            return _context.Sites.Any(e => e.SiteCode == id);
        }
    }
}
