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
    public class SpaceBookingController : Controller
    {
        private readonly HiSpaceContext _context;

        public SpaceBookingController(HiSpaceContext context)
        {
            _context = context;
        }

        #region MemberSpace

        /// <summary>
        /// Get booking space list
        /// </summary>            
        /// <response code="200">Return space list</response>
        /// <response code="400">Unable to process</response>
        [HttpGet]
        [Route("GetBookingSpaces/{LocationID}")]
        public async Task<ActionResult<List<SpaceBookingResponse>>> GetBookingSpaces(int LocationID)
        {
            var result = (from FP in _context.ClientWorkSpaceFloorPlans
                          join FL in _context.ClientFloors on FP.ClientFloorID equals FL.ClientFloorID
                          join CM in _context.ClientMasters on FP.ClientID equals CM.ClientID
                          join CL in _context.ClientLocations on FP.ClientLocationID equals CL.ClientLocationID
                          join ST in _context.WSpaceTypeNames on FP.WSpaceTypeID equals ST.WSpaceTypeID
                          join CT in _context.ChairTypes on FP.ChairTypeID equals CT.ChairTypeID
                          join SM in _context.ScaleMetrics on FP.ScaleMetricID equals SM.ScaleMetricID
                          where FP.ClientID == LocationID
                          select new SpaceBookingResponse()
                          {
                              ClientSpaceFloorPlanID = FP.ClientSpaceFloorPlanID,
                              ClientID = FP.ClientID,
                              ClientName = CM.ClientName,
                              ClientLocationID = FP.ClientLocationID,
                              ClientLocationName = CL.ClientLocationName,
                              SpaceName = FP.SpaceName,
                              WSpaceTypeID = FP.WSpaceTypeID,
                              WSpaceTypeName = ST.WSpaceTypeName,
                              ChairTypeID = FP.ChairTypeID,
                              ChairTypeName = CT.ChairTypeName,
                              Floor = FL.FloorNumber,
                              NumberOfSeats = FP.NumberOfSeats,
                              Price = FP.Price,
                              ScaleMetricID = FP.ScaleMetricID,
                              ScaleMetricName = SM.ScaleMetricName,
                              FloorLength = FP.FloorLength,
                              FloorBreadth = FP.FloorBreadth,
                              NumberOfRows = FP.NumberOfRows,
                              NumberOfColumns = FP.NumberOfColumns,
                              SeatSize = FP.SeatSize,
                              Status = FP.Status,
                              FloorPlanFilePath = FP.FloorPlanFilePath,
                              ContactPersonName = CL.ContactPersonName,
                              Verification = FP.Verification
                          });

            return await result.ToListAsync();
        }

        /// <summary>
        /// Get card list
        /// </summary>            
        /// <response code="200">Return card list</response>
        /// <response code="400">Unable to process</response>
        [HttpGet]
        [Route("GetCardDetails/{MemberID}")]
        public ActionResult<List<MyCard>> GetCardDetails(int MemberID)
        {
            List<MyCard> _myCards = new List<MyCard>();
            try
            {
                _myCards = _context.MyCards.Where(d => d.MemberID == MemberID).ToList();
            }
            catch (Exception err)
            {
            }
            return _myCards;
        }

        /// <summary>
        /// Update card list
        /// </summary>            
        /// <response code="200">Return true or false</response>
        /// <response code="400">Unable to process</response>
        [HttpPost]
        [Route("UpdateCardDetails")]
        public async Task<ActionResult<bool>> UpdateCardDetails([FromBody]List<MyCard> myCards)
        {
            bool result = true;
            using (var trans = _context.Database.BeginTransaction())
            {
                try
                {
                    foreach (var item in myCards)
                    {
                        var _card = _context.MyCards.SingleOrDefault(d => d.MemberID == item.MemberID && d.ClientSpaceFloorPlanID == item.ClientSpaceFloorPlanID && d.ClientSpaceSeatID == item.ClientSpaceSeatID);
                        if (_card == null)
                        {
                            _context.Add(item);
                            await _context.SaveChangesAsync();
                        }
                        else
                        {
                            _context.Entry(_card).State = EntityState.Modified;
                            await _context.SaveChangesAsync();
                        }
                    }
                    trans.Commit();
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
        /// Remove item from card
        /// </summary>            
        /// <response code="200">Return true or false</response>
        /// <response code="400">Unable to process</response>
        [HttpPost]
        [Route("RemoveItemFromCard")]
        public async Task<ActionResult<bool>> RemoveItemFromCard([FromBody] MyCard myCard)
        {
            bool result = true;
            using (var trans = _context.Database.BeginTransaction())
            {
                try
                {
                    _context.Remove(myCard);
                    await _context.SaveChangesAsync();
                    trans.Commit();
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
        /// Book Spaces/Seats
        /// </summary>            
        /// <response code="200">Return true or false</response>
        /// <response code="400">Unable to process</response>
        [HttpPost]
        [Route("BookSpaces")]
        public async Task<ActionResult<bool>> BookSpaces([FromBody] MemberBookingRequest bookingRequest)
        {
            bool result = true;


            #region Collect Existing Seats for Requested Spaces

            List<MemberBookingSpaceSeat> itemsToDelete = new List<MemberBookingSpaceSeat>();
            using (var _delete = _context.Database.BeginTransaction())
            {
                var spaces = bookingRequest.memberBookingSpaces.GroupBy(d => d.ClientSpaceFloorPlanID);
                foreach (var _space in spaces)
                {
                    foreach (var _spaceSeat in _context.MemberBookingSpaceSeats.Where(d => d.MemberBookingSpaceID == _space.Key))
                        itemsToDelete.Add(_spaceSeat);
                }
            }

            #endregion

            using (var trans = _context.Database.BeginTransaction())
            {
                try
                {
                    try
                    {

                        #region Saving Booking Request

                        //remove existing seats
                        foreach (var item in itemsToDelete)
                        {
                            _context.MemberBookingSpaceSeats.Remove(item);
                        }

                        foreach (var newSpace in bookingRequest.memberBookingSpaces)
                        {
                            var isSpaceAvailable = _context.ClientWorkSpaceFloorPlans.SingleOrDefault(m => m.ClientSpaceFloorPlanID == newSpace.ClientSpaceFloorPlanID);

                            if (isSpaceAvailable != null)
                            {
                                bool CanAddSeat = false;

                                if (isSpaceAvailable.Status == ClientBookingStatus.Available)
                                {
                                    newSpace.BookingStatus = MemberBookingStatus.Requested;
                                    newSpace.CreatedDateTime = DateTime.Now;
                                    _context.MemberBookingSpaces.Add(newSpace);
                                    //newSpace.MemberBookingSpaceID = trans.TransactionId;
                                    CanAddSeat = true;
                                }
                                else if (isSpaceAvailable.Status == ClientBookingStatus.Occupied && isSpaceAvailable.ClientID == newSpace.ClientID && isSpaceAvailable.ClientSpaceFloorPlanID == newSpace.ClientSpaceFloorPlanID)
                                {
                                    newSpace.ModifyDateTime = DateTime.Now;
                                    _context.Entry(newSpace).State = EntityState.Modified;
                                    CanAddSeat = true;
                                }

                                //adding newly selected seats by space wise
                                if (CanAddSeat)
                                {
                                    //foreach (var newSeat in bookingRequest.memberBookingSpaceSeats.Where(d => d.MemberBookingSpaceID == newSpace.MemberBookingSpaceID).ToList())
                                    foreach (var newSeat in bookingRequest.memberBookingSpaceSeats)
                                    {
                                        //var isSeatAvailable = _context.ClientSpaceSeats.SingleOrDefault(m => m.ClientSpaceSeatID == newSeat.ClientSpaceSeatID);

                                        //if (isSeatAvailable != null)
                                        //{
                                        //    if (isSeatAvailable.SeatStatus == ClientBookingStatus.Available)
                                        //    {
                                        newSeat.MemberBookingSpaceID = newSpace.MemberBookingSpaceID;
                                        newSeat.SeatStatus = MemberBookingStatus.Requested;
                                        newSeat.CreatedDateTime = DateTime.Now;
                                        _context.MemberBookingSpaceSeats.Add(newSeat);
                                        //    }
                                        //}
                                    }
                                }
                            }
                        }

                        #endregion

                        #region Commit dbcontext

                        await _context.SaveChangesAsync();
                        trans.Commit();

                        #endregion
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
        /// Request Spaces
        /// </summary>            
        /// <response code="200">Return true or false</response>
        /// <response code="400">Unable to process</response>
        [HttpPost]
        [Route("RequestSpace")]
        public async Task<ActionResult<MemberBookingSpace>> RequestSpace([FromBody] MemberBookingSpace requestSpace)
        {
            bool result = true;

            using (var trans = _context.Database.BeginTransaction())
            {
                try
                {
                    try
                    {
                        requestSpace.BookingStatus = MemberBookingStatus.Requested;
                        requestSpace.CreatedDateTime = DateTime.Now;
                        _context.MemberBookingSpaces.Add(requestSpace);
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

            return requestSpace;
        }

        /// <summary>
        /// Request Seats
        /// </summary>            
        /// <response code="200">Return true or false</response>
        /// <response code="400">Unable to process</response>
        [HttpPost]
        [Route("RequestSpaceSeats")]
        public async Task<ActionResult<bool>> RequestSpaceSeats([FromBody] List<MemberBookingSpaceSeat> requestSpaceSeats)
        {
            bool result = true;

            #region Collect Existing Seats for Requested Spaces

            List<MemberBookingSpaceSeat> itemsToDelete = new List<MemberBookingSpaceSeat>();

            if (requestSpaceSeats.Count > 0)
            {
                using (var _delete = _context.Database.BeginTransaction())
                {
                    foreach (var _spaceSeat in _context.MemberBookingSpaceSeats.Where(d => d.MemberBookingSpaceID == requestSpaceSeats[0].MemberBookingSpaceID))
                        itemsToDelete.Add(_spaceSeat);
                }
            }

            #endregion

            using (var trans = _context.Database.BeginTransaction())
            {
                try
                {
                    try
                    {

                       
                        //remove existing seats
                        foreach (var item in itemsToDelete)
                        {
                            _context.MemberBookingSpaceSeats.Remove(item);
                        }

                        foreach (var newSeat in requestSpaceSeats)
                        {
                            newSeat.SeatStatus = MemberBookingStatus.Requested;
                            newSeat.CreatedDateTime = DateTime.Now;
                            _context.MemberBookingSpaceSeats.Add(newSeat);
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

        #endregion


        /// <summary>
        /// Book Space Facilities
        /// </summary>            
        /// <response code="200">Return true or false</response>
        /// <response code="400">Unable to process</response>
        [HttpPost]
        [Route("BookFacility")]
        public async Task<ActionResult<bool>> BookFacility([FromBody] List<FacilityBooking> facilityBookings)
        {
            bool result = true;

            #region Collect Existing Booked Facilities for Requested Spaces

            List<FacilityBooking> itemsToDelete = new List<FacilityBooking>();

            if (facilityBookings.Count > 0)
            {
                using (var _delete = _context.Database.BeginTransaction())
                {
                    foreach (var _bookedFacility in _context.FacilityBookings.Where(d => d.MemberBookingSpaceID == facilityBookings[0].MemberBookingSpaceID))
                        itemsToDelete.Add(_bookedFacility);
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
                        _context.FacilityBookings.RemoveRange(itemsToDelete);
                        
                        facilityBookings.ForEach(n => n.CreatedDateTime = DateTime.Now);
                        
                        _context.FacilityBookings.AddRange(facilityBookings);        
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
