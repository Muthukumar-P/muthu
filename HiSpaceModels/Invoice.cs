using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HiSpaceModels
{    
    [Table("Invoice")]
    public class Invoice
    {
        [Key]
        public int InvoiceID { set; get; }

        public double ? SeatCost { set; get; }
        
        public double ? SpaceCost { get; set; }

        public double ? FacilitiesTotal {get; set;} 
        
        public double ? GST {get; set;}

        public double ? TotalCost {get; set;}

        public int MemberBookingSpaceID { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
