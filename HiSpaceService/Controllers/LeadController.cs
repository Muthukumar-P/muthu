using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HiSpaceModels;
using HiSpaceService.Contracts;
using HiSpaceService.Models;
using HiSpaceService.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HiSpaceService.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LeadController : Controller
	{
		private readonly HiSpaceContext _context;

		public LeadController(HiSpaceContext context)
		{
			_context = context;
		}

		/// <summary>
		/// GetLeadsByClientID
		/// </summary>
		/// /// <param>ClientID</param>
		/// <returns>Leads</returns>
		/// <response code="200">Return lead list</response>
		/// <response code="400">Unable to process</response>

		// GET: api/Lead/GetLeadsByClientID/1
		[HttpGet]
		[Route("GetLeadsByClientID/{ClientID}")]
		public async Task<ActionResult<IEnumerable<Lead>>> GetLeadsByClientID(int ClientID)
		{
			return await _context.Leads.Where(d => d.ClientID == ClientID).ToListAsync();
		}

		/// <summary>
		/// GetLead
		/// </summary>
		/// /// <param>ClientID</param>
		/// <returns>Leads</returns>
		/// <response code="200">Return lead list</response>
		/// <response code="400">Unable to process</response>
		// GET: api/Lead/GetLead/1
		[HttpGet("GetLead/{LeadID}")]
		public async Task<ActionResult<Lead>> GetLead(int LeadID)
		{
			var lead = await _context.Leads.FindAsync(LeadID);

			if (lead == null)
			{
				return NotFound();
			}

			return lead;
		}

		/// <summary>
		/// AddLead
		/// </summary>
		/// <response code="200">Return true or false</response>
		/// <response code="400">Unable to process</response>
		// POST: api/Lead/AddLead
		[HttpPost("AddLead")]
		public async Task<ActionResult<Lead>> AddLead([FromBody] Lead lead)
		{
			_context.Leads.Add(lead);
			await _context.SaveChangesAsync();

			return CreatedAtAction("GetLead", new { LeadID = lead.LeadID }, lead);
		}

		/// <summary>
		/// UpdateLead
		/// </summary>
		/// <response code="200">Return true or false</response>
		/// <response code="400">Unable to process</response>
		// POST: api/Lead/UpdateLead
		[HttpPut("UpdateLead/{LeadID}")]
		public async Task<IActionResult> UpdateLead(int LeadID, [FromBody] Lead lead)
		{
			if (LeadID != lead.LeadID || lead == null)
			{
				return BadRequest();
			}

			_context.Entry(lead).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!LeadExists(LeadID))
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

		private bool LeadExists(int LeadID)
		{
			return _context.Leads.Any(e => e.LeadID == LeadID);
		}
	}
}