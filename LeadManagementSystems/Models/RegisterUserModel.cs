using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LeadManagementSystems.Models
{
    public class RegisterUserModel
    {
        [Required (ErrorMessage ="Please Enter a Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage ="Please Enter a Name ")]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password, ErrorMessage = "Please Enter a valid Password")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password, ErrorMessage = "Please Confirm Correct Password")]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }


        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "Please Enter a valid Email")]
        public string Email { get; set; }

        public string PicturePath { get; set; }

        public HttpPostedFileWrapper ProfilePictureFile { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public string Status { get; set; }
        public bool IsActive { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public int ID { get; set; }
        public Nullable<int> RoleId { get; set; }
        public Nullable<int> EmployeeID { get; set; }
    }
}