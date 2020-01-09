using HiSpaceModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace HiSpaceService.ViewModel
{
    public class ClientFloorRequest
    {
        public ClientFloor clientFloor { set; get; }
        public List<ClientFacility> clientFacilities { set; get; }       
    }
}
