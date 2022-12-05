using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using smb_om.Infrastructure;
using smb_om.Library;
using smb_om.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace smb_om.Controllers
{
    public class UserManagerController : Controller
    {
        readonly IUserManager _userManager;

        public UserManagerController(IUserManager userManager)
        {
            this._userManager = userManager;
        }
        // GET: UserManagerController
        public ActionResult Index()
        {
            return View();
        }

        // GET: UserManagerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserManagerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserManagerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            if (!ModelState.IsValid)
            {
                UserManager _user = new UserManager();
                View("Index", _user);
            }
            try
            {
                UserManager _user = new UserManager();
                _user.UserId = collection["UserId"];
                _user.Password = EncryptionLibrary.EncryptText(collection["Password"]);
                _user.Group_Name = "";
                _user.Role_Type = Int32.Parse(collection["Role_Type"]);
                _user.First_Name = collection["First_Name"];
                _user.Last_Name = collection["Last_Name"];
                _user.Email = collection["Email"];
                _user.Phone_Number = collection["Phone_Number"];
                _user.Account_Lock = collection["Account_Lock"] == 1;  //int.Parse(collection["Account_Lock"])==1;
                _user.Pass_Never_Expire = collection["Pass_Never_Expire"] == 1; // Int32.Parse(collection["Pass_Never_Expire"])==1? true:false;
                _user.Max_Login = Int32.Parse(collection["Max_Login"]);
                _user.Program = collection["Program"].Count == 2 ? true : false;
                _user.FG_IsLogin = 1;
                _user.User_Session = collection["User_Session"];
                _user.Mode = "LOGIN";
                _user.FG_Flag = 1;
                _user.Created_By = HttpContext.Session.GetString("UserId");
                _user.Updated_By = HttpContext.Session.GetString("UserId");
                _user.Created_Date = DateTime.UtcNow;
                _user.Updated_Date = DateTime.UtcNow;
                _user.PartnerId = collection["PartnerId"];
                _user.AffiliateId = collection["Affiliate_Name"];
                //int c = _userManager.CreateNewUser(_user);
                int c = 0;

                if (c > 0)
                {
                    ViewBag.Message = "User Addedd Successfuly!";

                }
                else
                {
                    ViewBag.Message = "Error: No User Added";
                }

            }
            catch (Exception ex)
            {
                ViewBag.Message = "Error: " + ex.Message;
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: UserManagerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserManagerController/Edit/5
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

        // GET: UserManagerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserManagerController/Delete/5
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
