using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SaveRichTextToDB.Models;

namespace SaveRichTextToDB.Controllers
{
    public class HomeController : Controller
    {
        // Db Class Object Intiallization
        private db_htmlEntities1 databaseManager = new db_htmlEntities1();

        public ActionResult Index()
        {
            // Initialization/
            HTMLDisplayViewModel model = new HTMLDisplayViewModel() { HtmlContent = null, IsValid = false, Message = string.Empty, HTMLContentList = new List<display_all_HTML_Content_Result>() };

            try
            {
                // Get List of Rich Text From Database and Then Pass onto VIEW.
                model.HTMLContentList = databaseManager.display_all_HTML_Content().ToList();
            }
            catch (Exception ex)
            {
                // If Ever Exception Occurs
                Console.Write(ex);
            }

            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Index(HTMLDisplayViewModel model)
        {
            try
            {
                // Checking If Entered Data in VIEW is Model Valid or Not
                if (ModelState.IsValid)
                {
                    // Saving New ETxt Data onto Database
                    databaseManager.Insert_HTML_Content(model.HtmlContent);
                    databaseManager.SaveChanges();

                    // Getting Fresh Updated List From Database Afetr Saving New Data & Setting up other properties
                    model.HTMLContentList = databaseManager.display_all_HTML_Content().ToList();
                    model.Message = "Information successfully!! saved.";
                    model.IsValid = true;
                }
                else
                {
                    // Checking If No Data is Entered In Text Area On View or Is Empty Field passed
                    if (string.IsNullOrEmpty(model.HtmlContent))
                    {
                        // Setting up other properties
                        model.HTMLContentList = new List<display_all_HTML_Content_Result>();
                        model.Message = "Require field can not be emptied";
                        model.IsValid = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }

            return View(model);
        }
    }
}