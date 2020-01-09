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
    public class AttendanceController : Controller
    {
        private readonly HiSpaceContext _context;

        public AttendanceController(HiSpaceContext context)
        {
            _context = context;
        }

        /// <summary>
        /// GetAttendanceByMember
        /// </summary>            
        /// <response code="200">Return employee list</response>
        /// <response code="400">Unable to process</response>
        [HttpGet]
        [Route("GetAttendanceByMember/{MemberID}")]
        public ActionResult<List<AttendanceListResponse>> GetAttendanceByMember(int MemberID)
        {

            var attens = (from AT in _context.Attendance
                          join EM in _context.Employees on AT.EmpCode equals EM.EmpCode
                          where EM.MemberID == MemberID
                          select new AttendanceListResponse()
                          {
                              AttendanceID = AT.AttendanceID,
                              MemberID = AT.MemberID,
                              EmpCode = EM.EmpCode,
                              Name = EM.Name,
                              Designation = EM.Designation,
                              AttendanceDate = AT.AttendanceDate,
                              InTime = AT.InTime,
                              OutTime = AT.OutTime
                          }).ToList();


            return attens;
        }

        /// <summary>
        /// GetAttendanceByMember
        /// </summary>            
        /// <response code="200">Return employee list</response>
        /// <response code="400">Unable to process</response>
        [HttpPost]
        [Route("GetAttendanceByMember")]
        public ActionResult<List<AttendanceListResponse>> GetAttendanceByMember([FromBody] AttendanceRequest request)
        {
            List<AttendanceListResponse> response = new List<AttendanceListResponse>();

            if (request.EmpID > 0 && request.FromDate !=null && request.ToDate !=null)
            {
                response = (from AT in _context.Attendance
                            join EM in _context.Employees on AT.EmpCode equals EM.EmpCode
                            where EM.MemberID == request.MemberID 
                            && EM.EmpID == request.EmpID 
                            && (AT.AttendanceDate >= request.FromDate.Value && AT.AttendanceDate <= request.ToDate.Value.AddDays(1))
                            select new AttendanceListResponse()
                            {
                                AttendanceID = AT.AttendanceID,
                                MemberID = AT.MemberID,
                                EmpCode = EM.EmpCode,
                                Name = EM.Name,
                                Designation = EM.Designation,
                                AttendanceDate = AT.AttendanceDate,
                                InTime = AT.InTime,
                                OutTime = AT.OutTime
                            }).ToList();
            }
            else if (request.EmpID > 0 && request.FromDate != null && request.ToDate == null)
            {
                response = (from AT in _context.Attendance
                            join EM in _context.Employees on AT.EmpCode equals EM.EmpCode
                            where EM.MemberID == request.MemberID
                             && EM.EmpID == request.EmpID
                            && (AT.AttendanceDate >= request.FromDate.Value)
                            select new AttendanceListResponse()
                            {
                                AttendanceID = AT.AttendanceID,
                                MemberID = AT.MemberID,
                                EmpCode = EM.EmpCode,
                                Name = EM.Name,
                                Designation = EM.Designation,
                                AttendanceDate = AT.AttendanceDate,
                                InTime = AT.InTime,
                                OutTime = AT.OutTime
                            }).ToList();
            }
            else if (request.EmpID > 0 && request.FromDate == null && request.ToDate != null)
            {
                response = (from AT in _context.Attendance
                            join EM in _context.Employees on AT.EmpCode equals EM.EmpCode
                            where EM.MemberID == request.MemberID
                             && EM.EmpID == request.EmpID
                            && (AT.AttendanceDate <= request.ToDate.Value.AddDays(1))
                            select new AttendanceListResponse()
                            {
                                AttendanceID = AT.AttendanceID,
                                MemberID = AT.MemberID,
                                EmpCode = EM.EmpCode,
                                Name = EM.Name,
                                Designation = EM.Designation,
                                AttendanceDate = AT.AttendanceDate,
                                InTime = AT.InTime,
                                OutTime = AT.OutTime
                            }).ToList();
            }
            else if (request.EmpID < 0 && request.FromDate != null && request.ToDate == null)
            {
                response = (from AT in _context.Attendance
                            join EM in _context.Employees on AT.EmpCode equals EM.EmpCode
                            where EM.MemberID == request.MemberID
                            && (AT.AttendanceDate >= request.FromDate.Value)
                            select new AttendanceListResponse()
                            {
                                AttendanceID = AT.AttendanceID,
                                MemberID = AT.MemberID,
                                EmpCode = EM.EmpCode,
                                Name = EM.Name,
                                Designation = EM.Designation,
                                AttendanceDate = AT.AttendanceDate,
                                InTime = AT.InTime,
                                OutTime = AT.OutTime
                            }).ToList();
            }
            else if (request.EmpID < 0 && request.FromDate == null && request.ToDate != null)
            {
                response = (from AT in _context.Attendance
                            join EM in _context.Employees on AT.EmpCode equals EM.EmpCode
                            where EM.MemberID == request.MemberID
                            && (AT.AttendanceDate <= request.ToDate.Value.AddDays(1))
                            select new AttendanceListResponse()
                            {
                                AttendanceID = AT.AttendanceID,
                                MemberID = AT.MemberID,
                                EmpCode = EM.EmpCode,
                                Name = EM.Name,
                                Designation = EM.Designation,
                                AttendanceDate = AT.AttendanceDate,
                                InTime = AT.InTime,
                                OutTime = AT.OutTime
                            }).ToList();
            }
            else if (request.EmpID > 0 && request.FromDate == null && request.ToDate == null)
            {
                response = (from AT in _context.Attendance
                            join EM in _context.Employees on AT.EmpCode equals EM.EmpCode
                            where EM.MemberID == request.MemberID
                            && EM.EmpID == request.EmpID
                            select new AttendanceListResponse()
                            {
                                AttendanceID = AT.AttendanceID,
                                MemberID = AT.MemberID,
                                EmpCode = EM.EmpCode,
                                Name = EM.Name,
                                Designation = EM.Designation,
                                AttendanceDate = AT.AttendanceDate,
                                InTime = AT.InTime,
                                OutTime = AT.OutTime
                            }).ToList();
            }
            else if (request.EmpID <= 0 && request.FromDate != null && request.ToDate != null)
            {
                response = (from AT in _context.Attendance
                            join EM in _context.Employees on AT.EmpCode equals EM.EmpCode
                            where EM.MemberID == request.MemberID
                            && (AT.AttendanceDate >= request.FromDate.Value && AT.AttendanceDate <= request.ToDate.Value.AddDays(1))
                            select new AttendanceListResponse()
                            {
                                AttendanceID = AT.AttendanceID,
                                MemberID = AT.MemberID,
                                EmpCode = EM.EmpCode,
                                Name = EM.Name,
                                Designation = EM.Designation,
                                AttendanceDate = AT.AttendanceDate,
                                InTime = AT.InTime,
                                OutTime = AT.OutTime
                            }).ToList();
            }
            else             
            {
                response = (from AT in _context.Attendance
                            join EM in _context.Employees on AT.EmpCode equals EM.EmpCode
                            where EM.MemberID == request.MemberID                            
                            select new AttendanceListResponse()
                            {
                                AttendanceID = AT.AttendanceID,
                                MemberID = AT.MemberID,
                                EmpCode = EM.EmpCode,
                                Name = EM.Name,
                                Designation = EM.Designation,
                                AttendanceDate = AT.AttendanceDate,
                                InTime = AT.InTime,
                                OutTime = AT.OutTime
                            }).ToList();
            }

            return response;
        }


        /// <summary>
        /// UploadAttendance
        /// </summary>            
        /// <response code="200">Return true or false</response>
        /// <response code="400">Unable to process</response>
        [HttpPost]
        [Route("UploadAttendance/{EmpID}")]
        public async Task<ActionResult<bool>> UploadAttendance([FromBody] List<Attendance> attendance, int MemberID)
        {
            bool result = true;
            using (var trans = _context.Database.BeginTransaction())
            {
                try
                {
                    try
                    {
                        foreach (var atten in attendance)
                        {
                            var _atten = _context.Attendance.SingleOrDefault(d => d.MemberID == MemberID && d.EmpCode == atten.EmpCode && d.AttendanceDate == atten.AttendanceDate);
                            if (_atten != null)
                            {
                                _atten.InTime = atten.InTime;
                                _atten.OutTime = atten.OutTime;
                                _context.Entry(_atten).State = EntityState.Modified;
                            }
                            else
                                _context.Attendance.Add(atten);
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
    }
}
