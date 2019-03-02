using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SaveRichTextToDB.Models
{
    public class HTMLDisplayViewModel
    {

        // The AllowHtml attribute can be applied to a Model property and it will disable the validation by ASP.Net MVC only for that particular property.
        // We need to do this because we are going to store Raw Html of directily into this property.
        [AllowHtml]
        [Required]
        [Display(Name = "HTML Content")]
        public string HtmlContent { get; set; }


        // This is Just For Status Message to Show it On Client Area.
        [Display(Name = "Message")]
        public string Message { get; set; }


        // This is to Manually Set The Validity to Show Text Or Not.
        [Display(Name = "Is Valid")]
        public bool IsValid { get; set; }


        // This Property is To Get list of All Rich TExt From Database
        public List<display_all_HTML_Content_Result> HTMLContentList { get; set; }
    }
}