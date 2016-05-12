using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls.WebParts;
using HBGDatorServiceDAL;
using HBGDatorServiceDAL.Models;
using HBGDatorServiceDAL.POCO;
using System.Configuration;
using System.Data.SqlClient;
namespace HBGDatorService.Controllers
{
    [Authorize]
    public class EditAboutPageController : Controller
    {
        [HttpGet]
        public ActionResult EditAbout()
        {
            var currentAboutInfo = Repository.GetLatestAbouts();
            return View();
        }

        [HttpPost]
        public ActionResult EditAbout(EditAboutModel model)
        {
            if (ModelState.IsValid)
            {
                var about = Repository.GetLatestAbouts();
                Repository.UpdateAbouts(Repository.SetAboutValues(model, about));
                return RedirectToAction("Index", "About");
            }

            return View(model);
        }

        //public ActionResult AddEditAbout()
        //{
        //    try
        //    {
        //        //Abouts abouts = new Abouts();
        //        //About about    = new About(textBoxFirstName.Text, textBoxLastName.Text, textBoxEmail.Text, int.Parse(textBoxPersonID.Text));
        //        //abouts.InsertPerson(about);
        //    }
        //    catch (Exception exception)
        //    {
           
        //    }
        //}
        //public ActionResult UpdateEditAbout()
        //{
        //    try
        //    {
        //        //Abouts abouts = new Abouts();
        //        //About about    = new About(textBoxFirstName.Text, textBoxLastName.Text, textBoxEmail.Text, int.Parse(textBoxPersonID.Text));
        //        //abouts.UpdatePerson(about);
        //    }
        //    catch (Exception exception)
        //    {
                
        //    }
        //}
        //public ActionResult DeleteEditAbout()
        //{
        //    try
        //    {
        //        //Abouts abouts = new Abouts();
        //        //About about    = new About(textBoxFirstName.Text, textBoxLastName.Text, textBoxEmail.Text);

        //    }
        //    catch (Exception exception)
        //    {
            
        //    }
        //}
    }
}