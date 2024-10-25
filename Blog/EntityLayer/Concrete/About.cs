using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EntityLayer.Concrete
{
    public class About
    {
        [Key]
        public int AboutID { get; set; }

        [AllowHtml]
        [StringLength(1500)]
        public string AboutContent1 { get; set; }

        [AllowHtml]
        [StringLength(1500)]
        public string AboutContent2 { get; set; }

        [StringLength(200)]
        public string AboutImage1 { get; set; }

        [StringLength(200)]
        public string AboutImage2 { get; set; }

    }
}
