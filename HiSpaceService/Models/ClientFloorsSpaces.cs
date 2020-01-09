
using HiSpaceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HiSpaceService.Models
{
    public class ClientFloorsSpaces
    {
        public ClientFloorsSpaces()
        {
            floorSpaces = new List<ClientWorkSpaceFloorPlan>();
        }

        public int ClientFloorID { set; get; }
        public int? ClientID { set; get; }
        public int? ClientLocationID { set; get; }
        public int? FloorNumber { set; get; }
        public string FloorName { set; get; }
        public string FloorPlanFilePath { set; get; }
        public double? PaidAmenitiesPrice { set; get; }
        public string FloorDescription { set; get; }
        public bool Active { set; get; }

        public List<ClientWorkSpaceFloorPlan> floorSpaces { set; get; }
    }
}
