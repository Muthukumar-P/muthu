using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HiSpaceService.Contracts
{
    public static class ApiRoutes
    {
        public static class Client
        {

        }

        public static class Common
        {
            public const string GetAllUserTypes = "GetAllUserTypes";
            public const string GetAllWorkSpaceTypes = "GetAllWorkSpaceTypes";
            public const string GetAllAmenities = "GetAllAmenities";
            public const string GetAllChairTypes = "GetAllChairTypes";
            public const string GetAllMembershipPlans = "GetAllMembershipPlans";
            public const string GetAllScaleMetrics = "GetAllScaleMetrics";
            public const string GetPendingNotification = "GetPendingNotification/{UserID}";
            public const string GetAllClientLocationSearch = "GetAllClientLocationSearch";
            public const string GetAllAmenitiesSearch = "GetAllAmenitiesSearch";
            public const string GetAllWorkSpaceTypesSearch = "GetAllWorkSpaceTypesSearch";

        }
    }    

    public static class Notifications
    {
        public static Dictionary<string, string> Names = new Dictionary<string, string>();

        #region declare notification names

        public const string NewSpaceVerificationPending = "NewSpaceVerificationPending";
        public const string UserLogin = "UserLogin";
        public const string SpaceBookingRequest = "SpaceBookingRequest";
        public const string ClientProfilePending = "ClientProfilePending";
        public const string ClientVerification = "ClientVerification";
        public const string ClientFloor = "ClientFloor";
        public const string ClientLocation = "ClientLocation";
        public const string ClientSpace = "ClientSpace";
        public const string MemberProfilePending = "MemberProfilePending";
        public const string MemberNotActivated = "MemberNotActivated";

        #endregion

        static Notifications()
        {
            #region defining notification descriptions

            Names.Add(NewSpaceVerificationPending, "New spaces are not verified");
            Names.Add(UserLogin, "Logged User Not Activated");
            Names.Add(SpaceBookingRequest, "New Bookings are requested");
            Names.Add(ClientProfilePending, "Client profile pending");
            Names.Add(ClientVerification, "Client verification pending");
            Names.Add(ClientFloor, "Floor setup is not done");
            Names.Add(ClientLocation, "Location setup is not done");
            Names.Add(ClientSpace, "Space setup is not done");
            Names.Add(MemberProfilePending, "Member profile pending");
            Names.Add(MemberNotActivated, "Member not activated");

            #endregion
        }

    }

    public static class VerificationStatus
    {
        public const string Pending = "Pending";
        public const string Approved = "Approved";
    }

    public static class MemberBookingStatus
    {
        public const string Requested = "Requested";
        public const string Approved = "Approved";
        public const string Rejected = "Rejected";
    }

    public static class ClientBookingStatus
    {
        public const string Available = "Available";
        public const string Partial = "Partial";
        public const string Unavailable = "Unavailable";
        public const string Occupied = "Booked";
    }

}
