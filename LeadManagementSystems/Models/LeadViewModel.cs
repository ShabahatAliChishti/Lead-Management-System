using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LeadManagementSystems.Models
{
    public class LeadViewModel
    {
        public int LeadID { get; set; }
        [Required]
        public string ClientName { get; set; }
       
        public Nullable<System.DateTime> LeadDate { get; set; }
     
        public Nullable<int> LeadTypeID { get; set; }
       
        public string LeadTypeName { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }
       
        public Nullable<int> TimeZoneID { get; set; }
        public string TimeZoneName { get; set; }
        public string Location { get; set; }
        public string IPAddress { get; set; }
        [Required]
        public string LeadTime { get; set; }
        public Nullable<bool> LeadStatus { get; set; }
        public Nullable<decimal> Budget { get; set; }
        [Required]
        public string NextPlan { get; set; }
        public string LastStatus { get; set; }
        public string IntialRequirements { get; set; }
        public Nullable<int> AssignedToUSerID { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<bool> Is_Active { get; set; }
        public string Status { get; set; }
        public Nullable<int> Created_By { get; set; }
        public String UserName { get; set; }
    }
}