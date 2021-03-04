using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeadManagementSystems.Controllers
{
    public class DashboardController : BaseController
    {

        // GET: Dashboard
        public ActionResult Dashboard()
        {
            if (Session["UserId"] == null)
            {
               return RedirectToAction("Login", "Account");
            }
            else
            {
                GetActiveLeadsForDashboard();
                GetCloseLeadsForDashboard();
                GetFollowUpLeadsForDashboard();


                return View();
            }
        }
    }
}