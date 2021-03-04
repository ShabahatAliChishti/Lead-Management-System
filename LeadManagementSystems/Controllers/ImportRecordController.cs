using LeadManagementSystems.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using excel = Microsoft.Office.Interop.Excel;

namespace LeadManagementSystems.Controllers
{
    public class ImportRecordController : Controller
    {
        LeadModel objreportproperty;
        LeadCRMEntities db = new LeadCRMEntities();
        // GET: ImportRecord
        public ActionResult ImportBulkReport()
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }

        [HttpPost]
        public JsonResult UploadReport(HttpPostedFileBase ExcelFileReport)
        {
            ViewBag.msg = "";
            int statuscode = 0;
            try
            {

                if (SaveExcelFile(ExcelFileReport))
                {
                    objreportproperty = new LeadModel();
                    //objreportproperty.tbl_Record = ToDataTable(ReadExcelFile(ExcelFileReport.FileName));
                    List<LeadModel> lst = new List<LeadModel>();
                    lst =  ReadExcelFile(ExcelFileReport.FileName);
                    bool st =  insertBulk(lst);
                    
                    if(st == true && lst.Count>0)
                    {
                        ViewBag.msg = "Data Is Inserted Successfully";
                        statuscode = 200;
                    }
                    else
                    {
                        ViewBag.msg = "Failed to insert Data";
                        statuscode = 403;
                    }
                    //db.Leads.Add(objreportproperty.tbl_Record);
                    //var flag = objattendancebll.Insert(objreportproperty.tbl_Attendance);
                    //if (flag)
                    //{
                    //    ViewBag.msg = "Success";
                    //}
                    //else
                    //{
                    //    ViewBag.msg = "Contact Administrator";
                    //}

                }

                return Json(new { success = true,code= statuscode, msg = ViewBag.msg }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, code = statuscode, msg = "Contact Administrator" }, JsonRequestBehavior.AllowGet);
            }

        }

        public bool SaveExcelFile(HttpPostedFileBase ExcelFileRecord)
        {
            try
            {
                var file = ExcelFileRecord;
                // var filename = Path.GetFileName(ExcelFileAttendence.FileName);
                var filename = ExcelFileRecord.FileName;
                ExcelFileRecord.SaveAs(Server.MapPath("/ExcelFiles/" + filename));
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }

        }
        private List<LeadModel> ReadExcelFile(string filename)
        {
            try
            {
                
                int rowstart, LeadTypeID, TimeZoneID, AssignedToUSerID, ClientName, ContactNo, Email, Location, IPAddress, LeadTime, NextPlan, IntialRequirements, LeadDate, LastStatus, LeadStatus, Budget;



                rowstart = Convert.ToInt32(ConfigurationManager.AppSettings["RowStartReading"].ToString());
                LeadDate = Convert.ToInt32(ConfigurationManager.AppSettings["Date"].ToString());
                LeadTime = Convert.ToInt32(ConfigurationManager.AppSettings["Time"].ToString());
                LeadTypeID = Convert.ToInt32(ConfigurationManager.AppSettings["LeadType"].ToString());
                ClientName = Convert.ToInt32(ConfigurationManager.AppSettings["ClientName"].ToString());
                ContactNo = Convert.ToInt32(ConfigurationManager.AppSettings["ContactNo"].ToString());
                Email = Convert.ToInt32(ConfigurationManager.AppSettings["Email"].ToString());
                TimeZoneID = Convert.ToInt32(ConfigurationManager.AppSettings["Timezone"].ToString());
                Location = Convert.ToInt32(ConfigurationManager.AppSettings["Location"].ToString());
                IPAddress = Convert.ToInt32(ConfigurationManager.AppSettings["IP"].ToString());
                LeadStatus = Convert.ToInt32(ConfigurationManager.AppSettings["LeadStatus"].ToString());
                Budget = Convert.ToInt32(ConfigurationManager.AppSettings["Budget"].ToString());
                NextPlan = Convert.ToInt32(ConfigurationManager.AppSettings["NextActivePlan"].ToString());
                LastStatus = Convert.ToInt32(ConfigurationManager.AppSettings["LastStatus"].ToString());
                IntialRequirements = Convert.ToInt32(ConfigurationManager.AppSettings["InitialRequirements"].ToString());
                AssignedToUSerID = Convert.ToInt32(ConfigurationManager.AppSettings["AssignLead"].ToString());
               
                List<LeadModel> Listrecord = new List<LeadModel>();
                LeadModel report;
                string filepath = Server.MapPath("/ExcelFiles/" + filename).ToString();



                excel.Application xlApp = new excel.Application();
                excel.Workbook xlWorkbook = xlApp.Workbooks.Open(filepath, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                excel._Worksheet xlWorksheet = (excel._Worksheet)xlWorkbook.Sheets[1];
                excel.Range xlRange = xlWorksheet.UsedRange;
                int rowCount = xlRange.Rows.Count;
                int colCount = xlRange.Columns.Count;
                for (int i = rowstart; i <= rowCount; i++)
                {
                    //for (int j = 1; j <= colCount; j++)
                    //{
                    //attendance = new Attendance_Property();
                    //new line
                    //if (j == 1)
                    //    Console.Write("\r\n");

                    //write the value to the console
                    //if (xlRange.Cells[i, j] != null && xlRange.Cells[i, j].Value2 != null)
                    ////Console.Write(xlRange.Cells[i, j].Value2.ToString() + "\t");
                    //{
                    //    attendance.EmployeeId= xlRange.Cells[i, j].Value2.ToString();
                    //}


                    //}
                    report = new LeadModel();
                    int userId = Convert.ToInt32(Session["UserId"]);
                    report.Status = "Active";
                    report.Is_Active = true;
                    report.DateCreated = DateTime.Now;
                    report.Created_By = userId;
                    //forEmployeeID
                    if (xlRange.Cells[i, LeadTypeID] != null && xlRange.Cells[i, LeadTypeID].Value2 != null)
                    {
                        string lname = xlRange.Cells[i, LeadTypeID].Value2.ToString();
                        var  a = db.LeadTypes.Where(c => c.LeadTypeName == lname).FirstOrDefault();
                        
                        if (a==null)
                        {
                            report.LeadTypeID = 0;
                        }
                        else
                        {
                            report.LeadTypeID = Convert.ToInt32(a.ID);
                        }
                        
                    }
                    else
                    {
                        report.LeadTypeID = 0;
                    }

                    if (xlRange.Cells[i, TimeZoneID] != null && xlRange.Cells[i, TimeZoneID].Value2 != null)
                    {
                        string time = xlRange.Cells[i, TimeZoneID].Value2.ToString();
                        var a = db.TimeZones.Where(c => c.TimeZone1 == time).FirstOrDefault();
                        if (a == null)
                        {
                            report.TimeZoneID = 0;
                        }
                        else
                        {
                            report.TimeZoneID = Convert.ToInt32(a.ID);
                        }
                        
                    }
                    else
                    {
                        report.TimeZoneID = 0;
                    }
                    if (xlRange.Cells[i, AssignedToUSerID] != null && xlRange.Cells[i, AssignedToUSerID].Value2 != null)
                    {
                        string user = xlRange.Cells[i, AssignedToUSerID].Value2.ToString();
                        var a = db.USERs.Where(c => c.FirstName == user).FirstOrDefault();
                        if (a == null)
                        {
                            report.AssignedToUSerID = 0;
                        }
                        else
                        {
                            report.AssignedToUSerID = Convert.ToInt32(a.ID);
                        }
                        
                    }
                    else
                    {
                        report.AssignedToUSerID = 0;
                    }
                    if (xlRange.Cells[i, ClientName] != null && xlRange.Cells[i, ClientName].Value2 != null)
                    {
                        report.ClientName = xlRange.Cells[i, ClientName].Value2.ToString();
                    }
                    else
                    {
                        report.ClientName = "uploaded from exel column is null";
                    }
                 
                    if (xlRange.Cells[i, ContactNo] != null && xlRange.Cells[i, ContactNo].Value2 != null)
                    {
                        report.ContactNo = xlRange.Cells[i, ContactNo].Value2.ToString();
                    }
                    else
                    {
                        report.ContactNo = "uploaded from exel column is null";
                    }
                    if (xlRange.Cells[i, Email] != null && xlRange.Cells[i, Email].Value2 != null)
                    {
                        report.Email = xlRange.Cells[i, Email].Value2.ToString();
                    }
                    else
                    {
                        report.Email = "uploaded from exel column is null";
                    }
                    if (xlRange.Cells[i, Location] != null && xlRange.Cells[i, Location].Value2 != null)
                    {
                        report.Location = xlRange.Cells[i, Location].Value2.ToString();
                    }
                    else
                    {
                        report.Location = "uploaded from exel column is null";
                    }
                    if (xlRange.Cells[i, IPAddress] != null && xlRange.Cells[i, IPAddress].Value2 != null)
                    {
                        report.IPAddress = xlRange.Cells[i, IPAddress].Value2.ToString();
                    }
                    else
                    {
                        report.IPAddress = "uploaded from exel column is null";
                    }
                    if (xlRange.Cells[i, LeadTime] != null && xlRange.Cells[i, LeadTime].Value2 != null)
                    {
                        report.LeadTime = xlRange.Cells[i, LeadTime].Value2.ToString();
                    }
                    else
                    {
                        report.LeadTime = "uploaded from exel column is null";
                    }
                    if (xlRange.Cells[i, NextPlan] != null && xlRange.Cells[i, NextPlan].Value2 != null)
                    {
                        report.NextPlan = xlRange.Cells[i, NextPlan].Value2.ToString();
                    }
                    else
                    {
                        report.NextPlan = "uploaded from exel column is null";
                    }
                    if (xlRange.Cells[i, IntialRequirements] != null && xlRange.Cells[i, IntialRequirements].Value2 != null)
                    {
                        report.IntialRequirements = xlRange.Cells[i, IntialRequirements].Value2.ToString();
                    }
                    else
                    {
                        report.IntialRequirements = "uploaded from exel column is null";
                    }
                    if (xlRange.Cells[i, LastStatus] != null && xlRange.Cells[i, LastStatus].Value2 != null)
                    {
                        report.LastStatus = xlRange.Cells[i, LastStatus].Value2.ToString();
                    }
                    else
                    {
                        report.LastStatus = "uploaded from exel column is null";
                    }
                    if (xlRange.Cells[i, LeadStatus] != null && xlRange.Cells[i, LeadStatus].Value2 != null)
                    {
                        String isactive = xlRange.Cells[i, LeadStatus].Value2.ToString();
                        bool b = Convert.ToBoolean(isactive);
                        if(b==true || b==false)
                        {
                            report.LeadStatus = b;
                        }
                        else
                        {
                            report.LeadStatus = false;
                        }
                        
                    }
                    else
                    {
                        report.LeadStatus = false;
                    }
                    if (xlRange.Cells[i, Budget] != null && xlRange.Cells[i, Budget].Value2 != null)
                    {
                        String bbudget = xlRange.Cells[i, Budget].Value2.ToString();
                        try
                        {
                            decimal d = Convert.ToDecimal(bbudget);
                            report.Budget = d;

                        }
                        catch(Exception e)
                        {
                            report.Budget = 0;
                        }


                    }
                    else
                    {
                        report.Budget = 0;
                    }

                    //forattendancedate
                    if (xlRange.Cells[i, LeadDate] != null && xlRange.Cells[i, LeadDate].Value2 != null)
                    {
                        String date = xlRange.Cells[i, LeadDate].Value2.ToString();
   //attendance.Attendance_Date =Convert.ToDateTime(xlRange.Cells[i, AttendanceDate].Value2.ToString());
                        try
                        {

                            string newdate = DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.CurrentCulture).ToString("yyyy-MM-dd");
                            report.LeadDate = Convert.ToDateTime(newdate);// DateTime.ParseExact(xlRange.Cells[i, AttendanceDate].Value2.ToString(), "yyyy/MM/dd", null);

                        }
                        catch(Exception e)
                        {
                            report.LeadDate = DateTime.Now;
                        }
                    }
                    else
                    {
                        report.LeadDate = DateTime.Now;
                    }



                    Listrecord.Add(report);

                }

                return Listrecord;


            }


            catch (Exception ex)
            {
                using (var tw = new StreamWriter(Server.MapPath("/ExcelFiles/" + "abc.txt"), true))
                {
                    tw.WriteLine(ex.Message);
                }
                List<LeadModel> a =new  List<LeadModel>();
                return a;
            }
        }
        //public static DataTable ToDataTable<T>(List<T> items)
        //{
        //    DataTable dataTable = new DataTable(typeof(T).Name);

        //    //Get all the properties
        //    PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        //    foreach (PropertyInfo prop in Props)
        //    {
        //        //Defining type of data column gives proper data table 
        //        var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
        //        //Setting column names as Property names
        //        dataTable.Columns.Add(prop.Name, type);
        //    }
        //    foreach (T item in items)
        //    {
        //        var values = new object[Props.Length];
        //        for (int i = 0; i < Props.Length; i++)
        //        {
        //            //inserting property values to datatable rows
        //            values[i] = Props[i].GetValue(item, null);
        //        }
        //        dataTable.Rows.Add(values);
        //    }

        //    return dataTable;
        //}

        public bool insertBulk(List<LeadModel> m)
        {
            try
            {
                if(m.Count>0)
                {
                    foreach (LeadModel emp in m)
                    {
                        string da = "20-07-15";
                        Lead objlm = new Lead();
                        objlm.AssignedToUSerID = 2;
                        objlm.Budget = emp.Budget;
                        objlm.ClientName = emp.ClientName;
                        objlm.ContactNo = emp.ContactNo;
                        objlm.Created_By = emp.Created_By;
                        objlm.DateCreated = emp.DateCreated;
                        objlm.Email = emp.Email;
                        objlm.IntialRequirements = emp.IntialRequirements;
                        objlm.IPAddress = emp.IPAddress;
                        objlm.Is_Active = emp.Is_Active;
                        objlm.LastStatus = emp.LastStatus;
                        objlm.LeadDate = DateTime.Now;
                        objlm.LeadStatus = emp.LeadStatus;
                        objlm.LeadTime = emp.LeadTime;
                        objlm.LeadType = emp.LeadTypeID;
                        objlm.Location = emp.Location;
                        objlm.NextPlan = emp.NextPlan;
                        objlm.Status = emp.Status;
                        objlm.TimeZone = emp.TimeZoneID;
                        db.Leads.Add(objlm);
                       
                    }

                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
               
                
            }
            catch(Exception e)
            {
                return false;
            }
            
        }

    }
}