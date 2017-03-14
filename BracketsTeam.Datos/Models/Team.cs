using System;
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
        //public Team() { }

        [Key]
        public int IdTeam { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
