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
        [AllowHtml]
        [Required]
        [Display(Name = "HTML Content")]
        public string HtmlContent { get; set; }

        [Display(Name = "Message")]
        public string Message { get; set; }

        [Display(Name = "Is Valid")]
        public bool IsValid { get; set; }

        public List<display_all_HTML_Content_Result> HTMLContentList { get; set; }
    }
}