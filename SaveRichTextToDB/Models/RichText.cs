using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SaveRichTextToDB.Models
{
    public class RichText
    {
        /// <summary>
        /// Gets or sets the HTML content property.
        /// </summary>
        [AllowHtml]
        [Required]
        [Display(Name = "HTML Content")]
        public string HtmlContent { get; set; }

        /// <summary>
        /// Gets or sets message property.
        /// </summary>
        [Display(Name = "Message")]
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether it is valid or not property.
        /// </summary>
        [Display(Name = "Is Valid")]
        public bool IsValid { get; set; }

        /// <summary>
        /// Gets or sets list property.
        /// </summary>
        public List<tbl_html_info> HTMLContentList { get; set; }
    }
}