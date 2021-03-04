using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LeadManagementSystems.Models
{
    public class UserModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public string Status { get; set; }
        public bool IsActive { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public int ID { get; set; }
        public Nullable<int> RoleId { get; set; }
        public Nullable<int> EmployeeID { get; set; }
    }
}