using LeadManagementSystems.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeadManagementSystems.Controllers
{
    public class AccountController : Controller
    {
        LeadCRMEntities db = new LeadCRMEntities();
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult ChangePassword(int Id)
        {
            var users = db.USERs.Where(c => c.ID == Id).FirstOrDefault();
            RegisterUserModel user = new RegisterUserModel();
            user.ID = users.ID;

            return View(user);
        }

        [HttpPost]
        public JsonResult ChangePassword(RegisterUserModel reg)
        {
            var user = db.USERs.Where(c => c.ID == reg.ID).FirstOrDefault();
            user.Password = reg.Password;
            db.Entry(user).State = System.Data.EntityState.Modified;
            db.SaveChanges();
            return Json(new { status = "Ok", code = 400, msg = "Password Changed"}, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult AccountInfo(UserModel usermodel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //checking users in database with this email and password
                    var User = db.USERs.Where(p => p.Email == usermodel.Email && p.Password == usermodel.Password && p.IsActive==true).FirstOrDefault();
                    if (User != null)
                    {
                        //if  user found in database with this email and password
                        Session["UserName"] = User.UserName;
                        Session["UserId"] = User.ID;
                        Session["EmployeeID"] = User.EmployeeID;
                        Session["RoleID"] = User.RoleId;
                        Session["Imagepath"] = User.ProfilePicPath;
                        return Json(new { status = "Ok", code = 200, msg = "user Availble",data= User }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {//if  user not found in database with this email and password
                        return Json(new { status = "Ok", code = 201, msg = "No User Found",data = "" }, JsonRequestBehavior.AllowGet);
                    }
                }
                catch (Exception ex)
                {
                    //if any error 
                    return Json(new { status = "Bad Gateway", code = 400, msg = "Failed"+ ex.Message,data = "" }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new { status = "Bad Gateway", code = 400, msg = "Validation Failed", data = "" }, JsonRequestBehavior.AllowGet);
            }
        }

      

        //Add USer Form Request hit here
        [HttpPost]
        public JsonResult AddNewUser(RegisterUserModel rgsterUserformdata)
        {
            if (Session["UserId"] == null)
            {
                return Json(new { status = "Ok", code = 401, msg = "Unauthorized Access", data = User }, JsonRequestBehavior.AllowGet);

            }
            else
            {

                #region Adduser

                //checking validation 
                if (ModelState.IsValid)
                {
                    try
                    {
                        //assigning form data to table model
                        var rgsteruser = new USER();
                        rgsteruser.FirstName = rgsterUserformdata.FirstName;
                        rgsteruser.Email = rgsterUserformdata.Email;
                        rgsteruser.UserName = rgsterUserformdata.UserName;
                        rgsteruser.Password = rgsterUserformdata.Password;
                        rgsteruser.ProfilePicPath = rgsterUserformdata.PicturePath;
                        rgsteruser.IsActive = true;
                        rgsteruser.DateCreated = DateTime.Now;
                        rgsteruser.CreatedBy = Convert.ToInt32(Session["UserId"].ToString());
                        rgsteruser.RoleId = 2;
                        if (rgsterUserformdata.ProfilePictureFile != null)
                        {

                            UploadProfilePicture(rgsterUserformdata);
                        }
                        //insert to daatbase
                        db.USERs.Add(rgsteruser);
                        db.SaveChanges();

                        return Json(new { status = "Ok", code = 200, msg = "No User Found", data = User }, JsonRequestBehavior.AllowGet);

                    }
                    catch (Exception ex)
                    {
                        //if any error 
                        return Json(new { status = "Bad Gateway", code = 400, msg = "Failed" + ex.Message, data = "" }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    //Validation Failed
                    return Json(new { status = "Bad Gateway", code = 400, msg = "Validation Failed", data = "" }, JsonRequestBehavior.AllowGet);

                }
                #endregion
            }
        }


        public void UploadProfilePicture(RegisterUserModel rgsterUserformdata)
        {
            var file = rgsterUserformdata.ProfilePictureFile;
            string filename = "";
            string filepath = "";
            string root = Server.MapPath("/ProfileImages");
            try
            {


                filename = System.IO.Path.GetFileName(System.IO.Path.GetRandomFileName() + file.FileName);
                if (!Directory.Exists(root))
                {
                    Directory.CreateDirectory(root);
                }
                else
                {
                    // file.SaveAs(root + "/" + filename);
                    file.SaveAs("/ProfileImages/" + filename);
                }


                filepath = "/ProfileImages/" + filename;
                //file.SaveAs(Server.MapPath(filepath));
                //string fullPath = Request.MapPath(empprofilepic.ImgPath);
                //if (System.IO.File.Exists(fullPath))
                //{
                //    System.IO.File.Delete(fullPath);
                //}

                rgsterUserformdata.PicturePath = filepath;



            }
            catch (Exception ex)
            {

            }
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            Session.RemoveAll();
            Session.Clear();
            return RedirectToAction("Login", "Account");
        }
    }
}