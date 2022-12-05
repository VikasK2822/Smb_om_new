using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using smb_om.Middleware;
using smb_om.Infrastructure;
using smb_om.Library;
using smb_om.Model;

namespace smb_om.Controllers
{
    public class LoginController : Controller
    {
        // GET: LoginController
        readonly Ilogin _Ilogin;
        public LoginController(Ilogin ILogin)
        {
            _Ilogin = ILogin;
        }


        public ActionResult Login()
        {
            return View();
        }

        // GET: LoginController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LoginController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LoginController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public   ActionResult Login(LoginModel loginModel)
        {
           // if (ModelState.IsValid)
           // {
           //     try
           //     {
           //         return RedirectToAction("Index", "MLP");
           //     }
           //     catch
           //     {
           //         return View();
           //     }
           // }
           //// return RedirectToAction("Login",);

           // return View(loginModel);

            if (ModelState.IsValid)
            {
                try
                {
                    if (!string.IsNullOrEmpty(Convert.ToString(loginModel.UserId)) && !string.IsNullOrEmpty(loginModel.Password))
                    {
                        int nn = 0;
                        bool n = CrossSiteScriptingValidation.IsDangerousString(loginModel.UserId, out nn);
                        var uid = loginModel.UserId;
                        var password = EncryptionLibrary.EncryptText(loginModel.Password);
                        //var password = loginModel.password;
                        //    var password = loginModel.Password;

                      //  UserManager result = _Ilogin.ValidateUser(uid, password).FirstOrDefault();
                       // var  result1 = _Ilogin.ValidateUserlogin(uid, password).FirstOrDefault();
                        OrderManagerLogin result = _Ilogin.ValidateUserlogin(uid, password).FirstOrDefault();

                        //     UserManager result = _Ilogin.ValidateUser(uid, password);
                        if (result != null)
                        {
                            if ((result.UserId) != uid)
                            {
                                ViewData["MSG"] = "Invalid Username and Password";
                            }
                            else
                            {
                                Remove_Anonymous_Cookies(); //Remove Anonymous_Cookies
                                HttpContext.Session.SetString("UserId", Convert.ToString(result.UserId));
                                HttpContext.Session.SetString("Name", Convert.ToString(result.FirstName));
                                HttpContext.Session.SetString("Role", Convert.ToString(result.RoleId));
                               // string user = User.Identity.Name;
                                return RedirectToAction("Index", "MLP");
                            }
                        }
                        else
                        {
                            ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
                            ViewData["MSG"] = "Invalid Login Attempt";
                            return View(loginModel);
                            //return RedirectToAction("Index");
                        }
                    }
                    else
                    {
                        ViewData["MSG"] = "Invalid Username and Password";
                        return View("Login", loginModel);
                        //  return RedirectToAction("Index");
                        //  return View();
                    }
                    return View("Login", loginModel);
                    //    return View();
                }
                catch (Exception ex)
                {
                    ViewData["MSG"] = ex.Message;
                    return RedirectToAction("Index");
                    //return View();
                }
            }
          //  return View(loginModel);

            return View("Login", loginModel);
        }

        [NonAction]
        public void Remove_Anonymous_Cookies()
        {
            if (Request.Cookies["SMB_OM"] != null)
            {
                CookieOptions option = new CookieOptions();
                option.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Append("SMb_om", "", option);
            }
        }

        public ActionResult Logout()
        {
            Remove_Anonymous_Cookies();
            HttpContext.Session.Clear();
           
            return RedirectToAction("Login");
        }


        // GET: LoginController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LoginController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LoginController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LoginController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
