using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace HiSpaceService.ViewModel
{
    public class UserLoginResponse
    {
        public int UserID { set; get; }
        public string Username { set; get; }
        public string Password { set; get; }
        public int UserType { set; get; }
        public string UserTypeName { set; get; }
        public bool Active { set; get; }
        public int? MemberID { set; get; }
        public string MemberName { set; get; }
        public int? ClientID { set; get; }
        public string ClientName { set; get; }
        public int? ClientLocationID { set; get; }
        public string ClientLocationName { set; get; }
        public DateTime? LastLoginDateTime { set; get; }
        public Int64? LoginCount { set; get; }
        public int? CreatedBy { set; get; }
        public string CreatedByName { set; get; }
        public DateTime? CreatedDateTime { set; get; }
        public int? ModifyBy { set; get; }
        public string ModifyByName { set; get; }
        public DateTime? ModifyDateTime { set; get; }
    }
}
