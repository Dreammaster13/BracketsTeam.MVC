﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketsTeam.Datos.Models
{
    public class Team
    {
        public Team() { }

        public int IdTeam { get; set; }
        public int IdGame { get; set; }

        public string Name { get; set; }
        public string NameShort { get; set; }
        public bool IsActive { get; set; }

        public virtual Game Game { get; set; }
    }
}
