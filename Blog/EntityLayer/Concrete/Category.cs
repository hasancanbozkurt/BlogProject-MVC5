using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EntityLayer.Concrete
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }

        [StringLength(100)]
        public string CategoryName { get; set; }

        [StringLength(2000)]
        [AllowHtml]
        public string CategoryDescription { get; set; }

        public bool CategoryStatus { get; set; }
        public int? UstCategoryID { get; set; }
        public virtual Category UstCategory { get; set; }
        public ICollection <Blog> Blogs { get; set; }
    }
}
