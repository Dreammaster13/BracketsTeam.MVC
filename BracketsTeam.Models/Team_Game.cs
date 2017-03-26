using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketsTeam.Models
{
    public class Team_Game
    {
        public Team_Game() { }

        public int IdTeam_Game { get; set; }
        public int IdTeam { get; set; }
        public int IdGame { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Team Team { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Game Game { get; set; }
    }
}
