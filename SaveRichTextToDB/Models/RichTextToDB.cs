namespace SaveRichTextToDB.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class RichTextToDB : DbContext
    {
        public RichTextToDB()
            : base("name=RichTextToDB")
        {
        }

        public virtual DbSet<tbl_html_info> tbl_html_info { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
