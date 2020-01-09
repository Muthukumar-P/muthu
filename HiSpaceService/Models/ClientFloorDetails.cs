
using HiSpaceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HiSpaceService.Models
{
    public class ClientFloorDetails
    {
        public ClientFloorDetails()
        {
            clientFloor = new ClientFloor();
            clientFloorSpaces = new List<ClientFloorSpaceDetails>();
            clientFloorFacilities = new List<ClientFacilityDetails>();
        }

        public ClientFloor clientFloor { set; get; }
        public List<ClientFloorSpaceDetails> clientFloorSpaces { set; get; }
        public List<ClientFacilityDetails> clientFloorFacilities { set; get; }        
    }
}
