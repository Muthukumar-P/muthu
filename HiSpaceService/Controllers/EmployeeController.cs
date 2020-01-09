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
    public class EmployeeController : Controller
    {
        private readonly HiSpaceContext _context;

        public EmployeeController(HiSpaceContext context)
        {
            _context = context;
        }

        /// <summary>
        /// GetEmployees
        /// </summary>            
        /// <response code="200">Return employee list</response>
        /// <response code="400">Unable to process</response>
        [HttpGet]
        [Route("GetEmployees/{MemberID}")]
        public ActionResult<List<EmployeeMaster>> GetEmployees(int MemberID)
        {
            return _context.Employees.Where(d => d.MemberID == MemberID).ToList();
        }

        /// <summary>
        /// GetEmployeeDetails
        /// </summary>            
        /// <response code="200">Return employee details</response>
        /// <response code="400">Unable to process</response>
        [HttpGet]
        [Route("GetEmployeeDetails/{EmpCode}")]
        public ActionResult<EmployeeMaster> GetEmployeeDetails(string EmpCode)
        {
            return _context.Employees.SingleOrDefault(d => d.EmpCode == EmpCode);
        }

        /// <summary>
        /// AddEditEmployee
        /// </summary>            
        /// <response code="200">Return true or false</response>
        /// <response code="400">Unable to process</response>
        [HttpPost]
        [Route("AddEditEmployee")]
        public async Task<ActionResult<bool>> AddEditEmployee([FromBody] EmployeeMaster employee)
        {
            bool result = true;
            using (var trans = _context.Database.BeginTransaction())
            {
                try
                {
                    try
                    {
                        var emp = _context.Employees.SingleOrDefault(d => d.MemberID == employee.MemberID && d.EmpCode == employee.EmpCode);

                        if (emp != null)
                        {
                            emp.ModifiedDateTime = DateTime.Now;
                            _context.Entry(emp).State = EntityState.Modified;
                        }
                        else
                        {
                            employee.CreatedDateTime = DateTime.Now;
                            _context.Employees.Add(employee);
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
        [Route("UploadEmployees")]
        public async Task<ActionResult<bool>> UploadEmployees([FromBody] List<EmployeeMaster> employees)
        {
            bool result = true;
            using (var trans = _context.Database.BeginTransaction())
            {
                try
                {
                    try
                    {
                        foreach (var emp in employees)
                            _context.Employees.Add(emp);

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
