//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LeadManagementSystems
{
    using System;
    using System.Collections.Generic;
    
    public partial class notification
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
