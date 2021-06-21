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

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HiSpaceService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacilityAddOnController : Controller
    {
        private readonly HiSpaceContext _context;

        public FacilityAddOnController(HiSpaceContext context)
        {
            _context = context;
        }
         
        /// <summary>
        /// List Add-Ons
        /// </summary>            
        /// <response code="200">Return true or false</response>
        /// <response code="400">Bad request</response>
        /// <response code="404">Not Found</response>
        [HttpGet]
        [Route("List/{memberBookingSpaceID}")]
        public async Task<ActionResult> List(int? memberBookingSpaceID)
        {
            List<QuantityAddOn> quantityAddOns = null;

            if (memberBookingSpaceID != null && memberBookingSpaceID != 0)
                quantityAddOns = await _context.QuantityAddOns
                                    .Where(n => n.MemberBookingSpaceID == memberBookingSpaceID 
                                            && n.IsActive)
                                    .ToListAsync();
            else
                return BadRequest();

            if (quantityAddOns.Count > 0)
                return Ok(quantityAddOns);

            return NotFound();
        }

        /// <summary>
        /// Add Add-Ons
        /// </summary>            
        /// <response code="200">Return true or false</response>
        /// <response code="500">Internal Server Error</response>
        /// <response code="404">Bad Request</response>
        [HttpPost]
        [Route("Add")]
        public async Task<ActionResult> Add([FromBody] QuantityAddOn quantityAddOn)
        {
            try
            {
                quantityAddOn.CreatedDateTime = DateTime.Now;                
                _context.QuantityAddOns.Add(quantityAddOn);
                int recordsAffected = await _context.SaveChangesAsync();

                if (recordsAffected > 0)
                    return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, quantityAddOn);
            }
            return BadRequest();
        }

        /// <summary>
        /// Delete Add-On
        /// </summary>            
        /// <response code="200">Return true or false</response>
        /// <response code="500">Internal Server Error</response>
        /// <response code="400">Bad Request</response>
        [HttpGet]
        [Route("Delete/{id}")]
        public async Task<ActionResult> Delete(int? id)
        {            
            if(id == null || id == 0)
            return BadRequest();

            using (var trans = _context.Database.BeginTransaction())
			{
				try
				{
					try
					{
                        QuantityAddOn addOn = await _context.QuantityAddOns
                                                    .SingleOrDefaultAsync(n => n.QuantityAddOnID == id);

                        int recordsAffected = 0;
                        if (addOn != null)
                        {
                            addOn.IsActive = false;
                            recordsAffected = await _context.SaveChangesAsync();
                        }                       
                        
                        if (recordsAffected > 0)
                        return Ok(); 
                    }
                    catch (DbUpdateConcurrencyException)
					{
						trans.Rollback();
						return StatusCode(500, id);
					}
                }
                catch(Exception ex)
                {
                    trans.Rollback();
                    return StatusCode(500, id);
                }
            }
                    return BadRequest();        
        }

        /// <summary>
        /// Update Add-On
        /// </summary>            
        /// <response code="200">Return facility Add on</response>
        /// <response code="500">Internal Server Error</response>
        /// <response code="400">Bad Request</response>
        [HttpPut]
        [Route("Update")]
        public async Task<ActionResult> Update([FromBody] QuantityAddOn quantityAddOn)
        {
            if (await Exists(quantityAddOn.QuantityAddOnID))
            {
                using (var trans = _context.Database.BeginTransaction())
                {
                    try
                    {
                        try
                        {
                            int recordsAffected = 0;
                            if (quantityAddOn != null)
                            {
                                quantityAddOn.ModifyDateTime = DateTime.Now;
                                _context.Update(quantityAddOn);
                                recordsAffected = await _context.SaveChangesAsync();
                            }

                            if (recordsAffected > 0)
                                return Ok(quantityAddOn);
                        }
                        catch (DbUpdateConcurrencyException)
                        {
                            trans.Rollback();
                            return StatusCode(500, quantityAddOn);
                        }
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        return StatusCode(500, quantityAddOn);
                    }
                }
            }
            return NotFound(quantityAddOn);
        }

/*         /// <summary>
        /// Add Add-Ons
        /// </summary>            
        /// <response code="200">Return true or false</response>
        /// <response code="400">Unable to process</response>
        [HttpPost]
        [Route("Add")]
        public async Task<ActionResult<bool>> Add([FromBody] List<FacilityAddOn> facilityAddOns)
        {
            bool result = true;

            #region Collect Existing Facility Add-Ons for Requested Spaces

            List<FacilityAddOn> itemsToDelete = new List<FacilityAddOn>();

            if (facilityAddOns.Count > 0)
            {
                using (var _delete = _context.Database.BeginTransaction())
                {
                    foreach (var _bookedFacilityAddOn in _context.FacilityAddons.Where(d => d.MemberBookingSpaceID == facilityAddOns[0].MemberBookingSpaceID))
                        itemsToDelete.Add(_bookedFacilityAddOn);
                }
            }

            #endregion

            using (var trans = _context.Database.BeginTransaction())
            {
                try
                {
                    try
                    {                       
                        //remove existing Facilities                        
                        _context.FacilityAddons.RemoveRange(itemsToDelete);
                        
                        facilityAddOns.ForEach(n => n.CreatedDateTime = DateTime.Now);
                        
                        _context.FacilityAddons.AddRange(facilityAddOns);        
                        await _context.SaveChangesAsync();
                        
                        trans.Commit();
                    }
                    catch (DbUpdateConcurrencyException err)
                    {
                        trans.Rollback();
                        result = false;
                    }
                }
                catch (Exception err)
                {
                    trans.Rollback();
                    result = false;
                }
            }
            return result;
        }*/

        private async Task<bool> Exists(int? id)
        {
            if(id != 0 && id != null)
            {
                QuantityAddOn addOn = await _context.QuantityAddOns
                                            .SingleOrDefaultAsync(n => n.QuantityAddOnID == id);
                
                if (addOn != null) 
                    return true;
            }
            return false;
        }
    }
}