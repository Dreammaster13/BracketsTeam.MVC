using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketsTeam.Datos.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class Match_Player
    {
        public Match_Player() { }

        public int IdMatch_Player { get; set; }
        public int IdPlayer { get; set; }
        public int IdMatch { get; set; }
        public int IdTeam_Tournament { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Player Player { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Match Match { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Team_Tournament Team_Tournament { get; set; }
    }
}
