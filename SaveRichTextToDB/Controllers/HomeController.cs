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
        #region Private Property

        /// <summary>
        /// Gets or sets database manager property.
        /// </summary>
        private db_htmlEntities1 databaseManager = new db_htmlEntities1();

        #endregion

        #region Index view method.

        #region Get: /HTMLDisplay/Index method.

        /// <summary>
        /// Get: /HTMLDisplay/Index method.
        /// </summary>        
        /// <returns>Return index view</returns>
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

        #endregion

        #region POST: /HTMLDisplay/Index

        /// <summary>
        /// POST: /HTMLDisplay/Index
        /// </summary>
        /// <param name="model">Model parameter</param>
        /// <returns>Return - Response information</returns>
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Index(HTMLDisplayViewModel model)
        {
            try
            {
                // Verification
                if (ModelState.IsValid)
                {
                    // save info.
                    this.databaseManager.Insert_HTML_Content(model.HtmlContent);

                    // Commit database.
                    this.databaseManager.SaveChanges();

                    // Settings.
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
                // Info
                Console.Write(ex);
            }

            // Info
            return this.View(model);
        }

        #endregion

        #endregion
    }
}