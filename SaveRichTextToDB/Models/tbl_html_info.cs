namespace SaveRichTextToDB.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_html_info
    {
        public int id { get; set; }

        [Required]
        public string html_content { get; set; }
    }
}
