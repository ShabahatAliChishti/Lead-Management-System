using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LeadManagementSystems.Models
{
    public class LeadTypeModel
    {
        public int ID { get; set; }
        [Required(ErrorMessage ="Lead Type is Required")]
        public string LeadTypeName { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<bool> Is_Active { get; set; }
        public string Status { get; set; }
        public Nullable<int> Created_By { get; set; }
    }
}