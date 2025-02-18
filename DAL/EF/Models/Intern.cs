﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class Intern
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("Student")]
        public int S_ID { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

     
        public string Phone { get; set; }

   
        public string Education { get; set; }

        public string Skills { get; set; }
        public virtual Student Student { get; set; }
    }
}
