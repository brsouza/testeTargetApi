﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace testeTargetAPI.Models.Usuario
{
    public class Usuario
    {

        [Key]
        public int id { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
    }
}
