using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace HiSpaceService.ViewModel
{
    public class ClientLocationSearchResponse
    {
        public int ClientLocationID { set; get; }
        public string ClientLocationName { set; get; }
        public double ClientLocationInUseCount { set; get; }
        public bool IsSelected { set; get; }
    }
}
