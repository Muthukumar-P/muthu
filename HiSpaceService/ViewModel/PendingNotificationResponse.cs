using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace HiSpaceService.ViewModel
{
    public class PendingNotificationResponse
    {   
        public int NotificationID { set; get; }
        public string NotificationName { set; get; }
        public string NotificationDescription { set; get; }        
    }
}
