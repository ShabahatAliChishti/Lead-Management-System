using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LeadManagementSystems.Models
{
    public class LeadModel
    {
        public int? ID { get; set; }

        [Required(ErrorMessage ="Please Enter Client Name")]
        [RegularExpression(@"^(([A-za-z]+[\s]{1}[A-za-z]+)|([A-Za-z]+))$",ErrorMessage ="Client Name can not be a Number or a Special Case Character")]
        public string ClientName { get; set; }

        [Required(ErrorMessage ="Please Enter a valid Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> LeadDate { get; set; }
        

        [Required(ErrorMessage = "Please Enter a Lead Type")]
        public Nullable<int> LeadTypeID { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Please Enter a Contact Number")]
        public string ContactNo { get; set; }
        [Required(ErrorMessage = "Please Enter a valid Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please Select a Time Zone")]
        public Nullable<int> TimeZoneID { get; set; }
        [Required(ErrorMessage = "Please Enter a Location")]
        public string Location { get; set; }
        public string IPAddress { get; set; }
        [Required(ErrorMessage = "Please Enter a valid Time")]
        public string LeadTime { get; set; }
        public Nullable<bool> LeadStatus { get; set; }
        public Nullable<decimal> Budget { get; set; }
        [Required(ErrorMessage = "Please Enter a Next Plan")]
        public string NextPlan { get; set; }
        public string LastStatus { get; set; }
        public string IntialRequirements { get; set; }
        //[Required(ErrorMessage ="The AssignLead field is required")]
        
        public Nullable<int> AssignedToUSerID { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<bool> Is_Active { get; set; }
        public string Status { get; set; }
        public Nullable<int> Created_By { get; set; }

        public int Year { get; set; }
        

    }
}