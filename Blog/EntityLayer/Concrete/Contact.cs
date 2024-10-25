﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Contact
    {
        [Key]
        public int ContactID { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(100)]
        public string SurName { get; set; }

        [StringLength(200)]
        public string Mail { get; set; }

        [StringLength(200)]
        public string Subject { get; set; }

        [StringLength(2000)]
        public string Message { get; set; }

        public DateTime MessageDate { get; set; }
    }
}
