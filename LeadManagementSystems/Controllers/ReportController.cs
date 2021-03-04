using LeadManagementSystems.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeadManagementSystems.Controllers
{
    public class ReportController : BaseController
    {
        LeadCRMEntities db = new LeadCRMEntities();
        // GET: Report
        public ActionResult Report()
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
        public JsonResult SearchLead(LeadModel searchLead)
        {
           
           
            if (Session["UserId"] == null)
            {
                return Json(new { status = "Ok", code = 401, msg = "Unauthorized Access", data = "" }, JsonRequestBehavior.AllowGet);

            }
            else if(searchLead.Year!=0)
            {
                var leads = db.Leads.ToList();

                var bb = db.sp_readdatalead().ToList();
                List<LeadViewModel> LmList = new List<LeadViewModel>();

                foreach (var l in bb)
                {
                    LeadViewModel lvm = new LeadViewModel();
                    lvm.LeadID = l.ID;
                    lvm.LeadDate = l.LeadDate;
                    lvm.LeadTime = l.LeadTime;
                    lvm.LeadTypeID = l.LeadTypeTableID;
                    lvm.ClientName = l.ClientName;
                    lvm.LeadTypeName = l.LeadTypeName;
                    lvm.ContactNo = l.ContactNo;
                    lvm.Email = l.Email;
                    lvm.TimeZoneID = l.TimeZonetableID;
                    lvm.TimeZoneName = l.TimeZone;
                    lvm.Location = l.Location;
                    lvm.IPAddress = l.IPAddress;
                    lvm.LeadStatus = l.LeadStatus;
                    lvm.Budget = l.Budget;
                    lvm.NextPlan = l.NextPlan;
                    lvm.LastStatus = l.LastStatus;
                    lvm.IntialRequirements = l.IntialRequirements;
                    lvm.AssignedToUSerID = l.UserTableID;
                    lvm.Status = l.Status;
                    lvm.UserName = l.UserName;
                    LmList.Add(lvm);


                }
                

                return Json(new { status = "ok", code = 200, data = LmList }, JsonRequestBehavior.AllowGet);

            }
            else 
            {
                if (searchLead.AssignedToUSerID != null)
                {
                    if (searchLead.LeadStatus == null)
                    {
                        var s1 = db.Leads.Where(c => c.AssignedToUSerID == searchLead.AssignedToUSerID && c.LeadDate == searchLead.LeadDate && c.LeadType == searchLead.LeadTypeID).ToList();
                        var ActiveLeadsSearch1 = (from tbllead in s1
                                                  join tblleadtype in db.LeadTypes on tbllead.LeadType equals tblleadtype.ID
                                                  join tbltimezone in db.TimeZones on tbllead.TimeZone equals tbltimezone.ID
                                                  join tbluser in db.USERs on tbllead.AssignedToUSerID equals tbluser.ID
                                                  where tbllead.Is_Active == true

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
                                                      NextPlan = tbllead.NextPlan,
                                                      LastStatus = tbllead.LastStatus,
                                                      Status = tbllead.Status,
                                                      IntialRequirements = tbllead.IntialRequirements,
                                                      UserName = tbluser.UserName,

                                                  }).ToList();
                        return Json(new { status = "ok", code = 200, data = ActiveLeadsSearch1 }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        var s2 = db.Leads.Where(c => c.AssignedToUSerID == searchLead.AssignedToUSerID && c.LeadDate == searchLead.LeadDate && c.LeadType == searchLead.LeadTypeID && c.LeadStatus == searchLead.LeadStatus).ToList();
                        var ActiveLeadsSearch2 = (from tbllead in s2
                                                  join tblleadtype in db.LeadTypes on tbllead.LeadType equals tblleadtype.ID
                                                  join tbltimezone in db.TimeZones on tbllead.TimeZone equals tbltimezone.ID
                                                  join tbluser in db.USERs on tbllead.AssignedToUSerID equals tbluser.ID
                                                  where tbllead.Is_Active == true

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
                                                      NextPlan = tbllead.NextPlan,
                                                      LastStatus = tbllead.LastStatus,
                                                      Status = tbllead.Status,
                                                      IntialRequirements = tbllead.IntialRequirements,
                                                      UserName = tbluser.UserName,

                                                  }).ToList();
                        return Json(new { status = "ok", code = 200, data = ActiveLeadsSearch2 }, JsonRequestBehavior.AllowGet);
                    }


                }

                else
                {
                    if (searchLead.LeadStatus == null)
                    {
                        var s1 = db.Leads.Where(c => c.LeadDate == searchLead.LeadDate && c.LeadType == searchLead.LeadTypeID).ToList();
                        var ActiveLeadsSearch1 = (from tbllead in s1
                                                  join tblleadtype in db.LeadTypes on tbllead.LeadType equals tblleadtype.ID
                                                  join tbltimezone in db.TimeZones on tbllead.TimeZone equals tbltimezone.ID
                                                  join tbluser in db.USERs on tbllead.AssignedToUSerID equals tbluser.ID
                                                  where tbllead.Is_Active == true

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
                                                      NextPlan = tbllead.NextPlan,
                                                      LastStatus = tbllead.LastStatus,
                                                      Status = tbllead.Status,
                                                      IntialRequirements = tbllead.IntialRequirements,
                                                      UserName = tbluser.UserName,

                                                  }).ToList();
                        return Json(new { status = "ok", code = 200, data = ActiveLeadsSearch1 }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        var s2 = db.Leads.Where(c => c.LeadDate == searchLead.LeadDate && c.LeadType == searchLead.LeadTypeID && c.LeadStatus == searchLead.LeadStatus).ToList();
                        var ActiveLeadsSearch2 = (from tbllead in s2
                                                  join tblleadtype in db.LeadTypes on tbllead.LeadType equals tblleadtype.ID
                                                  join tbltimezone in db.TimeZones on tbllead.TimeZone equals tbltimezone.ID
                                                  join tbluser in db.USERs on tbllead.AssignedToUSerID equals tbluser.ID
                                                  where tbllead.Is_Active == true

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
                                                      NextPlan = tbllead.NextPlan,
                                                      LastStatus = tbllead.LastStatus,
                                                      Status = tbllead.Status,
                                                      IntialRequirements = tbllead.IntialRequirements,
                                                      UserName = tbluser.UserName,

                                                  }).ToList();


                        return Json(new { status = "ok", code = 200, data = ActiveLeadsSearch2 }, JsonRequestBehavior.AllowGet);
                    }

                }
             
            
               
                // db.Leads.Where(p=>p.LeadStatus==true).ToList()
            }
        }
    }
}