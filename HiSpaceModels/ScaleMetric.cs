using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HiSpaceModels
{
    [Table("ScaleMetric")]
    public class ScaleMetric
    {
        [Key]
        public int ScaleMetricID { set; get; }

        public string ScaleMetricName { set; get; }
       
    }
}
