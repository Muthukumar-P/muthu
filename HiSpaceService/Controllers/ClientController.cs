using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using HiSpaceModels;
using HiSpaceService.Models;
using HiSpaceService.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HiSpaceService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Produces("application/json")]
    public class ClientController : Controller
    {
        private readonly HiSpaceContext _context;

        public ClientController(HiSpaceContext context)
        {
            _context = context;
        }

        #region ClientMaster

        /// <summary>
        /// Get list clients
        /// </summary>
        /// <param ></param>
        /// <returns></returns>
        /// <returns></returns>
        /// <remakrs>
        /// Sample **request**:
        /// 
        /// POST /api/GetClients
        /// {
        /// "name": "Some name"
        /// }
        /// 
        /// </remakrs>
        /// <response code="200">Returne all list clients from database</response>
        /// <response code="400">Unable to process</response>
        // GET: api/Client
        [HttpGet]
        [Route("GetClients")]
        public async Task<ActionResult<IEnumerable<ClientMaster>>> GetClients()
        {
            return await _context.ClientMasters.ToListAsync();
        }


        /// <summary>
        /// Get client details
        /// </summary>
        /// <param>Request</param>
        /// <param>ClientID</param>
        /// <returns>ClientMaster</returns>
        /// 

        // GET: api/Client/1
        //[HttpGet("GetClient/{ClientID}")]
        [HttpGet("GetClient/{ClientID}")]
        //[Route("GetClient/{ClientID}")]
        public async Task<ActionResult<ClientMaster>> GetClient(int ClientID)
        {
            var client = await _context.ClientMasters.FindAsync(ClientID);

            if (client == null)
            {
                return NotFound();
            }

            return client;
        }

        /// <summary>
        /// Create new client master
        /// </summary>
        /// <param ></param>
        /// <returns></returns>
        /// <returns></returns>
        /// <remakrs>
        /// Sample **request**:
        /// 
        /// POST /api/AddClientMaster
        /// {
        /// "name": "Some name"
        /// }
        /// 
        /// </remakrs>
        /// <response code="200">Successfully Created</response>
        /// <response code="400">Unable to process</response>
        // POST: api/Client
        [HttpPost("AddClientMaster")]
        public async Task<ActionResult<ClientMaster>> AddClientMaster([FromBody] ClientMaster clientMaster)
        {
            clientMaster.CreatedDateTime = DateTime.Now;

            _context.ClientMasters.Add(clientMaster);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClientMaster", new { ClientID = clientMaster.ClientID }, clientMaster);
        }

        // PUT: api/Client
        [HttpPut("UpdateClientMaster/{ClientID}")]
        public async Task<IActionResult> UpdateClientMaster(int ClientID, [FromBody]  ClientMaster clientMaster)
        {
            if (ClientID != clientMaster.ClientID || clientMaster == null)
            {
                return BadRequest();
            }

            using (var trans = _context.Database.BeginTransaction())
            {
                try
                {

                    _context.Entry(clientMaster).State = EntityState.Modified;

                    try
                    {
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!ClientMasterExists(ClientID))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }

                    trans.Commit();
                }
                catch (Exception err)
                {
                    trans.Rollback();
                }
            }

            return NoContent();
        }

        // PUT: api/Client
        [HttpGet("ApproveClient/{ClientID}/{Status}")]
        public ActionResult<bool> ApproveClient(int ClientID, string Status)
        {
            bool result = true;
            if (ClientID == 0)
            {
                result = false;
            }
            try
            {
                var client = _context.ClientMasters.SingleOrDefault(d => d.ClientID == ClientID);
                if (client != null)
                {
                    client.ClientStatus = Status;
                    _context.Entry(client).State = EntityState.Modified;
                    _context.SaveChangesAsync();
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                result = false;
            }

            return result;
        }

        private bool ClientMasterExists(int ClientID)
        {
            return _context.ClientMasters.Any(e => e.ClientID == ClientID);
        }

        #endregion

        #region ClientLocation

        // GET: api/Client
        [HttpGet]
        [Route("GetClientLocations")]
        public async Task<ActionResult<IEnumerable<ClientLocation>>> GetClientLocations()
        {
            return await _context.ClientLocations.ToListAsync();
        }

        // GET: api/Client
        [HttpGet]
        [Route("GetClientLocationsByClientID/{ClientID}")]
        public async Task<ActionResult<IEnumerable<ClientLocation>>> GetClientLocationsByClientID(int ClientID)
        {
            return await _context.ClientLocations.Where(d => d.ClientID == ClientID).ToListAsync();
        }

        // GET: api/Client/1
        [HttpGet("GetClientLocation/{ClientLocationID}")]
        public async Task<ActionResult<ClientLocation>> GetClientLocation(int ClientLocationID)
        {
            var clientLocation = await _context.ClientLocations.FindAsync(ClientLocationID);

            if (clientLocation == null)
            {
                return NotFound();
            }

            return clientLocation;
        }

        // POST: api/Client
        [HttpPost("AddClientLocation")]
        public async Task<ActionResult<ClientLocation>> AddClientLocation([FromBody] ClientLocation clientLocation)
        {
            _context.ClientLocations.Add(clientLocation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClientLocation", new { ClientLocationID = clientLocation.ClientLocationID }, clientLocation);
        }

        // PUT: api/Client
        [HttpPut("UpdateClientLocation/{ClientLocationID}")]
        public async Task<IActionResult> UpdateClientLocation(int ClientLocationID, [FromBody] ClientLocation clientLocation)
        {
            if (ClientLocationID != clientLocation.ClientLocationID || clientLocation == null)
            {
                return BadRequest();
            }

            _context.Entry(clientLocation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientLocationExists(ClientLocationID))
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

        private bool ClientLocationExists(int ClientLocationID)
        {
            return _context.ClientLocations.Any(e => e.ClientLocationID == ClientLocationID);
        }

        #endregion

        #region ClientFacility

        // GET: api/Client
        [HttpGet]
        [Route("GetClientSpaceFacilities/{ClientID}/{ClientFloorID}")]
        public async Task<ActionResult<IEnumerable<ClientFacility>>> GetClientSpaceFacilities(int ClientID, int ClientFloorID)
        {
            return await _context.ClientFacilities.Where(d => d.ClientID == ClientID && d.ClientFloorID == ClientFloorID).ToListAsync();
        }

        [HttpGet]
        [Route("GetClientSpaceFacilitiesByClientSpace/{SpaceFloorPlanID}")]
        public async Task<ActionResult<List<ClientFacility>>> GetClientSpaceFacilitiesByClientSpace(int SpaceFloorPlanID)
        {
            return await _context.ClientFacilities.Where(d => d.ClientSpaceFloorPlanID == SpaceFloorPlanID).ToListAsync();
        }

        // GET: api/Client/1
        [HttpGet("GetClientFacility/{ClientFacilityID}")]
        public async Task<ActionResult<ClientFacility>> GetClientFacility(int ClientFacilityID)
        {
            var clienSpaceFacility = await _context.ClientFacilities.FindAsync(ClientFacilityID);

            if (clienSpaceFacility == null)
            {
                return NotFound();
            }

            return clienSpaceFacility;
        }

        // POST: api/Client
        [HttpPost("AddClientFacility")]
        public async Task<ActionResult<bool>> AddClientFacility([FromBody] List<ClientFacility> ClientFacilityList)
        {
            foreach (var item in ClientFacilityList)
            {
                _context.ClientFacilities.Add(item);
                await _context.SaveChangesAsync();
            }

            //return CreatedAtAction("ClientFacility", new { ClientFacilityID = ClientFacility.ClientFacilityID }, ClientFacility);

            return true;
        }

        // PUT: api/Client
        //[HttpPut("UpdateClientFacility")]
        [HttpPut]
        [Route("UpdateClientFacility/{ClientID}")]
        public async Task<ActionResult<bool>> UpdateClientFacility(int ClientID, [FromBody] List<ClientFacility> clientFacilityList)
        {
            bool result = true;

            if (clientFacilityList == null)
                return false;

            List<ClientFacility> itemsToDelete = new List<ClientFacility>();
            using (var _delete = _context.Database.BeginTransaction())
            {
                foreach (var _item in _context.ClientFacilities.Where(d => d.ClientID == ClientID))
                    itemsToDelete.Add(_item);
            }

            using (var trans = _context.Database.BeginTransaction())
            {
                try
                {
                    try
                    {
                        foreach (var item in itemsToDelete)
                        {
                            _context.ClientFacilities.Remove(item);
                            //await _context.SaveChangesAsync();
                        }

                        foreach (var item in clientFacilityList)
                        {
                            //_context.Entry(item).State = EntityState.Modified;
                            _context.ClientFacilities.Add(item);
                            await _context.SaveChangesAsync();
                        }
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        trans.Rollback();
                        result = false;
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

        private bool ClientFacilityExists(int ClientFacilityID)
        {
            return _context.ClientFacilities.Any(e => e.ClientFacilityID == ClientFacilityID);
        }


        #endregion

        #region ClientWorkSpaceFloorPlan

        // GET: api/Client
        [HttpGet]
        [Route("GetClientWorkSpaceFloorPlanList")]
        public async Task<ActionResult<IEnumerable<SpaceDetailsListSearchResponse>>> GetClientWorkSpaceFloorPlanList()
        {
            List<SpaceDetailsListSearchResponse> lst = new List<SpaceDetailsListSearchResponse>();
            var spaces = await _context.ClientWorkSpaceFloorPlans.Where(m => m.Verification == "Approved").OrderByDescending(d => d.CreatedDateTime).ToListAsync();

            foreach (var item in spaces)
            {
                SpaceDetailsListSearchResponse space = new SpaceDetailsListSearchResponse();
                space.space = item;
                space.client = _context.ClientMasters.SingleOrDefault(d => d.ClientID == item.ClientID);
                space.location = _context.ClientLocations.SingleOrDefault(d => d.ClientID == item.ClientID && d.ClientLocationID == item.ClientLocationID);
                space.AvailableFacilities = (from CF in _context.ClientFacilities
                                             join FM in _context.FacilityMasters on CF.FacilityID equals FM.FacilityID
                                             where CF.ClientID == item.ClientID && CF.ClientFloorID == item.ClientFloorID && CF.Available
                                             select new FacilityMaster() { FacilityID = CF.FacilityID, FacilityName = FM.FacilityName }
                            ).ToList().Count();
                space.AvailableSeats = _context.ClientSpaceSeats.Count(m => m.ClientSpaceFloorPlanID == item.ClientSpaceFloorPlanID && m.SeatStatus == "Available");
                space.OccupiedSeats = _context.ClientSpaceSeats.Count(m => m.ClientSpaceFloorPlanID == item.ClientSpaceFloorPlanID && m.SeatStatus == "Occupied");

                lst.Add(space);
            }

            //return lst;
            return lst;
        }

        // GET: api/Client
        [HttpGet]
        [Route("GetFacilitiesBySpace/{ClientSpaceFloorPlanID}")]
        public async Task<ActionResult<IEnumerable<FacilityMaster>>> GetFacilitiesBySpace(int ClientSpaceFloorPlanID)
        {
            List<FacilityMaster> facs = new List<FacilityMaster>();
            var space = _context.ClientWorkSpaceFloorPlans.SingleOrDefault(d => d.ClientSpaceFloorPlanID == ClientSpaceFloorPlanID);

            if (space != null)
            {
                facs = await (from CF in _context.ClientFacilities
                              join FM in _context.FacilityMasters on CF.FacilityID equals FM.FacilityID
                              where CF.ClientID == space.ClientID && CF.ClientFloorID == space.ClientFloorID && CF.Available
                              select new FacilityMaster() { FacilityID = CF.FacilityID, FacilityName = FM.FacilityName }
                            ).ToListAsync();
            }

            return facs;
        }

        // GET: api/Client
        [HttpGet]
        [Route("GetClientWorkSpaceFloorPlans/{ClientLocationID}")]
        //public async Task<ActionResult<IEnumerable<ClientWorkSpaceFloorPlan>>> GetClientWorkSpaceFloorPlans()
        public ActionResult<List<ClientWorkSpaceFloorPlan>> GetClientWorkSpaceFloorPlans(int ClientLocationID)
        {
            List<ClientWorkSpaceFloorPlan> lst = new List<ClientWorkSpaceFloorPlan>();
            foreach (var item in _context.ClientWorkSpaceFloorPlans.Where(d => d.ClientLocationID == ClientLocationID))
                lst.Add(item);

            return lst;
            //return await _context.ClientWorkSpaceFloorPlans.Where(d => d.ClientLocationID == ClientLocationID).ToListAsync();
        }

        // GET: api/Client
        [HttpGet]
        [Route("GetClientWorkSpaceFloorPlansByFilter/{ClientID}/{ClientLocationID}")]
        //public async Task<ActionResult<IEnumerable<ClientWorkSpaceFloorPlan>>> GetClientWorkSpaceFloorPlans()
        public ActionResult<List<SpaceBookingResponse>> GetClientWorkSpaceFloorPlansByFilter(int ClientID, int ClientLocationID)
        {
            if (ClientID != 0 && ClientLocationID == 0)
            {
                var result = (from FP in _context.ClientWorkSpaceFloorPlans
                              join FL in _context.ClientFloors on FP.ClientFloorID equals FL.ClientFloorID
                              join CM in _context.ClientMasters on FP.ClientID equals CM.ClientID
                              join CL in _context.ClientLocations on FP.ClientLocationID equals CL.ClientLocationID
                              join ST in _context.WSpaceTypeNames on FP.WSpaceTypeID equals ST.WSpaceTypeID
                              join CT in _context.ChairTypes on FP.ChairTypeID equals CT.ChairTypeID
                              join SM in _context.ScaleMetrics on FP.ScaleMetricID equals SM.ScaleMetricID
                              where FP.ClientID == ClientID
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
                                  Verification = FP.Verification,
								  Is24 = FP.Is24,
								  SunAvail = FP.SunAvail,
								  SunClose = FP.SunClose,
								  SunOpen = FP.SunOpen,
								  MonAvail = FP.MonAvail,
								  MonClose = FP.MonClose,
								  MonOpen = FP.MonOpen,
								  TueAvail = FP.TueAvail,
								  TueClose = FP.TueClose,
								  TueOpen = FP.TueOpen,
								  WedAvail = FP.WedAvail,
								  WedClose = FP.WedClose,
								  WedOpen = FP.WedOpen,
								  ThuAvail = FP.ThuAvail,
								  ThuClose = FP.ThuClose,
								  ThuOpen = FP.ThuOpen,
								  FriAvail = FP.FriAvail,
								  FriClose = FP.FriClose,
								  FriOpen = FP.FriOpen,
								  SatAvail = FP.SatAvail,
								  SatClose = FP.SatClose,
								  SatOpen = FP.SatOpen

							  });
                return result.ToList();
            }
            else if (ClientID != 0 && ClientLocationID != 0)
            {
                var result = (from FP in _context.ClientWorkSpaceFloorPlans
                              join FL in _context.ClientFloors on FP.ClientFloorID equals FL.ClientFloorID
                              join CM in _context.ClientMasters on FP.ClientID equals CM.ClientID
                              join CL in _context.ClientLocations on FP.ClientLocationID equals CL.ClientLocationID
                              join ST in _context.WSpaceTypeNames on FP.WSpaceTypeID equals ST.WSpaceTypeID
                              join CT in _context.ChairTypes on FP.ChairTypeID equals CT.ChairTypeID
                              join SM in _context.ScaleMetrics on FP.ScaleMetricID equals SM.ScaleMetricID
                              where FP.ClientID == ClientID && FP.ClientLocationID == ClientLocationID
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
                                  Verification = FP.Verification,
								  Is24 = FP.Is24,
								  SunAvail = FP.SunAvail,
								  SunClose = FP.SunClose,
								  SunOpen = FP.SunOpen,
								  MonAvail = FP.MonAvail,
								  MonClose = FP.MonClose,
								  MonOpen = FP.MonOpen,
								  TueAvail = FP.TueAvail,
								  TueClose = FP.TueClose,
								  TueOpen = FP.TueOpen,
								  WedAvail = FP.WedAvail,
								  WedClose = FP.WedClose,
								  WedOpen = FP.WedOpen,
								  ThuAvail = FP.ThuAvail,
								  ThuClose = FP.ThuClose,
								  ThuOpen = FP.ThuOpen,
								  FriAvail = FP.FriAvail,
								  FriClose = FP.FriClose,
								  FriOpen = FP.FriOpen,
								  SatAvail = FP.SatAvail,
								  SatClose = FP.SatClose,
								  SatOpen = FP.SatOpen
							  });
                return result.ToList();
            }
            else
            {
                var result = (from FP in _context.ClientWorkSpaceFloorPlans
                              join FL in _context.ClientFloors on FP.ClientFloorID equals FL.ClientFloorID
                              join CM in _context.ClientMasters on FP.ClientID equals CM.ClientID
                              join CL in _context.ClientLocations on FP.ClientLocationID equals CL.ClientLocationID
                              join ST in _context.WSpaceTypeNames on FP.WSpaceTypeID equals ST.WSpaceTypeID
                              join CT in _context.ChairTypes on FP.ChairTypeID equals CT.ChairTypeID
                              join SM in _context.ScaleMetrics on FP.ScaleMetricID equals SM.ScaleMetricID
                              //where 1 = 1
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
                                  Verification = FP.Verification,
								  Is24 = FP.Is24,
								  SunAvail = FP.SunAvail,
								  SunClose = FP.SunClose,
								  SunOpen = FP.SunOpen,
								  MonAvail = FP.MonAvail,
								  MonClose = FP.MonClose,
								  MonOpen = FP.MonOpen,
								  TueAvail = FP.TueAvail,
								  TueClose = FP.TueClose,
								  TueOpen = FP.TueOpen,
								  WedAvail = FP.WedAvail,
								  WedClose = FP.WedClose,
								  WedOpen = FP.WedOpen,
								  ThuAvail = FP.ThuAvail,
								  ThuClose = FP.ThuClose,
								  ThuOpen = FP.ThuOpen,
								  FriAvail = FP.FriAvail,
								  FriClose = FP.FriClose,
								  FriOpen = FP.FriOpen,
								  SatAvail = FP.SatAvail,
								  SatClose = FP.SatClose,
								  SatOpen = FP.SatOpen
							  });
                return result.ToList();
            }

            //List<ClientWorkSpaceFloorPlan> lst = new List<ClientWorkSpaceFloorPlan>();
            //foreach (var item in _context.ClientWorkSpaceFloorPlans.Where(d => d.ClientLocationID == ClientLocationID))
            //    lst.Add(item);

            //return lst;
            ////return await _context.ClientWorkSpaceFloorPlans.Where(d => d.ClientLocationID == ClientLocationID).ToListAsync();
        }

        // GET: api/Client/1
        [HttpGet("GetClientWorkSpaceFloorPlan/{SpaceFloorPlanID}")]
        public async Task<ActionResult<ClientWorkSpaceFloorPlan>> GetClientWorkSpaceFloorPlan(int SpaceFloorPlanID)
        {
            var clienWorkSpaceFloorPlan = await _context.ClientWorkSpaceFloorPlans.FindAsync(SpaceFloorPlanID);

            if (clienWorkSpaceFloorPlan == null)
            {
                return NotFound();
            }

            return clienWorkSpaceFloorPlan;
        }

        // POST: api/Client
        [HttpPost("AddClientWorkSpaceFloorPlan")]
        public async Task<ActionResult<ClientWorkSpaceFloorPlan>> AddClientWorkSpaceFloorPlan([FromBody] ClientWorkSpaceFloorPlan clientWorkSpaceFloorPlan)
        {
            _context.ClientWorkSpaceFloorPlans.Add(clientWorkSpaceFloorPlan);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClientWorkSpaceFloorPlan", new { SpaceFloorPlanID = clientWorkSpaceFloorPlan.ClientSpaceFloorPlanID }, clientWorkSpaceFloorPlan);
        }

        // PUT: api/Client
        [HttpPost("UpdateClientWorkSpaceFloorPlan")]
        public async Task<IActionResult> UpdateClientWorkSpaceFloorPlan([FromBody]  ClientWorkSpaceFloorPlan clientWorkSpaceFloorPlan)
        {
            if (clientWorkSpaceFloorPlan == null)
            {
                return BadRequest();
            }

            try
            {
                _context.Entry(clientWorkSpaceFloorPlan).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!ClientWorkSpaceFloorPlanExists(SpaceFloorPlanID))
                //{
                //    return NotFound();
                //}
                //else
                //{
                //    throw;
                //}
            }

            return NoContent();
        }

        [HttpGet("ApproveSpace/{ClientSpaceFloorPlanID}/{Status}")]
        public ActionResult<bool> ApproveSpace(int ClientSpaceFloorPlanID, string Status)
        {
            bool result = true;
            if (ClientSpaceFloorPlanID == 0)
            {
                result = false;
            }
            try
            {
                var space = _context.ClientWorkSpaceFloorPlans.SingleOrDefault(d => d.ClientSpaceFloorPlanID == ClientSpaceFloorPlanID);
                if (space != null)
                {
                    space.Verification = Status;
                    _context.Entry(space).State = EntityState.Modified;
                    _context.SaveChangesAsync();
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                result = false;
            }

            return result;
        }

        private bool ClientWorkSpaceFloorPlanExists(int SpaceFloorPlanID)
        {
            return _context.ClientWorkSpaceFloorPlans.Any(e => e.ClientSpaceFloorPlanID == SpaceFloorPlanID);
        }

        // GET: api/Client/1
        [HttpGet("GetWorkSpaceDetails/{ClientSpaceFloorPlanID}")]
        public async Task<ActionResult<WorkSpaceDetailsResponse>> GetWorkSpaceDetails(int ClientSpaceFloorPlanID)
        {
            WorkSpaceDetailsResponse spaceDetails = new WorkSpaceDetailsResponse();

            var space = await _context.ClientWorkSpaceFloorPlans.SingleOrDefaultAsync(m => m.Verification == "Approved" && m.ClientSpaceFloorPlanID == ClientSpaceFloorPlanID);
            if (space == null)
            {
                return NotFound();
            }

            spaceDetails.selectedSpace = space;
            spaceDetails.client = _context.ClientMasters.SingleOrDefault(d => d.ClientID == space.ClientID);
            spaceDetails.location = _context.ClientLocations.SingleOrDefault(d => d.ClientID == space.ClientID && d.ClientLocationID == space.ClientLocationID);
            var flrs = _context.ClientFloors.Where(d => d.Active && d.ClientID == space.ClientID && d.ClientLocationID == space.ClientLocationID).ToList();


            foreach (var flr in flrs)
            {
                ClientFloorDetails clientFloorDetails = new ClientFloorDetails();
                clientFloorDetails.clientFloor = flr;
                clientFloorDetails.clientFloorFacilities = (from CF in _context.ClientFacilities
                                                            join FM in _context.FacilityMasters on CF.FacilityID equals FM.FacilityID
                                                            where CF.ClientID == space.ClientID && CF.ClientFloorID == space.ClientFloorID && CF.Available
                                                            select new ClientFacilityDetails()
                                                            {
                                                                FacilityID = CF.FacilityID,
                                                                FacilityName = FM.FacilityName
                                                            }).ToList();
                List<ClientFloorSpaceDetails> clFlrSpaceDetailsLst = new List<ClientFloorSpaceDetails>();
                ClientFloorSpaceDetails cltFlrDetails = new ClientFloorSpaceDetails();
                var spaces = _context.ClientWorkSpaceFloorPlans.Where(m => m.Verification == "Approved" && m.ClientID == flr.ClientID && m.ClientLocationID == flr.ClientLocationID && m.ClientFloorID == flr.ClientFloorID).ToList();
                foreach (var _space in spaces)
                {
                    cltFlrDetails = new ClientFloorSpaceDetails();
                    cltFlrDetails.clientFloorSpace = _space;
                    cltFlrDetails.clientFloorSpaceSeats = _context.ClientSpaceSeats.Where(d => d.ClientSpaceFloorPlanID == _space.ClientSpaceFloorPlanID).ToList();
                    cltFlrDetails.clientFloorSpaceSeatsCount = cltFlrDetails.clientFloorSpaceSeats.Count();
                    clFlrSpaceDetailsLst.Add(cltFlrDetails);
                }
                clientFloorDetails.clientFloorSpaces = clFlrSpaceDetailsLst;
                spaceDetails.clientFloors.Add(clientFloorDetails);
            }

            return spaceDetails;
        }

        #endregion

        #region ClientSpaceSeat

        /// <summary>
        /// Get defined list of client seats for the given space id
        /// </summary>            
        /// <response code="200">Return list of space seats</response>
        /// <response code="400">Unable to process</response>
        [HttpGet]
        [Route("GetClientSpaceSeats/{ClientSpaceFloorPlanID}")]
        public ActionResult<List<ClientSpaceSeat>> GetClientSpaceSeats(int ClientSpaceFloorPlanID)
        {
            List<ClientSpaceSeat> lst = new List<ClientSpaceSeat>();
            foreach (var item in _context.ClientSpaceSeats.Where(d => d.ClientSpaceFloorPlanID == ClientSpaceFloorPlanID))
                lst.Add(item);

            return lst;

            //return await _context.ClientSpaceSeats.FindAsync
        }

        /// <summary>
        /// Get seat details for the given seat id
        /// </summary>            
        /// <response code="200">Return seat details</response>
        /// <response code="400">Unable to process</response>
        [HttpGet]
        [Route("GetClientSpaceSeat/{ClientSpaceSeatID}")]
        public async Task<ActionResult<ClientSpaceSeat>> GetClientSpaceSeat(int ClientSpaceSeatID)
        {
            var clienFacility = await _context.ClientSpaceSeats.FindAsync(ClientSpaceSeatID);

            if (clienFacility == null)
            {
                return NotFound();
            }

            return clienFacility;
        }

        /// <summary>
        /// Add/update list of client seats with price, description, etc..
        /// </summary>            
        /// <response code="200">Return true or false</response>
        /// <response code="400">Unable to process</response>
        [HttpPost("UpdateClientSpaceSeats")]
        public async Task<ActionResult<bool>> UpdateClientSpaceSeats([FromBody] List<ClientSpaceSeat> clientSpaceSeatList)
        {

            bool result = true;

            if (clientSpaceSeatList == null)
                return false;

            if (clientSpaceSeatList.Count() == 0)
                return false;

            List<ClientSpaceSeat> itemsToDelete = new List<ClientSpaceSeat>();
            using (var _delete = _context.Database.BeginTransaction())
            {
                foreach (var _item in _context.ClientSpaceSeats.Where(d => d.ClientSpaceFloorPlanID == clientSpaceSeatList[0].ClientSpaceFloorPlanID))
                    itemsToDelete.Add(_item);
            }

            using (var trans = _context.Database.BeginTransaction())
            {
                try
                {
                    try
                    {
                        foreach (var item in itemsToDelete)
                        {
                            _context.ClientSpaceSeats.Remove(item);
                        }
                        foreach (var clientSpaceSeat in clientSpaceSeatList)
                        {
                            _context.ClientSpaceSeats.Add(clientSpaceSeat);
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
            //return NoContent();
            return true;
        }

        /// <summary>
        /// Delete list of client seats
        /// </summary>            
        /// <response code="200">Return true or false</response>
        /// <response code="400">Unable to process</response>
        [HttpPut]
        [Route("DeleteClientSpaceSeats")]
        public async Task<ActionResult<bool>> DeleteClientSpaceSeats(List<ClientSpaceSeat> ClientSpaceSeatIDList)
        {
            bool result = true;
            using (var trans = _context.Database.BeginTransaction())
            {
                try
                {
                    foreach (var _seat in ClientSpaceSeatIDList)
                    {
                        if (ClientSpaceSeatExists(_seat.ClientSpaceFloorPlanID, _seat.SeatXCoord, _seat.SeatYCoord))
                        {
                            _context.ClientSpaceSeats.Remove(_seat);
                            await _context.SaveChangesAsync();
                        }
                    }
                    trans.Commit();
                }
                catch (Exception err)
                {
                    result = false;
                    trans.Rollback();
                }
            }

            return result;
        }

        private bool ClientSpaceSeatExists(int ClientSpaceSeatID)
        {
            return _context.ClientSpaceSeats.Any(e => e.ClientSpaceSeatID == ClientSpaceSeatID);
        }

        private bool ClientSpaceSeatExists(int ClientSpaceFloorPlanID, int SeatXCoord, int SeatYCoord)
        {
            return _context.ClientSpaceSeats.Any(e => e.ClientSpaceFloorPlanID == ClientSpaceFloorPlanID && e.SeatXCoord == SeatXCoord && e.SeatYCoord == SeatYCoord);
        }

        #endregion

        #region ClientFloor

        /// <summary>
        /// Get list of client floors for the given client location id
        /// </summary>            
        /// <response code="200">Return list of floors</response>
        /// <response code="400">Unable to process</response>
        [HttpGet]
        [Route("GetClientFloors/{ClientLocationID}")]
        public ActionResult<List<ClientFloor>> GetClientFloors(int ClientLocationID)
        {
            List<ClientFloor> lst = new List<ClientFloor>();
            foreach (var item in _context.ClientFloors.Where(d => d.ClientLocationID == ClientLocationID))
                lst.Add(item);

            return lst;
        }

        /// <summary>
        /// Get client floor details
        /// </summary>            
        /// <response code="200">Return client floor details</response>
        /// <response code="400">Unable to process</response>
        [HttpGet]
        [Route("GetClientFloorDetails/{ClientFloorID}")]
        public ActionResult<ClientFloor> GetClientFloorDetails(int ClientFloorID)
        {
            var flr = _context.ClientFloors.SingleOrDefault(d => d.ClientFloorID == ClientFloorID);
            if (flr == null)
            {
                return NoContent();
            }
            return flr;
        }

        /// <summary>
        /// Add/update list of client floor
        /// </summary>            
        /// <response code="200">Return true or false</response>
        /// <response code="400">Unable to process</response>
        [HttpPost("UpdateClientFloor")]
        public async Task<ActionResult<bool>> UpdateClientFloor([FromBody] ClientFloorRequest clientFloorRequest)
        {
            bool result = true;

            if (clientFloorRequest == null)
                return false;

            if (clientFloorRequest.clientFloor == null)
                return false;

            List<ClientFacility> itemsToDelete = new List<ClientFacility>();

            using (var del_trans = _context.Database.BeginTransaction())
            {
                try
                {
                    var _floor = _context.ClientFloors.SingleOrDefault(d => d.ClientID == clientFloorRequest.clientFloor.ClientID && d.ClientLocationID == clientFloorRequest.clientFloor.ClientLocationID && d.FloorNumber == clientFloorRequest.clientFloor.FloorNumber);
                    if (_floor != null)
                    {
                        foreach (var item in _context.ClientFacilities.Where(d => d.ClientID == clientFloorRequest.clientFloor.ClientID && d.ClientLocationID == clientFloorRequest.clientFloor.ClientLocationID && d.ClientFloorID == _floor.ClientFloorID))
                            itemsToDelete.Add(item);
                    }
                    del_trans.Commit();
                }
                catch (Exception ex)
                {
                    del_trans.Rollback();
                }
            }

            using (var trans = _context.Database.BeginTransaction())
            {
                try
                {
                    try
                    {
                        var _floor = _context.ClientFloors.SingleOrDefault(d => d.ClientID == clientFloorRequest.clientFloor.ClientID && d.ClientLocationID == clientFloorRequest.clientFloor.ClientLocationID && d.FloorNumber == clientFloorRequest.clientFloor.FloorNumber);
                        if (_floor == null)
                        {
                            _context.ClientFloors.Add(clientFloorRequest.clientFloor);
                            await _context.SaveChangesAsync();

                            _floor = clientFloorRequest.clientFloor;
                        }
                        else
                        {
                            _floor.FloorName = clientFloorRequest.clientFloor.FloorName;
                            _floor.FloorNumber = clientFloorRequest.clientFloor.FloorNumber;
                            _floor.FloorPlanFilePath = clientFloorRequest.clientFloor.FloorPlanFilePath;
                            _floor.PaidAmenitiesPrice = clientFloorRequest.clientFloor.PaidAmenitiesPrice;
                            _floor.FloorDescription = clientFloorRequest.clientFloor.FloorDescription;
                            _context.Entry(_floor).State = EntityState.Modified;
                            await _context.SaveChangesAsync();
                        }

                        foreach (var item in itemsToDelete)
                        {
                            _context.ClientFacilities.Remove(item);
                        }

                        await _context.SaveChangesAsync();

                        foreach (var fac in clientFloorRequest.clientFacilities)
                        {
                            var _faci = _context.ClientFacilities.SingleOrDefault(d => d.ClientID == clientFloorRequest.clientFloor.ClientID && d.ClientLocationID == clientFloorRequest.clientFloor.ClientLocationID && d.ClientFloorID == _floor.ClientFloorID && d.FacilityID == fac.FacilityID);
                            if (_faci == null)
                            {
                                fac.ClientFloorID = _floor.ClientFloorID;
                                if (fac.Available)
                                {
                                    _context.ClientFacilities.Add(fac);
                                    await _context.SaveChangesAsync();
                                }
                            }
                            else
                            {
                                _faci.Available = fac.Available;
                                _faci.IsPaidAmenity = fac.IsPaidAmenity;
                                _context.Entry(_faci).State = EntityState.Modified;
                                await _context.SaveChangesAsync();
                            }
                        }
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        trans.Rollback();
                        result = false;
                    }
                    trans.Commit();
                }
                catch (Exception err)
                {
                    trans.Rollback();
                    result = false;
                }
            }
            //return NoContent();
            return result;
        }

        #endregion

        #region Client Space Available Times

        /// <summary>
        /// Get client space available times (Is24Hours working, start & end office times, mon to friday working, etc..)
        /// </summary>            
        /// <response code="200">Return list of space available times</response>
        /// <response code="400">Unable to process</response>
        [HttpPut]
        [Route("GetClientSpaceAvailableTimes/{ClientID}/{ClientSpaceFloorPlanID}")]
        public ActionResult<List<ClientSpaceAvailableTime>> GetClientSpaceAvailableTimes(int ClientID, int ClientSpaceFloorPlanID)
        {
            List<ClientSpaceAvailableTime> lst = new List<ClientSpaceAvailableTime>();
            foreach (var item in _context.ClientSpaceAvailableTimes.Where(d => d.ClientID == ClientID && d.ClientSpaceFloorPlanID == ClientSpaceFloorPlanID))
                lst.Add(item);

            return lst;
            //return await _context.ClientWorkSpaceFloorPlans.Where(d => d.ClientLocationID == ClientLocationID).ToListAsync();
        }

        /// <summary>
        /// Update total views for given space
        /// </summary>            
        /// <response code="200">Return true or false</response>
        /// <response code="400">Unable to process</response>
        [HttpGet]
        [Route("UpdateSpaceTotalViews/{ClientSpaceFloorPlanID}")]
        public async Task<ActionResult<bool>> UpdateSpaceTotalViews(int ClientSpaceFloorPlanID)
        {
            bool rs = true;
            try
            {
                var _space = _context.ClientWorkSpaceFloorPlans.SingleOrDefault(d => d.ClientSpaceFloorPlanID == ClientSpaceFloorPlanID);
                if (_space != null)
                {
                    _space.TotalViews = _space.TotalViews + 1;
                    _context.Entry(_space).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception err)
            {
                rs = false;
            }
            return rs;
        }

        /// <summary>
        /// Enable/Disable the client space
        /// </summary>
        /// <response code="200">Return true or false</response>
        /// <response code="400">Unable to process</response>
        [HttpPut]
        [Route("EnableDisableSpace/{ClientSpaceFloorPlanID}/{IsEnable}")]
        public async Task<ActionResult<bool>> EnableDisableSpace(int ClientSpaceFloorPlanID, bool IsEnable)
        {
            bool rs = true;
            try
            {
                var _space = _context.ClientWorkSpaceFloorPlans.SingleOrDefault(d => d.ClientSpaceFloorPlanID == ClientSpaceFloorPlanID);
                if (_space != null)
                {
                    _space.IsEnable = IsEnable;
                    _context.Entry(_space).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception err)
            {
                rs = false;
            }
            return rs;
        }

        /// <summary>
        /// Add/edit client space available times
        /// </summary>            
        /// <response code="200">Return true or false</response>
        /// <response code="400">Unable to process</response>
        [HttpPost]
        [Route("UpdateClientSpaceAvailableTimes")]
        public async Task<ActionResult<bool>> UpdateClientSpaceAvailableTimes([FromBody] ClientSpaceAvailableTime clientAvailableTime)
        {
            bool rs = true;
            try
            {
                var _availableTime = _context.ClientSpaceAvailableTimes.SingleOrDefault(d => d.ClientID == clientAvailableTime.ClientID && d.ClientFloorID == clientAvailableTime.ClientFloorID && d.ClientSpaceFloorPlanID == clientAvailableTime.ClientSpaceFloorPlanID);
                if (_availableTime != null)
                {
                    _context.Entry(_availableTime).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                }
                else
                {
                    _context.ClientSpaceAvailableTimes.Add(_availableTime);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception err)
            {
                rs = false;
            }
            return rs;
        }

        /// <summary>
        /// Get available seats
        /// </summary>            
        /// <response code="200">Return list of seats</response>
        /// <response code="400">Unable to process</response>
        [HttpGet]
        [Route("GetAvailableSeats")]
        public ActionResult<List<ClientSpaceSeat>> GetAvailableSeats(int ClientSpaceFloorPlanID)
        {
            List<ClientSpaceSeat> _seats = new List<ClientSpaceSeat>();
            try
            {
                _seats = _context.ClientSpaceSeats.Where(d => d.ClientSpaceFloorPlanID == ClientSpaceFloorPlanID && d.SeatStatus == "Available").ToList();
            }
            catch (Exception err)
            {
            }
            return _seats;
        }


        #endregion

        #region ClientMembershipPlan

        /// <summary>
        /// Get list of client membership plans
        /// </summary>            
        /// <response code="200">Return list of floors</response>
        /// <response code="400">Unable to process</response>
        [HttpGet]
        [Route("GetClientMembershipPlans/{ClientID}")]
        public ActionResult<List<ClientMembershipPlan>> GetClientMembershipPlans(int ClientID)
        {
            List<ClientMembershipPlan> lst = new List<ClientMembershipPlan>();
            foreach (var item in _context.ClientMembershipPlans.Where(d => d.ClientID == ClientID))
                lst.Add(item);

            return lst;
        }

        /// <summary>
        /// Get client membership plan details
        /// </summary>            
        /// <response code="200">Return client floor details</response>
        /// <response code="400">Unable to process</response>
        [HttpGet]
        [Route("GetClientMembershipPlanDetails/{ClientMembershipPlanID}")]
        public ActionResult<ClientMembershipPlan> GetClientMembershipPlanDetails(int ClientMembershipPlanID)
        {
            var flr = _context.ClientMembershipPlans.SingleOrDefault(d => d.ClientMembershipPlanID == ClientMembershipPlanID);
            if (flr == null)
            {
                return NoContent();
            }
            return flr;
        }

        /// <summary>
        /// AddEditClientMembershipPlan
        /// </summary>            
        /// <response code="200">Return true or false</response>
        /// <response code="400">Unable to process</response>
        [HttpPost]
        [Route("AddEditClientMembershipPlan")]
        public async Task<ActionResult<ClientMembershipPlan>> AddEditClientMembershipPlan([FromBody] ClientMembershipPlan clientMemPlan)
        {
            using (var trans = _context.Database.BeginTransaction())
            {
                try
                {
                    try
                    {
                        if (clientMemPlan.ClientMembershipPlanID > 0)
                        {
                            clientMemPlan.ModifyDateTime = DateTime.Now;
                            _context.Entry(clientMemPlan).State = EntityState.Modified;
                        }
                        else
                        {
                            clientMemPlan.CreatedDateTime = DateTime.Now;
                            _context.ClientMembershipPlans.Add(clientMemPlan);
                        }

                        await _context.SaveChangesAsync();
                        trans.Commit();
                    }
                    catch (DbUpdateConcurrencyException err)
                    {
                        trans.Rollback();
                    }
                }
                catch (Exception err)
                {
                    trans.Rollback();
                }
            }
            return clientMemPlan;
        }

        /// <summary>
        /// AddClientMembershipPlanHistory
        /// </summary>            
        /// <response code="200">Return true or false</response>
        /// <response code="400">Unable to process</response>
        [HttpPost]
        [Route("AddClientMembershipPlanHistory")]
        public async Task<ActionResult<bool>> AddClientMembershipPlanHistory([FromBody] ClientMembershipPlanHistory clientMemPlanHistory)
        {
            bool result = true;
            using (var trans = _context.Database.BeginTransaction())
            {
                try
                {
                    try
                    {
                        clientMemPlanHistory.CreatedDateTime = DateTime.Now;
                        _context.ClientMembershipPlanHistories.Add(clientMemPlanHistory);

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
        /// AddMembershipPlanHistory
        /// </summary>            
        /// <response code="200">Return true or false</response>
        /// <response code="400">Unable to process</response>
        [HttpGet]
        [Route("AddMembershipPlanHistory/{MemberID}/{ClientMembershipPlanID}")]
        public async Task<ActionResult<bool>> AddMembershipPlanHistory(int MemberID, int ClientMembershipPlanID)
        {
            bool result = true;
            using (var trans = _context.Database.BeginTransaction())
            {
                try
                {
                    try
                    {

                        var memPlan = _context.ClientMembershipPlans.SingleOrDefault(d => d.ClientMembershipPlanID == ClientMembershipPlanID);
                        var member = _context.Members.SingleOrDefault(d => d.MemberID == MemberID);

                        if (memPlan != null && member != null)
                        {
                            var StartedDate = DateTime.Now;
                            DateTime? RenewalAlertDate = null;
                            DateTime? expiryDate = null;

                            if (memPlan.MembershipDurationType == "Hour")
                            {
                                if (memPlan.MembershipDuration != null)
                                {
                                    expiryDate = StartedDate.AddHours(memPlan.MembershipDuration.Value);
                                    RenewalAlertDate = expiryDate.Value.AddHours(-memPlan.RenewalAlertDays.Value);
                                }
                            }
                            else if (memPlan.MembershipDurationType == "Month")
                            {
                                if (memPlan.MembershipDuration != null)
                                {
                                    expiryDate = StartedDate.AddMonths(memPlan.MembershipDuration.Value);
                                    RenewalAlertDate = expiryDate.Value.AddDays(-memPlan.RenewalAlertDays.Value);
                                }
                            }
                            else if (memPlan.MembershipDurationType == "Day")
                            {
                                if (memPlan.MembershipDuration != null)
                                {
                                    expiryDate = StartedDate.AddDays(memPlan.MembershipDuration.Value);
                                    RenewalAlertDate = expiryDate.Value.AddDays(-memPlan.RenewalAlertDays.Value);
                                }
                            }
                            else if (memPlan.MembershipDurationType == "Year")
                            {
                                if (memPlan.MembershipDuration != null)
                                {
                                    expiryDate = StartedDate.AddYears(memPlan.MembershipDuration.Value);
                                    RenewalAlertDate = expiryDate.Value.AddDays(-memPlan.RenewalAlertDays.Value);
                                }
                            }
                            else
                                expiryDate = null;

                            member.MembershipStartedDate = DateTime.Now;
                            member.MembershipExpiryDate = expiryDate;
                            member.RenewalAlertDate = RenewalAlertDate;
                            member.MembershipPriceOnDate = memPlan.Price;
                            member.RenewalAlertDays = memPlan.RenewalAlertDays;
                            member.RenewalAlertDays = 30;
                            member.ModifyDateTime = DateTime.Now;
                            _context.Entry(member).State = EntityState.Modified;

                            MembershipHistory history = new MembershipHistory();
                            history.ClientMembershipPlanID = ClientMembershipPlanID;
                            history.MemberID = MemberID;
                            history.StartedDate = member.MembershipStartedDate;
                            history.ExpiredDate = expiryDate;
                            history.RenewalDate = RenewalAlertDate;
                            history.PriceOnDate = memPlan.Price;
                            history.CreatedDateTime = DateTime.Now;
                            _context.MembershipHistories.Add(history);

                            await _context.SaveChangesAsync();
                            trans.Commit();
                        }
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
        /// GetMembershipPlanHistories
        /// </summary>            
        /// <response code="200">Return list of MembershipHistory</response>
        /// <response code="400">Unable to process</response>
        [HttpGet]
        [Route("GetMembershipPlanHistories/{MemberID}")]
        public async Task<ActionResult<List<MembershipPlanHistoryResponse>>> GetMembershipPlanHistories(int MemberID)
        {
            List<MembershipPlanHistoryResponse> response = new List<MembershipPlanHistoryResponse>();

            response = await (from MH in _context.MembershipHistories
                              join CMP in _context.ClientMembershipPlans on MH.ClientMembershipPlanID equals CMP.ClientMembershipPlanID
                              where MH.MemberID == MemberID
                              orderby CMP.ClientMembershipPlanID descending
                              select new MembershipPlanHistoryResponse()
                              {
                                  MembershipHistoryID = MH.MembershipHistoryID,
                                  MembershipName = CMP.MembershipName,
                                  MembershipDuration = CMP.MembershipDuration,
                                  MembershipDurationType = CMP.MembershipDurationType,
                                  Price = CMP.Price,
                                  Description = CMP.Description,
                                  StartedDate = MH.StartedDate,
                                  ExpiredDate = MH.ExpiredDate,
                                  RenewalDate = MH.RenewalDate,
                                  PriceOnDate = MH.PriceOnDate
                              }).ToListAsync();

            return response;
        }

        #endregion

    }
}
