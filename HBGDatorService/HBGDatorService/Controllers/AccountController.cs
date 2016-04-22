using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using HBGDatorServiceDAL.Models;
using HBGDatorServiceDAL.POCO;
using HBGDatorServiceDAL;
namespace HBGDatorService.Controllers
{
    public class AccountController : Controller // här är alla användare, både vanliga och admins.
    {
        // GET: Account
        public ActionResult Index()
        {
            using (HBGDatorServiceContext db = new HBGDatorServiceContext())
            {
                return View(db.UserAccount.ToList());
            }
        }
        public ActionResult Register()
        {
            return View();
        }
        // Register
        [HttpPost]
        public ActionResult Register(UserAccount account)
        {
            if (ModelState.IsValid)
                if (ModelState.IsValid)
                {
                    using (HBGDatorServiceContext db = new HBGDatorServiceContext())
                    {
                        db.UserAccount.Add(account);
                        db.SaveChanges();
                    }
                    ModelState.Clear();
                    ViewBag.Message = account.FirstName + " " + account.LastName + " successfully registerd";
                }
            return View();
        }

        // LOGIN
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(UserAccount user, string returnUrl)
        {

            using (HBGDatorServiceContext db = new HBGDatorServiceContext())
            {
                var usr = db.UserAccount.Where(u => u.Username == user.Username && u.Password == user.Password).FirstOrDefault();
                if (usr != null)
                {
                    Session["Admin"] = usr.Admin;
                    Session["UserID"] = usr.UserID.ToString();
                    Session["Username"] = usr.Username.ToString();
                    ViewBag.FirstName = usr.FirstName;
                    FormsAuthentication.SetAuthCookie(usr.Username, true);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "The user name or password provided is incorrect.");
                }

            }
            return View();
        }
        public ActionResult Logout() // sätt admin till null, logga ut andvändaren och skicka dem till Home.
        {
            Session["Admin"] = null;
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }

        public ActionResult IsAdmin(UserAccount currentUser)
        //kolla om användaren är en admin eller inte när dem försöker använda funktioner, är dem inte admin säger sidan att dem inte är det och dem skickas tillbaka till login.
        {
            using (HBGDatorServiceContext db = new HBGDatorServiceContext())
            {
                var usr = db.UserAccount.Where(u => u.Username == currentUser.Username && u.Password == currentUser.Password).FirstOrDefault();
                if (!(bool)Session["Admin"])
                {
                    return RedirectToAction("Login", "Account");
                }
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Loggedin()
        {
            if (Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        #region Status Codes
        private static string ErrorCodeToString(MembershipCreateStatus createStatus) // olika failsaves för Register.
        {
            // See http://go.microsoft.com/fwlink/?LinkID=177550 for
            // a full list of status codes.
            switch (createStatus)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return "User name already exists. Please enter a different user name.";

                case MembershipCreateStatus.DuplicateEmail:
                    return "A user name for that e-mail address already exists. Please enter a different e-mail address.";

                case MembershipCreateStatus.InvalidPassword:
                    return "The password provided is invalid. Please enter a valid password value.";

                case MembershipCreateStatus.InvalidEmail:
                    return "The e-mail address provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidAnswer:
                    return "The password retrieval answer provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidQuestion:
                    return "The password retrieval question provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidUserName:
                    return "The user name provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.ProviderError:
                    return "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                case MembershipCreateStatus.UserRejected:
                    return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                default:
                    return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
            }
        }
        #endregion
    }
}