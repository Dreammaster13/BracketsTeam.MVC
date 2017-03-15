using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketsTeam.Datos.Models
{
    public class Team_Player
    {
        public Team_Player() { }

        public int IdTeam_Player { get; set; }
        public int IdTeam { get; set; }
        public int IdPlayer { get; set; }

        public virtual Team Team { get; set; }
        public virtual Player Player { get; set; }
    }
}
