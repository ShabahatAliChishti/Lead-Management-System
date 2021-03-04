using LeadManagementSystems.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace LeadManagementSystems.Controllers
{
    public class LeadController : BaseController
    {
        // GET: Lead
        LeadCRMEntities db = new LeadCRMEntities();
        // GET: User
        public ActionResult AddLead()
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                GetLeadType();
                GetTimeZone();
                GetUser();
                return View();
            }

        }

        [HttpPost]
        public JsonResult AddNewLead(LeadModel newlead)
        {
            if (Session["UserId"] == null)
            {
                return Json(new { status = "Ok", code = 401, msg = "Unauthorized Access", data = "" }, JsonRequestBehavior.AllowGet);

            }
            else
            {

                #region AddLead

                //checking validation 
                //if (ModelState.IsValid)
                //{
                try
                {
                    if (newlead.ID <= 0 || newlead.ID == null)
                    {
                        //assigning form data to table model
                        var newleadrgstr = new Lead();
                        newleadrgstr.ClientName = newlead.ClientName;
                        newleadrgstr.LeadDate = newlead.LeadDate;
                        newleadrgstr.LeadTime = newlead.LeadTime;
                        newleadrgstr.LeadType = newlead.LeadTypeID;
                        newleadrgstr.ContactNo = newlead.ContactNo;
                        newleadrgstr.Email = newlead.Email;
                        newleadrgstr.TimeZone = newlead.TimeZoneID;
                        newleadrgstr.Location = newlead.Location;
                        newleadrgstr.IPAddress = newlead.IPAddress;
                        newleadrgstr.LeadStatus = newlead.LeadStatus;
                        newleadrgstr.Budget = newlead.Budget;
                        newleadrgstr.NextPlan = newlead.NextPlan;
                        newleadrgstr.LastStatus = newlead.LastStatus;
                        newleadrgstr.IntialRequirements = newlead.IntialRequirements;
                        newleadrgstr.AssignedToUSerID = newlead.AssignedToUSerID;
                        newleadrgstr.DateCreated = DateTime.Now;
                        newleadrgstr.Is_Active = true;
                        newleadrgstr.Status = "Active";
                        newleadrgstr.Created_By = Convert.ToInt32(Session["UserId"]);

                        //var adminId = Convert.ToInt32(Session["UserId"].ToString());

                        //var user = db.USERs.Where(c => c.ID == newlead.AssignedToUSerID).FirstOrDefault();
                        ////var admin = db.USERs.Where(c => c.ID == adminId).FirstOrDefault();
                        //var mes = "Dear " + user.UserName + " a lead has been assigned to you";
                        
                        //var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
                        //var message = new MailMessage();
                        //message.To.Add(new MailAddress(user.Email));  // replace with valid value 
                        //message.From = new MailAddress("rashid.rahim@appicoders.com");  // replace with valid value
                        //message.Subject = "You have been assigned a Lead";
                        //message.Body = string.Format(body, "Rashid Rahim", "rashid.rahim@appicoders.com", mes);
                        //message.IsBodyHtml = true;

                        //using (var smtp = new SmtpClient())
                        //{
                        //    var credential = new NetworkCredential
                        //    {
                        //        UserName = "rashid.rahim@appicoders.com",  // replace with valid value
                        //        Password = "password"  // replace with valid value
                        //    };
                        //    smtp.Credentials = credential;
                        //    smtp.Host = "smtp-mail.outlook.com";
                        //    smtp.Port = 587;
                        //    smtp.EnableSsl = true;
                        //    smtp.SendMailAsync(message);
                            
                        //}

                        //insert to daatbase
                        db.Leads.Add(newleadrgstr);
                        db.SaveChanges();

                        NotificationModel nm = new NotificationModel();
                        nm.N_To = newlead.AssignedToUSerID;
                        nm.NotificationText = "You have Assigned to New Lead";
                        nm.N_from = Convert.ToInt32(Session["UserId"]);
                        nm.IsRead = false;
                        nm.dateCreated = DateTime.Now;
                        AddNotification(nm);

                    }
                    else
                    {
                        if (Convert.ToInt32(Session["RoleID"]) == 1)
                        {
                            var result = db.Leads.SingleOrDefault(b => b.ID == newlead.ID);
                            if (result != null)
                            {
                                result.ClientName = newlead.ClientName;
                                result.LeadDate = newlead.LeadDate;
                                result.LeadTime = newlead.LeadTime;
                                result.LeadType = newlead.LeadTypeID;
                                result.ContactNo = newlead.ContactNo;
                                result.Email = newlead.Email;
                                result.TimeZone = newlead.TimeZoneID;
                                result.Location = newlead.Location;
                                result.IPAddress = newlead.IPAddress;
                                result.LeadStatus = newlead.LeadStatus;
                                result.Budget = newlead.Budget;
                                result.NextPlan = newlead.NextPlan;
                                result.LastStatus = newlead.LastStatus;
                                result.IntialRequirements = newlead.IntialRequirements;
                                result.AssignedToUSerID = newlead.AssignedToUSerID;
                                result.DateCreated = DateTime.Now;
                                result.Is_Active = true;
                                result.Status = "Active";
                                result.Created_By = Convert.ToInt32(Session["UserId"]);
                                db.SaveChanges();

                                NotificationModel nm = new NotificationModel();
                                nm.N_To = newlead.AssignedToUSerID;
                                nm.NotificationText = "Lead has been Edited";
                                nm.N_from = Convert.ToInt32(Session["UserId"]);
                                nm.IsRead = false;
                                nm.dateCreated = DateTime.Now;
                                AddNotification(nm);


                            }
                        }
                        else
                        {
                            var result = db.Leads.SingleOrDefault(b => b.ID == newlead.ID);
                            if (result != null)
                            {
                                result.ClientName = newlead.ClientName;
                                result.LeadDate = newlead.LeadDate;
                                result.LeadTime = newlead.LeadTime;
                                result.LeadType = newlead.LeadTypeID;
                                result.ContactNo = newlead.ContactNo;
                                result.Email = newlead.Email;
                                result.TimeZone = newlead.TimeZoneID;
                                result.Location = newlead.Location;
                                result.IPAddress = newlead.IPAddress;
                                result.LeadStatus = newlead.LeadStatus;
                                result.Budget = newlead.Budget;
                                result.NextPlan = newlead.NextPlan;
                                result.LastStatus = newlead.LastStatus;
                                result.IntialRequirements = newlead.IntialRequirements;
                                result.AssignedToUSerID = newlead.AssignedToUSerID;
                                result.DateCreated = DateTime.Now;
                                result.Is_Active = true;
                                result.Status = "Active";
                                result.Created_By = Convert.ToInt32(Session["UserId"]);
                                db.SaveChanges();

                                // use fro notification for all Admin Roles
                                db = new LeadCRMEntities();
                                var adminslist = db.USERs.Where(p => p.RoleId == 1).ToList();
                                for (int i = 0; i < adminslist.Count; i++)
                                {
                                    NotificationModel nm = new NotificationModel();
                                    nm.N_To = adminslist[i].ID;
                                    nm.NotificationText = "Lead has been Edited";
                                    nm.N_from = Convert.ToInt32(Session["UserId"]);
                                    nm.IsRead = false;
                                    nm.dateCreated = DateTime.Now;
                                    AddNotification(nm);
                                }
                            }

                        }

                    }
                    return Json(new { status = "Ok", code = 200, msg = "No User Found", data = "" }, JsonRequestBehavior.AllowGet);

                }
                catch (Exception ex)
                {
                    //if any error 
                    return Json(new { status = "Bad Gateway", code = 400, msg = "Failed" + ex.Message, data = "" }, JsonRequestBehavior.AllowGet);
                }
                //}
                //else
                //{


                //    //foreach (var eve in ModelState.EntityValidationErrors)
                //    //{
                //    //    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                //    //        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                //    //    foreach (var ve in eve.ValidationErrors)
                //    //    {
                //    //        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                //    //            ve.PropertyName, ve.ErrorMessage);
                //    //    }
                //    //}



                //    //Validation Failed
                //    return Json(new { status = "Bad Gateway", code = 400, msg = "Validation Failed", data = "" }, JsonRequestBehavior.AllowGet);

            //}
            #endregion
        }
    }

        // api for external Website
        [HttpPost]
        public JsonResult AddLeadFromOtherSource(LeadModel newlead)
        {
            if (ModelState.IsValid)
            {
                #region Addlead fRom Other Source
                try
                {

                    //assigning form data to table model
                    var newleadrgstr = new Lead();
                    newleadrgstr.ClientName = newlead.ClientName;
                    newleadrgstr.LeadDate = newlead.LeadDate;
                    newleadrgstr.LeadTime = newlead.LeadTime;
                    newleadrgstr.LeadType = newlead.LeadTypeID;
                    newleadrgstr.ContactNo = newlead.ContactNo;
                    newleadrgstr.Email = newlead.Email;
                    newleadrgstr.TimeZone = newlead.TimeZoneID;
                    newleadrgstr.Location = newlead.Location;
                    newleadrgstr.IPAddress = newlead.IPAddress;
                    newleadrgstr.LeadStatus = newlead.LeadStatus;
                    newleadrgstr.Budget = newlead.Budget;
                    newleadrgstr.NextPlan = newlead.NextPlan;
                    newleadrgstr.LastStatus = newlead.LastStatus;
                    newleadrgstr.IntialRequirements = newlead.IntialRequirements;
                    newleadrgstr.AssignedToUSerID = newlead.AssignedToUSerID;
                    newleadrgstr.DateCreated = DateTime.Now;
                    newleadrgstr.Is_Active = true;
                    newleadrgstr.Status = "Active";
                    newleadrgstr.Created_By = Convert.ToInt32(Session["UserId"]);

                    //insert to database
                    db.Leads.Add(newleadrgstr);
                    db.SaveChanges();
                    return Json(new { status = "Ok", code = 200, msg = "SuccessFully Inserted", data = "" }, JsonRequestBehavior.AllowGet);

                }
                catch (Exception ex)
                {
                    return Json(new { status = "Bad Gateway", code = 400, msg = "Failed Server Error" + ex.Message, data = "" }, JsonRequestBehavior.AllowGet);
                }
                #endregion
            }
            else
            {
                return Json(new { status = "Error", code = 422, msg = "Entity Failed ", data="" }, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult DeleteLeadType(int id)
        {
            var result = db.LeadTypes.SingleOrDefault(b => b.ID == id);
            if (result != null)
            {
                
                result.Is_Active = false;
                result.Status = "Deleted";
                result.Created_By = Convert.ToInt32(Session["UserId"]);
                db.SaveChanges();
            }
            return Json(new { status = "Ok", code = 200, msg = "No User Found", data = "" }, JsonRequestBehavior.AllowGet);
        }
                      
        public JsonResult ShowLeadType(int id)
        {
            var leadtype = db.LeadTypes.Where(p => p.ID == id).FirstOrDefault();
            return Json(new { status = "Ok", code = 200, msg = "Success", data = leadtype }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddLeadType()
        {
            GetLeadType();
            return View();
        }
        
        [HttpPost]
        public JsonResult AddNewLeadType(LeadTypeModel ltype)
        {
            if (ltype.ID > 0)
            {
                var result = db.LeadTypes.SingleOrDefault(b => b.ID == ltype.ID);
                if (result != null)
                {
                    result.LeadTypeName = ltype.LeadTypeName;
                    //result.Is_Active = false;
                    //result.Status = "Active";
                    // result.Created_By = Convert.ToInt32(Session["UserId"]);
                    db.SaveChanges();
                }
            }
            else
            {


                int userId = Convert.ToInt32(Session["UserId"]);
                LeadType lt = new LeadType();
                lt.LeadTypeName = ltype.LeadTypeName;
                lt.Status = "Active";
                lt.Is_Active = true;
                lt.DateCreated = DateTime.Now;
                lt.Created_By = userId;
                db.LeadTypes.Add(lt);
                db.SaveChanges();
            }
            //LeadType lt = db.LeadTypes.Where(c => c.LeadTypeName == ltype).SingleOrDefault();
            return Json(new { status = "ok", code = 200, data = ltype }, JsonRequestBehavior.AllowGet);

        }

        public JsonResult GetActiveLeadType()
        {
            var LeadType = db.LeadTypes.Where(p=>p.Is_Active==true).ToList();
            return Json(new {data= LeadType }, JsonRequestBehavior.AllowGet);
        }


        public ActionResult ViewActiveLeads()
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                //GetLeadType();
                //GetTimeZone();
                //GetUser();
                return View();
            }

        }
        public JsonResult GetActiveLeads()
        {
            if (Session["RoleID"].ToString() == "1")

            {
                var ActiveLeads = (from tbllead in db.Leads
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

                                   }).OrderByDescending(p => p.LeadID).ToList();

                return Json(new { status = "ok", code = 200, data = ActiveLeads }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                int userId = Convert.ToInt32(Session["UserId"]);

                var ActiveLeads = (from tbllead in db.Leads
                                   join tblleadtype in db.LeadTypes on tbllead.LeadType equals tblleadtype.ID
                                   join tbltimezone in db.TimeZones on tbllead.TimeZone equals tbltimezone.ID
                                   where tbllead.LeadStatus == true && tbllead.Is_Active == true
                                   && tbllead.AssignedToUSerID == userId
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

                                   }).OrderByDescending(p => p.LeadID).ToList();

                return Json(new { status = "ok", code = 200, data = ActiveLeads }, JsonRequestBehavior.AllowGet);
            }

            // db.Leads.Where(p=>p.LeadStatus==true).ToList()
        }
        public ActionResult ViewClosedLeads()
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                //GetLeadType();
                //GetTimeZone();
                //GetUser();
                return View();
            }

        }

        public JsonResult GetClosedLeads()
        {
            if (Session["RoleID"].ToString() == "1")
            {
                var ActiveLeads = (from tbllead in db.Leads
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

                                   }).OrderByDescending(p => p.LeadID).ToList();

                return Json(new { status = "ok", code = 200, data = ActiveLeads }, JsonRequestBehavior.AllowGet);
                // db.Leads.Where(p=>p.LeadStatus==true).ToList()
            }
            else
            {
                int userId = Convert.ToInt32(Session["UserId"]);
                var ActiveLeads = (from tbllead in db.Leads
                                   join tblleadtype in db.LeadTypes on tbllead.LeadType equals tblleadtype.ID
                                   join tbltimezone in db.TimeZones on tbllead.TimeZone equals tbltimezone.ID
                                   where tbllead.LeadStatus == false && tbllead.Is_Active == true
                                   && tbllead.AssignedToUSerID == userId
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

                                   }).OrderByDescending(p => p.LeadID).ToList();

                return Json(new { status = "ok", code = 200, data = ActiveLeads }, JsonRequestBehavior.AllowGet);
                // db.Leads.Where(p=>p.LeadStatus==true).ToList()
            }


        }

        public ActionResult ShowLead(int id)
        {

            var ActiveLeads = (from tbllead in db.Leads
                               join tblleadtype in db.LeadTypes on tbllead.LeadType equals tblleadtype.ID
                               join tbltimezone in db.TimeZones on tbllead.TimeZone equals tbltimezone.ID
                               where tbllead.ID == id
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
                                   Location = tbllead.Location,
                                   IPAddress = tbllead.IPAddress,
                                   LeadStatus = tbllead.LeadStatus,
                                   Budget = tbllead.Budget,
                                   LastStatus = tbllead.LastStatus,
                                   NextPlan = tbllead.NextPlan,
                                   IntialRequirements = tbllead.IntialRequirements
                               }).ToList();

            return Json(new { status = "ok", code = 200, data = ActiveLeads }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult EditLead(int id)
        {

            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                GetLeadType();
                GetTimeZone();
                GetUser();
                Lead vlead = db.Leads.Where(p => p.ID == id).FirstOrDefault();
                LeadModel Lmodel = new LeadModel();
                Lmodel.ID = vlead.ID;
                Lmodel.LeadDate = vlead.LeadDate;
                Lmodel.LeadTime = vlead.LeadTime;
                Lmodel.LeadTypeID = vlead.LeadType;
                Lmodel.ClientName = vlead.ClientName;
                Lmodel.ContactNo = vlead.ContactNo;
                Lmodel.Email = vlead.Email;
                Lmodel.TimeZoneID = vlead.TimeZone;
                Lmodel.Location = vlead.Location;
                Lmodel.IPAddress = vlead.IPAddress;
                Lmodel.LeadStatus = vlead.LeadStatus;
                Lmodel.Budget = vlead.Budget;
                Lmodel.NextPlan = vlead.NextPlan;
                Lmodel.LastStatus = vlead.LastStatus;
                Lmodel.IntialRequirements = vlead.IntialRequirements;
                Lmodel.AssignedToUSerID = vlead.AssignedToUSerID;
                
                return View(Lmodel);
            }
        }
        public ActionResult ShowSingleLead(int id)
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                GetLeadType();
                GetTimeZone();
                GetUser();
                Lead vlead = db.Leads.Where(p => p.ID == id).FirstOrDefault();
                LeadModel Lmodel = new LeadModel();
                Lmodel.ID = vlead.ID;
                Lmodel.LeadDate = vlead.LeadDate;
                Lmodel.LeadTime = vlead.LeadTime;
                Lmodel.LeadTypeID = vlead.LeadType;
                Lmodel.ClientName = vlead.ClientName;
                Lmodel.ContactNo = vlead.ContactNo;
                Lmodel.Email = vlead.Email;
                Lmodel.TimeZoneID = vlead.TimeZone;
                Lmodel.Location = vlead.Location;
                Lmodel.IPAddress = vlead.IPAddress;
                Lmodel.LeadStatus = vlead.LeadStatus;
                Lmodel.Budget = vlead.Budget;
                Lmodel.NextPlan = vlead.NextPlan;
                Lmodel.LastStatus = vlead.LastStatus;
                Lmodel.IntialRequirements = vlead.IntialRequirements;
                Lmodel.AssignedToUSerID = vlead.AssignedToUSerID;
                return View("AddLead", Lmodel);
            }
        }

        public ActionResult ViewFollowUpLeads()
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                //GetLeadType();
                //GetTimeZone();
                //GetUser();
                return View();
            }
        }

        public JsonResult GetFollowUpLeads()
        {
            if (Session["UserId"].ToString() == "1")
            {
                DateTime dt = DateTime.Now;
                DateTime dateOnly = dt.Date;
                var ActiveLeads = (from tbllead in db.Leads
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

                                   }).OrderByDescending(p => p.LeadID).ToList();

                return Json(new { status = "ok", code = 200, data = ActiveLeads }, JsonRequestBehavior.AllowGet);
                // db.Leads.Where(p=>p.LeadStatus==true).ToList()
            }
            else
            {
                DateTime dt = DateTime.Now;
                DateTime dateOnly = dt.Date;
                int userId = Convert.ToInt32(Session["UserId"]);
                var ActiveLeads = (from tbllead in db.Leads
                                   join tblleadtype in db.LeadTypes on tbllead.LeadType equals tblleadtype.ID
                                   join tbltimezone in db.TimeZones on tbllead.TimeZone equals tbltimezone.ID
                                   where tbllead.LeadDate == dateOnly  && tbllead.Is_Active == true
                                   && tbllead.AssignedToUSerID == userId
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

                                   }).OrderByDescending(p => p.LeadID).ToList();

                return Json(new { status = "ok", code = 200, data = ActiveLeads }, JsonRequestBehavior.AllowGet);
                // db.Leads.Where(p=>p.LeadStatus==true).ToList()

            }

        }

        public JsonResult DeleteLead(int id)
        {
            bool flag = false;
            try
            {
                Lead vlead = db.Leads.Where(p => p.ID == id).FirstOrDefault();
                vlead.Is_Active = false;
                db.Entry(vlead).State = System.Data.EntityState.Modified;
                db.SaveChanges();
                flag = true;
            }
            catch(Exception e)
            {
                flag = false;
            }

            if (flag)
            {

                return Json(new { success = true, statuscode = 200, msg = "Successfull" }, JsonRequestBehavior.AllowGet);

            }
            else
            {
                return Json(new { success = false, statuscode = 500, msg = "Failed" }, JsonRequestBehavior.AllowGet);

            }
        }
    }
}