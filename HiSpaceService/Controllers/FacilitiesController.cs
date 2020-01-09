using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HiSpaceModels;
using HiSpaceService.Models;

namespace HiSpaceService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacilitiesController : ControllerBase
    {
        private readonly HiSpaceContext _context;

        public FacilitiesController(HiSpaceContext context)
        {
            _context = context;
        }

        // GET: api/Facilities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FacilityMaster>>> GetFacilities()
        {
            return await _context.FacilityMasters.ToListAsync();
        }

        // GET: api/Facilities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FacilityMaster>> GetFacility(int id)
        {
            var facility = await _context.FacilityMasters.FindAsync(id);

            if (facility == null)
            {
                return NotFound();
            }

            return facility;
        }

        // PUT: api/Facilities/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFacility(int id, FacilityMaster facility)
        {
            if (id != facility.FacilityID)
            {
                return BadRequest();
            }

            _context.Entry(facility).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FacilityExists(id))
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

        // POST: api/Facilities
        [HttpPost]
        public async Task<ActionResult<FacilityMaster>> PostFacility(FacilityMaster facility)
        {
            _context.FacilityMasters.Add(facility);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFacility", new { id = facility.FacilityID }, facility);
        }

        // DELETE: api/Facilities/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<FacilityMaster>> DeleteFacility(int id)
        {
            var facility = await _context.FacilityMasters.FindAsync(id);
            if (facility == null)
            {
                return NotFound();
            }

            _context.FacilityMasters.Remove(facility);
            await _context.SaveChangesAsync();

            return facility;
        }

        private bool FacilityExists(int id)
        {
            return _context.FacilityMasters.Any(e => e.FacilityID == id);
        }
    }
}
