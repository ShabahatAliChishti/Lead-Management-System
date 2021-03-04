using LeadManagementSystems.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeadManagementSystems.Controllers
{
    public class BaseController : Controller
    {
        LeadCRMEntities db = new LeadCRMEntities();
        // GET: Base

        //Session["UserId"] = User.ID;
        //                Session["EmployeeID"] = User.EmployeeID;
        //                Session["RoleID"] = User.RoleId;
        public void GetLeadType()
        {
        //    List<LeadType> Ltype = db.LeadTypes.Where(p => p.Is_Active == true).ToList();
        //    LeadType objltype = new LeadType();
        //    objltype.LeadTypeName = "select Lead Type";
        //    objltype.ID = 0;
        //    Ltype.Add(objltype);
           
            ViewBag.LeadType = db.LeadTypes.Where(p => p.Is_Active == true).ToList();
           

            //for(int i = 0; i < Ltype.co; i++)
            //{
            //    Ltype.Add(ViewBag.LeadType[i]);
            //}
            // ViewBag.LeadType = Ltype.OrderByDescending(p=>p.ID);
        }
        public void GetTimeZone()
        {
            ViewBag.TimeZone = db.TimeZones.Where(p => p.Is_Active == true).ToList();
        }
        public void GetUser()
        {
            ViewBag.User = db.USERs.Where(p => p.IsActive == true).ToList();
        }

        public void GetActiveLeadsForDashboard()
        {
            if (Session["RoleID"].ToString() == "1")
            {
                ViewBag.ActiveLeadsForDashboard = (from tbllead in db.Leads
                                                   join tblleadtype in db.LeadTypes on tbllead.LeadType equals tblleadtype.ID
                                                   join tbltimezone in db.TimeZones on tbllead.TimeZone equals tbltimezone.ID
                                                   where tbllead.LeadStatus == true && tbllead.Is_Active == true 
                                                   select new LeadViewModel()
                                                   {
                                                       LeadID = tbllead.ID,
                                                       LeadDate = tbllead.LeadDate,
                                                       LeadTime = tbllead.LeadTime,
                                                       LeadTypeID = tblleadtype.ID,
                                                       LeadTypeName = tblleadtype.LeadTypeName,
                                                       ClientName = tbllead.ClientName,
                                                       ContactNo = tbllead.ContactNo,
                                                       Email = tbllead.Email,
                                                       TimeZoneID = tbltimezone.ID,
                                                       TimeZoneName = tbltimezone.TimeZone1,

                                                   }).OrderByDescending(p=>p.LeadID).Take(5).ToList();
            }
            else
            {
                int userid=Convert.ToInt32(Session["UserId"].ToString());
                ViewBag.ActiveLeadsForDashboard = (from tbllead in db.Leads
                                                   join tblleadtype in db.LeadTypes on tbllead.LeadType equals tblleadtype.ID
                                                   join tbltimezone in db.TimeZones on tbllead.TimeZone equals tbltimezone.ID
                                                   where tbllead.LeadStatus == true && tbllead.Is_Active == true && tbllead.AssignedToUSerID==userid
                                                   select new LeadViewModel()
                                                   {
                                                       LeadID = tbllead.ID,
                                                       LeadDate = tbllead.LeadDate,
                                                       LeadTime = tbllead.LeadTime,
                                                       LeadTypeID = tblleadtype.ID,
                                                       LeadTypeName = tblleadtype.LeadTypeName,
                                                       ClientName = tbllead.ClientName,
                                                       ContactNo = tbllead.ContactNo,
                                                       Email = tbllead.Email,
                                                       TimeZoneID = tbltimezone.ID,
                                                       TimeZoneName = tbltimezone.TimeZone1,

                                                   }).OrderByDescending(p => p.LeadID).Take(5).ToList();
            }
        }

        public void GetCloseLeadsForDashboard()
        {
            if (Session["RoleID"].ToString() == "1")
            {
                ViewBag.CloseLeadsForDashboard = (from tbllead in db.Leads
                                                   join tblleadtype in db.LeadTypes on tbllead.LeadType equals tblleadtype.ID
                                                   join tbltimezone in db.TimeZones on tbllead.TimeZone equals tbltimezone.ID
                                                   where tbllead.LeadStatus == false && tbllead.Is_Active == true
                                                   select new LeadViewModel()
                                                   {
                                                       LeadID = tbllead.ID,
                                                       LeadDate = tbllead.LeadDate,
                                                       LeadTime = tbllead.LeadTime,
                                                       LeadTypeID = tblleadtype.ID,
                                                       LeadTypeName = tblleadtype.LeadTypeName,
                                                       ClientName = tbllead.ClientName,
                                                       ContactNo = tbllead.ContactNo,
                                                       Email = tbllead.Email,
                                                       TimeZoneID = tbltimezone.ID,
                                                       TimeZoneName = tbltimezone.TimeZone1,

                                                   }).OrderByDescending(p => p.LeadID).Take(5).ToList();
            }
            else
            {
                int userid = Convert.ToInt32(Session["UserId"].ToString());
                ViewBag.CloseLeadsForDashboard = (from tbllead in db.Leads
                                                   join tblleadtype in db.LeadTypes on tbllead.LeadType equals tblleadtype.ID
                                                   join tbltimezone in db.TimeZones on tbllead.TimeZone equals tbltimezone.ID
                                                   where tbllead.LeadStatus == false && tbllead.Is_Active == true && tbllead.AssignedToUSerID == userid
                                                   select new LeadViewModel()
                                                   {
                                                       LeadID = tbllead.ID,
                                                       LeadDate = tbllead.LeadDate,
                                                       LeadTime = tbllead.LeadTime,
                                                       LeadTypeID = tblleadtype.ID,
                                                       LeadTypeName = tblleadtype.LeadTypeName,
                                                       ClientName = tbllead.ClientName,
                                                       ContactNo = tbllead.ContactNo,
                                                       Email = tbllead.Email,
                                                       TimeZoneID = tbltimezone.ID,
                                                       TimeZoneName = tbltimezone.TimeZone1,

                                                   }).OrderByDescending(p => p.LeadID).Take(5).ToList();
            }
        }


        public void GetFollowUpLeadsForDashboard()
        {
            DateTime dt = DateTime.Now;
            DateTime dateOnly = dt.Date;
            if (Session["RoleID"].ToString() == "1")
            {
                ViewBag.FollowUpLeadsForDashboard = (from tbllead in db.Leads
                                                   join tblleadtype in db.LeadTypes on tbllead.LeadType equals tblleadtype.ID
                                                   join tbltimezone in db.TimeZones on tbllead.TimeZone equals tbltimezone.ID
                                                   where tbllead.LeadDate == dateOnly && tbllead.Is_Active == true
                                                     select new LeadViewModel()
                                                   {
                                                       LeadID = tbllead.ID,
                                                       LeadDate = tbllead.LeadDate,
                                                       LeadTime = tbllead.LeadTime,
                                                       LeadTypeID = tblleadtype.ID,
                                                       LeadTypeName = tblleadtype.LeadTypeName,
                                                       ClientName = tbllead.ClientName,
                                                       ContactNo = tbllead.ContactNo,
                                                       Email = tbllead.Email,
                                                       TimeZoneID = tbltimezone.ID,
                                                       TimeZoneName = tbltimezone.TimeZone1,

                                                   }).OrderByDescending(p => p.LeadID).Take(5).ToList();
            }
            else
            {
                int userid = Convert.ToInt32(Session["UserId"].ToString());
                ViewBag.FollowUpLeadsForDashboard = (from tbllead in db.Leads
                                                   join tblleadtype in db.LeadTypes on tbllead.LeadType equals tblleadtype.ID
                                                   join tbltimezone in db.TimeZones on tbllead.TimeZone equals tbltimezone.ID
                                                   where tbllead.LeadDate == dateOnly && tbllead.AssignedToUSerID == userid && tbllead.Is_Active == true
                                                     select new LeadViewModel()
                                                   {
                                                       LeadID = tbllead.ID,
                                                       LeadDate = tbllead.LeadDate,
                                                       LeadTime = tbllead.LeadTime,
                                                       LeadTypeID = tblleadtype.ID,
                                                       LeadTypeName = tblleadtype.LeadTypeName,
                                                       ClientName = tbllead.ClientName,
                                                       ContactNo = tbllead.ContactNo,
                                                       Email = tbllead.Email,
                                                       TimeZoneID = tbltimezone.ID,
                                                       TimeZoneName = tbltimezone.TimeZone1,

                                                   }).OrderByDescending(p => p.LeadID).Take(5).ToList();
            }
        }

        public void AddNotification(NotificationModel nmodel)
        {
            notification nm = new notification();
            nm.NotificationText = nmodel.NotificationText;
            nm.N_To = nmodel.N_To;
            nm.N_from = nmodel.N_from;
            nm.IsRead = false;
            nm.dateCreated = DateTime.Now;
            db = new LeadCRMEntities();
            db.notifications.Add(nm);
            db.SaveChanges();
        }
        //public ActionResult contact()
        //{

        //    return View();
        //}
        public JsonResult ViewNotification()
        {
            int userid =Convert.ToInt32(Session["UserId"].ToString());
            var notifications = db.notifications.Where(p => p.N_To == userid && p.IsRead==false).OrderByDescending(p => p.ID).ToList();
            return Json(new {data= notifications }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult DeleteNotification()
        {
            int userid = Convert.ToInt32(Session["UserId"].ToString());
            var notifications = db.notifications.Where(p => p.N_To == userid && p.IsRead == false).OrderByDescending(p => p.ID).ToList();
            foreach(notification n in notifications)
            {
                n.IsRead = true;
                db.Entry(n).State = System.Data.EntityState.Modified;
                db.SaveChanges();
            }
            
            return Json(new {code = 200}, JsonRequestBehavior.AllowGet);
        }
    }
}