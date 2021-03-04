using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;

namespace LeadManagementSystems.Models
{
    public class Report_Property
    {
        public int? ID { get; set; }
        [Required]
        public string ClientName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> LeadDate { get; set; }


        [Required]
        public Nullable<int> LeadTypeID { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string ContactNo { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        public Nullable<int> TimeZoneID { get; set; }
        [Required]
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
        //[Required(ErrorMessage ="The AssignLead field is required")]

        public Nullable<int> AssignedToUSerID { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<bool> Is_Active { get; set; }
        public string Status { get; set; }
        public Nullable<int> Created_By { get; set; }

        
        public DataTable tbl_Record { get; set; }
    }
}