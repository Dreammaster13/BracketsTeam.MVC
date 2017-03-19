using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketsTeam.Entities.Models
{
    public class Team_Tournament
    {
        public Team_Tournament() { }

        public int IdTeam_Tournament { get; set; }
        public int IdTeam { get; set; }
        public int IdTournament { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Team Team { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Tournament Tournament { get; set; }
    }
}
