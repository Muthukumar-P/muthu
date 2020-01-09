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
    public class HolidayController : Controller
    {
        private readonly HiSpaceContext _context;

        public HolidayController(HiSpaceContext context)
        {
            _context = context;
        }

        /// <summary>
        /// GetHolidaysByClientID
        /// </summary>            
        /// <response code="200">Return employee list</response>
        /// <response code="400">Unable to process</response>
        [HttpGet]
        [Route("GetHolidaysByClientID/{ClientID}")]
        public ActionResult<List<HolidayMaster>> GetHolidaysByClientID(int ClientID)
        {
            return _context.Holidays.Where(d => d.ClientID == ClientID).OrderBy(d => d.HolidayDate).ToList();
        }

        /// <summary>
        /// AddEditHoliday
        /// </summary>            
        /// <response code="200">Return true or false</response>
        /// <response code="400">Unable to process</response>
        [HttpPost]
        [Route("AddEditHoliday")]
        public async Task<ActionResult<bool>> AddEditHoliday([FromBody] HolidayMaster holiday)
        {
            bool result = true;
            using (var trans = _context.Database.BeginTransaction())
            {
                try
                {
                    try
                    {
                        if (holiday.HolidayID > 0)
                        {
                            _context.Entry(holiday).State = EntityState.Modified;
                        }
                        else
                        {
                            _context.Holidays.Add(holiday);
                        }
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
        }

        /// <summary>
        /// UploadEmployees
        /// </summary>            
        /// <response code="200">Return true or false</response>
        /// <response code="400">Unable to process</response>
        [HttpPost]
        [Route("UploadHolidayList")]
        public async Task<ActionResult<bool>> UploadHolidayList([FromBody] List<HolidayMaster> holidays)
        {
            bool result = true;
            using (var trans = _context.Database.BeginTransaction())
            {
                try
                {
                    try
                    {
                        foreach (var holi in holidays)
                            _context.Holidays.Add(holi);

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
        }
    }
}
