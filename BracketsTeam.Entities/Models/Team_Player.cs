using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketsTeam.Entities.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class Team_Player
    {
        public Team_Player() { }

        public int IdTeam_Player { get; set; }
        public int IdTeam { get; set; }
        public int IdPlayer { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsPlayerMain { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsPlayerAdmin { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Team Team { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Player Player { get; set; }
    }
}
