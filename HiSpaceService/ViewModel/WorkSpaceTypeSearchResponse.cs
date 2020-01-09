using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace HiSpaceService.ViewModel
{
    public class WorkSpaceTypeSearchResponse
    {
        public int WSpaceTypeID { set; get; }
        public string WSpaceTypeName { set; get; }
        public double WSpaceTypeInUseCount { set; get; }
        public bool IsSelected { set; get; }
    }
}
