using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeadManagementSystems.Models
{
    public class NotificationModel
    {
        public int ID { get; set; }
        public string NotificationText { get; set; }
        public string LinkText { get; set; }
        public Nullable<bool> IsRead { get; set; }
        public Nullable<System.DateTime> dateCreated { get; set; }
        public Nullable<int> N_To { get; set; }
        public Nullable<int> N_from { get; set; }
    }
}