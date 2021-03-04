using LeadManagementSystems.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeadManagementSystems.Controllers
{
    public class UserController : Controller
    {
        LeadCRMEntities db = new LeadCRMEntities();
        // GET: User
        public ActionResult AddUsers()
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                return View();
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
                //if (ModelState.IsValid)
                //{
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
                        rgsteruser.Status = "Active";
                        rgsteruser.DateCreated = DateTime.Now;
                        rgsteruser.CreatedBy = Convert.ToInt32(Session["UserId"].ToString());
                        rgsteruser.RoleId = 2;
                        if (rgsterUserformdata.ProfilePictureFile != null)
                        {

                            UploadProfilePicture(rgsterUserformdata);
                        }
                        rgsteruser.ProfilePicPath = rgsterUserformdata.PicturePath;
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
                //}
                //else
                //{
                //    //Validation Failed
                //    return Json(new { status = "Bad Gateway", code = 400, msg = "Validation Failed", data = "" }, JsonRequestBehavior.AllowGet);

                //}
                #endregion
            }
        }

        public ActionResult ViewUsers()
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                return View();
            }
        }
        [HttpGet]
        public JsonResult ViewActiveUsers()
        {
            if (Session["UserId"] == null)
            {
                return Json(new { status = "Ok", code = 401, msg = "Unauthorized Access", data = User }, JsonRequestBehavior.AllowGet);

            }
            else
            {
                try
                {
                    var data = db.USERs.Where(p => p.IsActive == true).ToList();
                    return Json(new { status = "ok ", code = 200, msg = "Unauthorized Access", data = data }, JsonRequestBehavior.AllowGet);

                }
                catch (Exception ex)
                {
                    return Json(new { status = "Bad Request ", code = 401, msg = "Unauthorized Access", data = User }, JsonRequestBehavior.AllowGet);

                }
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
                    file.SaveAs(root+"/" + filename);
                }
                else
                {
                    file.SaveAs(root+"/" + filename);
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

       
    }
}