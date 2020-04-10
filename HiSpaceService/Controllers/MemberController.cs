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
	public class MemberController : Controller
	{
		private readonly HiSpaceContext _context;

		public MemberController(HiSpaceContext context)
		{
			_context = context;
		}

		#region MemberMaster

		/// <summary>
		/// Get all members
		/// </summary>
		/// <response code="200">Returns all member list</response>
		/// <response code="400">Unable to process</response>
		[HttpGet]
		[Route("GetMembers")]
		public async Task<ActionResult<IEnumerable<MemberMaster>>> GetMembers()
		{
			return await _context.Members.ToListAsync();
		}

		[HttpGet]
		[Route("GetMembersByClientID/{ClientID}")]
		public async Task<ActionResult<IEnumerable<MemberMaster>>> GetMembersByClientID(int ClientID)
		{
			return await _context.Members.Where(d => d.ClientID == ClientID).ToListAsync();
		}

		/// <summary>
		/// Get member details fro given member id
		/// </summary>
		/// <response code="200">Returns member details</response>
		/// <response code="400">Unable to process</response>
		[HttpGet("GetMember/{MemberID}")]
		public async Task<ActionResult<MemberMaster>> GetMember(int MemberID)
		{
			var member = await _context.Members.FindAsync(MemberID);

			if (member == null)
			{
				return NotFound();
			}

			return member;
		}

		/// <summary>
		/// Add new member
		/// </summary>
		/// <response code="200">Returns created new member details</response>
		/// <response code="400">Unable to process</response>
		[HttpPost]
		[Route("AddMemberMaster")]
		public async Task<ActionResult<MemberMaster>> AddMemberMaster([FromBody] MemberMaster memberMaster)
		{
			_context.Members.Add(memberMaster);
			await _context.SaveChangesAsync();

			return memberMaster;
			//return CreatedAtAction("AddMemberMaster", new { MemberID = memberMaster.MemberID }, memberMaster);
		}

		/// <summary>
		/// Add new user login
		/// </summary>
		/// <response code="200">Returns created new user login</response>
		/// <response code="400">Unable to process</response>
		[HttpPost("AddUserLogin")]
		public async Task<ActionResult<UserLogin>> AddUserLogin([FromBody] UserLogin userLogin)
		{
			_context.UserLogins.Add(userLogin);
			await _context.SaveChangesAsync();

			return CreatedAtAction("GetUserLogin", new { UserID = userLogin.UserID }, userLogin);
		}

		/// <summary>
		/// Edit member master details
		/// </summary>
		/// <response code="200">Returns true or false</response>
		/// <response code="400">Unable to process</response>
		[HttpPut("UpdateMemberMaster/{MemberID}")]
		public async Task<ActionResult<bool>> UpdateMemberMaster(int MemberID, [FromBody]  MemberMaster MemberMaster)
		{
			bool result = true;

			if (MemberID != MemberMaster.MemberID || MemberMaster == null)
			{
				return BadRequest();
			}

			_context.Entry(MemberMaster).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!MemberMasterExists(MemberID))
				{
					return NotFound();
				}
				else
				{
					throw;
				}
			}

			//return NoContent();
			return result;
		}

		private bool MemberMasterExists(int MemberID)
		{
			return _context.Members.Any(e => e.MemberID == MemberID);
		}

		/// <summary>
		/// Get member space listings
		/// </summary>
		/// <response code="200">Returns member space listngs</response>
		/// <response code="400">Unable to process</response>
		[HttpGet]
		[Route("GetMemberBookingsByMemberID/{MemberID}/{ClientID}")]
		public async Task<ActionResult<List<MemberBookingResponse>>> GetMemberBookingsByMemberID(int MemberID, int ClientID)
		{
			if (MemberID != 0)
			{
				var result = (from MB in _context.MemberBookingSpaces
							  join FP in _context.ClientWorkSpaceFloorPlans on MB.ClientSpaceFloorPlanID equals FP.ClientSpaceFloorPlanID
							  join FL in _context.ClientFloors on FP.ClientFloorID equals FL.ClientFloorID
							  join CM in _context.ClientMasters on FP.ClientID equals CM.ClientID
							  join CL in _context.ClientLocations on FP.ClientLocationID equals CL.ClientLocationID
							  join ST in _context.WSpaceTypeNames on FP.WSpaceTypeID equals ST.WSpaceTypeID
							  join MM in _context.Members on MB.MemberID equals MM.MemberID
							  //join MBSS in _context.MemberBookingSpaceSeats on MB.MemberBookingSpaceID equals MBSS.MemberBookingSpaceID
							  where MB.MemberID == MemberID //&& MB.ClientID == ClientID
							  select new MemberBookingResponse()
							  {
								  MemberBookingSpaceID = MB.MemberBookingSpaceID,
								  ClientSpaceFloorPlanID = FP.ClientSpaceFloorPlanID,
								  MemberID = MM.MemberID,
								  MemberName = MM.MemberName,
								  ClientName = CM.ClientName,
								  ClientLocationName = CL.ClientLocationName,
								  SpaceName = FP.SpaceName,
								  BookingStatus = MB.BookingStatus,
								  WSpaceTypeName = ST.WSpaceTypeName,
								  Floor = FL.FloorNumber,
								  NumberOfSeats = _context.MemberBookingSpaceSeats.Count(d => d.MemberBookingSpaceID == MB.MemberBookingSpaceID && d.SeatStatus == MemberBookingStatus.Requested),
								  SpacePrice = MB.SpacePrice,
								  //FromDayTime = MBSS.FromDateTime,
								  //ToDayTime = MBSS.ToDateTime
							  });

				return await result.ToListAsync();
			}
			else
			{
				var result = (from MB in _context.MemberBookingSpaces
							  join FP in _context.ClientWorkSpaceFloorPlans on MB.ClientSpaceFloorPlanID equals FP.ClientSpaceFloorPlanID
							  join FL in _context.ClientFloors on FP.ClientFloorID equals FL.ClientFloorID
							  join CM in _context.ClientMasters on FP.ClientID equals CM.ClientID
							  join CL in _context.ClientLocations on FP.ClientLocationID equals CL.ClientLocationID
							  join ST in _context.WSpaceTypeNames on FP.WSpaceTypeID equals ST.WSpaceTypeID
							  join MM in _context.Members on MB.MemberID equals MM.MemberID
							  //join MBSS in _context.MemberBookingSpaceSeats on MB.MemberBookingSpaceID equals MBSS.MemberBookingSpaceID
							  where MB.ClientID == ClientID
							  select new MemberBookingResponse()
							  {
								  MemberBookingSpaceID = MB.MemberBookingSpaceID,
								  ClientSpaceFloorPlanID = FP.ClientSpaceFloorPlanID,
								  MemberID = MM.MemberID,
								  MemberName = MM.MemberName,
								  ClientName = CM.ClientName,
								  ClientLocationName = CL.ClientLocationName,
								  SpaceName = FP.SpaceName,
								  BookingStatus = MB.BookingStatus,
								  WSpaceTypeName = ST.WSpaceTypeName,
								  Floor = FL.FloorNumber,
								  NumberOfSeats = _context.MemberBookingSpaceSeats.Count(d => d.MemberBookingSpaceID == MB.MemberBookingSpaceID && d.SeatStatus == MemberBookingStatus.Requested),
								  SpacePrice = MB.SpacePrice,
								  //FromDayTime = MBSS.FromDateTime,
								  //ToDayTime = MBSS.ToDateTime
							  });

				return await result.ToListAsync();
			}
		}

		[HttpGet("ApproveMemberBooking/{MemberBookingSpaceID}/{Status}")]
		public async Task<ActionResult<bool>> ApproveMemberBooking(int MemberBookingSpaceID, string Status)
		{
			bool result = true;
			if (MemberBookingSpaceID == 0)
			{
				result = false;
			}
			using (var trans = _context.Database.BeginTransaction())
			{
				try
				{
					try
					{
						var booking = _context.MemberBookingSpaces.SingleOrDefault(d => d.MemberBookingSpaceID == MemberBookingSpaceID && d.BookingStatus == MemberBookingStatus.Requested);
						if (booking != null)
						{
							var space = _context.ClientWorkSpaceFloorPlans.SingleOrDefault(d => d.ClientSpaceFloorPlanID == booking.ClientSpaceFloorPlanID);

							if (space != null)
							{
								if (space.Status == ClientBookingStatus.Available || space.Status == ClientBookingStatus.Partial)
								{
									if (Status == MemberBookingStatus.Approved)
									{
										space.Status = ClientBookingStatus.Occupied;
										space.ModifyDateTime = DateTime.Now;
										_context.Entry(space).State = EntityState.Modified;

										foreach (var clientSeat in _context.ClientSpaceSeats.Where(d => d.ClientSpaceFloorPlanID == space.ClientSpaceFloorPlanID))
										{
											clientSeat.SeatStatus = ClientBookingStatus.Occupied;
											clientSeat.ModifyDateTime = DateTime.Now;
											_context.Entry(clientSeat).State = EntityState.Modified;
										}
									}

									booking.BookingStatus = Status;
									booking.ModifyDateTime = DateTime.Now;
									_context.Entry(booking).State = EntityState.Modified;

									foreach (var memberSeat in _context.MemberBookingSpaceSeats.Where(d => d.MemberBookingSpaceID == booking.MemberBookingSpaceID))
									{
										memberSeat.SeatStatus = Status;
										memberSeat.ModifyDateTime = DateTime.Now;
										_context.Entry(memberSeat).State = EntityState.Modified;
									}
								}
							}
						}

						await _context.SaveChangesAsync();
						trans.Commit();
					}
					catch (DbUpdateConcurrencyException)
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
		/// Get client membership plans
		/// </summary>
		/// <response code="200">Return client membership plans</response>
		/// <response code="400">Unable to process</response>
		// GET: api/Common
		[HttpGet]
		[Route("GetClientMembershipPlans/{ClientID}")]
		public async Task<ActionResult<IEnumerable<ClientMembershipPlan>>> GetClientMembershipPlans(int ClientID)
		{
			return await _context.ClientMembershipPlans.Where(d => d.ClientID == ClientID).ToListAsync();
		}

		#region private methods

		private int GetNumberOfRequestedSeats(int MemberBookingSpaceID)
		{
			return _context.MemberBookingSpaceSeats.Count(d => d.MemberBookingSpaceID == MemberBookingSpaceID && d.SeatStatus == MemberBookingStatus.Requested);
		}

		#endregion private methods

		#endregion MemberMaster
	}
}