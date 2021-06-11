﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Shared
{
    public class Roles
    {
        [Key]
        public int Id { get; set; }
        public string DescriptionType { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
