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
        private db_htmlEntities1 databaseManager = new db_htmlEntities1();

        public ActionResult Index()
        {
            // Initialization/
            HTMLDisplayViewModel model = new HTMLDisplayViewModel() { HtmlContent = null, IsValid = false, Message = string.Empty, HTMLContentList = new List<display_all_HTML_Content_Result>() };

            try
            {
                // Get info list.
                model.HTMLContentList = this.databaseManager.display_all_HTML_Content().ToList();
            }
            catch (Exception ex)
            {
                // Info
                Console.Write(ex);
            }

            // Info.
            return this.View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Index(HTMLDisplayViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    this.databaseManager.Insert_HTML_Content(model.HtmlContent);

                    this.databaseManager.SaveChanges();

                    model.HTMLContentList = this.databaseManager.display_all_HTML_Content().ToList();
                    model.Message = "Information successfully!! saved.";
                    model.IsValid = true;
                }
                else
                {
                    if (string.IsNullOrEmpty(model.HtmlContent))
                    {
                        // Settings.
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