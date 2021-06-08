using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using HiSpaceModels;
using HiSpaceService.Contracts;
using HiSpaceService.Models;
using HiSpaceService.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HiSpaceService.Services;

//test commit
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HiSpaceService.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	//[Produces("application/json")]
	public class InvoiceController : Controller
	{
		private IInvoiceService _invoiceService;

		public InvoiceController(IInvoiceService invoiceService)
		{
			_invoiceService = invoiceService;
		}

		/// <summary>
		/// Get invoice details
		/// </summary>
		/// <param ></param>
		/// <returns></returns>
		/// <returns></returns>
		/// <remarks>
		/// Sample **request**:
		///
		/// POST /api/GetClients
		/// {
		/// "name": "Some name"
		/// }
		///
		/// </remarks>
		/// <response code="200">Returns generated invoice for a booking</response>
		/// <response code="404">Member Booking not found</response>
		// GET: api/Client
		[HttpGet]
		[Route("GetInvoice/{memberBookingSpaceID}")]
		public async Task<ActionResult> GetInvoice(int memberBookingSpaceID)
		{		        
			ServiceResult<Invoice> serviceResult = await _invoiceService.Get(memberBookingSpaceID);
			
			if(serviceResult.IsSuccess)
				return Ok(serviceResult.Result);					
						return NotFound();
		}

		/// <summary>
		/// Get invoice details
		/// </summary>
		/// <param ></param>
		/// <returns></returns>
		/// <returns></returns>
		/// <remarks>
		/// Sample **request**:
		///
		/// POST /api/GetClients
		/// {
		/// "name": "Some name"
		/// }
		///
		/// </remarks>
		/// <response code="200">Saves invoice</response>
		/// <response code="500">Internal server error</response>
		// GET: api/Client
		[HttpPost]
		[Route("GetInvoice/{memberBookingSpaceID}")]
		public async Task<ActionResult> Add(Invoice invoice)
		{
			ServiceResult<Invoice> serviceResult = await _invoiceService.Add(invoice);

			if(serviceResult.IsSuccess)
				return Ok(serviceResult.Result);
					return StatusCode(500);				
		}
    }
}