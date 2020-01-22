using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HiSpaceModels;
using HiSpaceService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HiSpaceService.Contracts;
using HiSpaceService.ViewModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HiSpaceService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class CommonController : Controller
    {
        private readonly HiSpaceContext _context;

        public CommonController(HiSpaceContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get all user types
        /// </summary>            
        /// <response code="200">Return all user types</response>
        /// <response code="400">Unable to process</response>
        // GET: api/Common
        [Route(template: ApiRoutes.Common.GetAllUserTypes)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserType>>> GetUserTypes()
        {
            return await _context.UserTypes.ToListAsync();
        }

        /// <summary>
        /// Get all work space types
        /// </summary>            
        /// <response code="200">Return all work space types</response>
        /// <response code="400">Unable to process</response>
        // GET: api/Common
        [Route(template: ApiRoutes.Common.GetAllWorkSpaceTypes)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WSpaceType>>> GetWorkSpaceTypes()
        {
            return await _context.WSpaceTypeNames.ToListAsync();
        }

        /// <summary>
        /// Get all amenities by category wise
        /// </summary>            
        /// <response code="200">Return all amenities by category wise</response>
        /// <response code="400">Unable to process</response>
        // GET: api/Common
        [Route(template: ApiRoutes.Common.GetAllAmenities)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FacilityMaster>>> GetFacilities()
        {
            return await _context.FacilityMasters.OrderBy(d => d.CategoryName).ToListAsync();
        }

        /// <summary>
        /// Get all chair types
        /// </summary>            
        /// <response code="200">Return all chair types</response>
        /// <response code="400">Unable to process</response>
        // GET: api/Common
        [Route(template: ApiRoutes.Common.GetAllChairTypes)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChairType>>> GetChairTypes()
        {
            return await _context.ChairTypes.ToListAsync();
        }

        /// <summary>
        /// Get all membership plans
        /// </summary>            
        /// <response code="200">Return all membership plans</response>
        /// <response code="400">Unable to process</response>
        // GET: api/Common
        [Route(template: ApiRoutes.Common.GetAllMembershipPlans)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientMembershipPlan>>> GetMembershipPlans()
        {
            return await _context.ClientMembershipPlans.ToListAsync();
        }

        /// <summary>
        /// Get all scale metrics
        /// </summary>            
        /// <response code="200">Return all scale metrics</response>
        /// <response code="400">Unable to process</response>
        // GET: api/Common
        [Route(template: ApiRoutes.Common.GetAllScaleMetrics)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ScaleMetric>>> GetScaleMetrics()
        {
            return await _context.ScaleMetrics.ToListAsync();
        }

        /// <summary>
        /// Client Notification Pending
        /// </summary>            
        /// <response code="200">Return pending notification</response>
        /// <response code="400">Unable to process</response>
        // GET: api/Common
        [Route(template: ApiRoutes.Common.GetPendingNotification)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PendingNotificationResponse>>> GetPendingNotification(int UserID)
        {
            List<PendingNotificationResponse> notifications = new List<PendingNotificationResponse>();

            var user = _context.UserLogins.SingleOrDefault(d => d.UserID == UserID);
            if (user == null)
                return null;


            if (user.UserType == 1)
            {
                var spaces = _context.ClientWorkSpaceFloorPlans.Where(d => d.Verification == "Pending");
                if (spaces.Count() > 0)
                {
                    notifications.Add(new PendingNotificationResponse()
                    {
                        NotificationID = user.UserID,
                        NotificationName = Notifications.NewSpaceVerificationPending,
                        NotificationDescription = spaces.Count() + " " + Notifications.Names[Notifications.NewSpaceVerificationPending]
                    });
                }

                if (!user.Active)
                {
                    notifications.Add(new PendingNotificationResponse()
                    {
                        NotificationID = user.UserID,
                        NotificationName = Notifications.UserLogin,
                        NotificationDescription = Notifications.Names[Notifications.UserLogin]
                    });
                }
            }

            if (user.UserType == 2 || user.UserType == 3)
            {
                var client = _context.ClientMasters.SingleOrDefault(d => d.ClientID == user.ClientID);

                var spaces = _context.MemberBookingSpaces.Where(d => d.BookingStatus == MemberBookingStatus.Requested && d.ClientID == user.ClientID);
                if (spaces.Count() > 0)
                {
                    notifications.Add(new PendingNotificationResponse()
                    {
                        NotificationID = user.ClientID.Value,
                        NotificationName = Notifications.SpaceBookingRequest,
                        NotificationDescription = spaces.Count() + " " + Notifications.Names[Notifications.SpaceBookingRequest]
                    });
                }

                if (client != null)
                {

                    if (string.IsNullOrEmpty(client.GSTIN) ||
                        string.IsNullOrEmpty(client.PAN) ||
                        string.IsNullOrEmpty(client.UAN) ||
                        string.IsNullOrEmpty(client.ClientLogo) ||
                        string.IsNullOrEmpty(client.Doc_ContactPersonAadhaar) ||
                        string.IsNullOrEmpty(client.Doc_ContactPersonPAN) ||
                        string.IsNullOrEmpty(client.Doc_GSTCopy) ||
                        string.IsNullOrEmpty(client.Doc_MembershipAgreementCopy) ||
                        string.IsNullOrEmpty(client.Doc_PANCopy) ||
                        string.IsNullOrEmpty(client.Doc_RCCopy)
                        )
                    {
                        notifications.Add(new PendingNotificationResponse()
                        {
                            NotificationID = user.ClientID.Value,
                            NotificationName = Notifications.ClientProfilePending,
                            NotificationDescription = Notifications.Names[Notifications.ClientProfilePending]
                        });
                    }

                    if (client.ClientStatus == "Pending")

                        notifications.Add(new PendingNotificationResponse()
                        {
                            NotificationID = user.ClientID.Value,
                            NotificationName = Notifications.ClientVerification,
                            NotificationDescription = Notifications.Names[Notifications.ClientVerification]
                        });
                }
                else
                {
                    notifications.Add(new PendingNotificationResponse()
                    {
                        NotificationID = user.ClientID.Value,
                        NotificationName = Notifications.ClientProfilePending,
                        NotificationDescription = Notifications.Names[Notifications.ClientProfilePending]
                    });
                }

                var floor = _context.ClientFloors.Where(d => d.ClientID == user.ClientID);
                if (floor.Count() == 0)
                    notifications.Add(new PendingNotificationResponse()
                    {
                        NotificationID = user.ClientID.Value,
                        NotificationName = Notifications.ClientFloor,
                        NotificationDescription = Notifications.Names[Notifications.ClientFloor]
                    });

                var location = _context.ClientLocations.Where(d => d.ClientID == user.ClientID);
                if (location.Count() == 0)
                    notifications.Add(new PendingNotificationResponse()
                    {
                        NotificationID = user.ClientID.Value,
                        NotificationName = Notifications.ClientLocation,
                        NotificationDescription = Notifications.Names[Notifications.ClientLocation]
                    });

                var space = _context.ClientWorkSpaceFloorPlans.Where(d => d.ClientID == user.ClientID);
                if (space.Count() == 0)
                    notifications.Add(new PendingNotificationResponse()
                    {
                        NotificationID = user.ClientID.Value,
                        NotificationName = Notifications.ClientSpace,
                        NotificationDescription = Notifications.Names[Notifications.ClientSpace]
                    });
            }

            if (user.UserType == 4)
            {
                var member = _context.Members.SingleOrDefault(d => d.MemberID == user.MemberID);
                if (member == null)
                {

                    if (string.IsNullOrEmpty(member.GSTIN) ||
                        string.IsNullOrEmpty(member.PAN) ||
                        string.IsNullOrEmpty(member.UAN) ||
                        string.IsNullOrEmpty(member.Doc_ContactPersonAadhaar) ||
                        string.IsNullOrEmpty(member.Doc_ContactPersonPAN) ||
                        string.IsNullOrEmpty(member.Doc_RCCopy)
                        )
                    {
                        notifications.Add(new PendingNotificationResponse()
                        {
                            NotificationID = user.MemberID.Value,
                            NotificationName = Notifications.MemberProfilePending,
                            NotificationDescription = Notifications.Names[Notifications.MemberProfilePending]
                        });
                    }

                    if (!member.MemberStatus)

                        notifications.Add(new PendingNotificationResponse()
                        {
                            NotificationID = user.MemberID.Value,
                            NotificationName = Notifications.MemberNotActivated,
                            NotificationDescription = Notifications.Names[Notifications.MemberNotActivated]
                        });
                }
            }

            return notifications;
        }

        /// <summary>
        /// Get all client locations with usage count
        /// </summary>            
        /// <response code="200">Return all client locations with usage count</response>
        /// <response code="400">Unable to process</response>
        // GET: api/Common
        [Route(template: ApiRoutes.Common.GetAllClientLocationSearch)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientLocationSearchResponse>>> GetAllClientLocationSearch()
        {
            List<ClientLocationSearchResponse> response = new List<ClientLocationSearchResponse>();
            var locations = await _context.ClientLocations.OrderBy(d => d.ClientLocationName).ToListAsync();
            foreach (var item in locations)
            {
                response.Add(new ClientLocationSearchResponse()
                {
                    ClientLocationID = item.ClientLocationID,
                    ClientLocationName = item.ClientLocationName,
                    ClientLocationInUseCount = _context.ClientLocations.Count(d => d.ClientLocationID == item.ClientLocationID)
                });
            }
            return response;
        }

        /// <summary>
        /// Get all amenities by category wise with usage count
        /// </summary>            
        /// <response code="200">Return all amenities by category wise with usage count</response>
        /// <response code="400">Unable to process</response>
        // GET: api/Common
        [Route(template: ApiRoutes.Common.GetAllAmenitiesSearch)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AmenitiesSearchResponse>>> GetAllAmenitiesSearch()
        {
            List<AmenitiesSearchResponse> response = new List<AmenitiesSearchResponse>();
            var amenities = await _context.FacilityMasters.OrderBy(d => d.CategoryName).ToListAsync();
            foreach (var item in amenities)
            {
                response.Add(new AmenitiesSearchResponse()
                {
                    FacilityID = item.FacilityID,
                    FacilityName = item.FacilityName,
                    CategoryName = item.CategoryName,
                    FacilityInUseCount = _context.ClientFacilities.Count(d => d.FacilityID == item.FacilityID)
                });
            }
            return response;
        }

        /// <summary>
        /// Get all work space types with usage count
        /// </summary>            
        /// <response code="200">Return all work space types with usage count</response>
        /// <response code="400">Unable to process</response>
        // GET: api/Common
        [Route(template: ApiRoutes.Common.GetAllWorkSpaceTypesSearch)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WorkSpaceTypeSearchResponse>>> GetAllWorkSpaceTypesSearch()
        {
            List<WorkSpaceTypeSearchResponse> response = new List<WorkSpaceTypeSearchResponse>();
            var locations = await _context.WSpaceTypeNames.OrderBy(d => d.WSpaceTypeName).ToListAsync();
            foreach (var item in locations)
            {
                response.Add(new WorkSpaceTypeSearchResponse()
                {
                    WSpaceTypeID = item.WSpaceTypeID,
                    WSpaceTypeName = item.WSpaceTypeName,
                    WSpaceTypeInUseCount = _context.ClientWorkSpaceFloorPlans.Count(d => d.WSpaceTypeID == item.WSpaceTypeID)
                });
            }
            return response;
        }
    }
}
