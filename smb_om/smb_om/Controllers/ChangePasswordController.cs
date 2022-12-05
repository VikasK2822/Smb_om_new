using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using smb_om.Infrastructure;
using smb_om.Library;
using smb_om.Middleware;
using smb_om.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace smb_om.Controllers
{
    public class ChangePasswordController : Controller
    {
        readonly IChangePassword _IChangePassword;
        public ChangePasswordController(IChangePassword IChangePassword)
        {
            _IChangePassword = IChangePassword;
        }

        public IActionResult Index()
        {
            //string UserId = HttpContext.Session.GetString("UID");
            //changePassword.UserId = UserId;
            //return View(changePassword);
            return View();
        }
        public IActionResult Index2()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangePassword(ChangePasswordModel Changepasswordmodel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (!string.IsNullOrEmpty(Convert.ToString(Changepasswordmodel.UserId)) && !string.IsNullOrEmpty(Changepasswordmodel.OldPassword))
                    {
                      
                        if(Changepasswordmodel.Password.ToLower() == "Password".ToLower() )
                            {

                            ViewData["MSG"] = "Password can not be set as password";
                            return View("Index", Changepasswordmodel);
                        }
                        
                        int nn = 0;
                        bool n = CrossSiteScriptingValidation.IsDangerousString(Changepasswordmodel.UserId, out nn);
                        var uid = Changepasswordmodel.UserId;
                        var password = EncryptionLibrary.EncryptText(Changepasswordmodel.OldPassword);
                        //var password = Changepasswordmodel.password;
                        //var password = Changepasswordmodel.Password;

                        bool IsCheckUid = _IChangePassword.CheckUid(uid, password);
                        if(!IsCheckUid)
                        {
                            ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
                            ViewData["MSG"] = "Invalid UserID or Password";
                            return View("Index", Changepasswordmodel);
                        }
                        string UserId = HttpContext.Session.GetString("UserId");
                       
                        var result = _IChangePassword.ChangePassword(uid, EncryptionLibrary.EncryptText(Changepasswordmodel.Password), UserId);
                        //OrderManagerLogin result = _Ilogin.ValidateUserlogin(uid, password).FirstOrDefault();
                        //var result = "";

                        //     UserManager result = _Ilogin.ValidateUser(uid, password);
                        if (result > 0)
                        {
                            ViewData["MSG"] = "Password changed succesfully!";
                           return RedirectToAction("Logout", "Login");
                            //  return View("Index", Changepasswordmodel);
                        }
                        else
                        {
                            ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
                            ViewData["MSG"] = "Invalid Login Attempt";
                            return View("Index", Changepasswordmodel);
                            //return RedirectToAction("Index");
                        }
                    }
                    else
                    {
                        //ViewData["MSG"] = "Invalid Username and Password";
                        return View("Index", Changepasswordmodel);
                        //  return RedirectToAction("Index");
                        //  return View();
                    }
                  //  return View("Index", Changepasswordmodel);
                    //    return View();
                }
                catch (Exception ex)
                {
                    ViewData["MSG"] = ex.Message;
                    return RedirectToAction("Index");
                   // return View("Index", loginModel);
                    //return View();
                }
            }

                return View("Index", Changepasswordmodel);
        }
    }

}
