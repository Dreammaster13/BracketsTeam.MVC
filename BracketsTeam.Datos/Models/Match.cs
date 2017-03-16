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
    public class Match
    {
        public Match() { }

        public int IdMatch { get; set; }

        public int IdTeamOne { get; set; }
        public int IdTeamTwo { get; set; }
        public int IdTeamWinner { get; set; }

        /// <summary>
        /// Date of the match
        /// </summary>
        public DateTime DatePlayed { get; set; }
        /// <summary>
        /// Match Code of te game played (sometimes known as IdMatch)
        /// </summary>
        public string MatchCode { get; set; }
        /// <summary>
        /// Optional Observation on the played match
        /// </summary>
        public string Observation { get; set; }

        /// <summary>
        /// First Team to play
        /// </summary>
        public virtual Team TeamOne { get; set; }
        /// <summary>
        /// Second Team to play
        /// </summary>
        public virtual Team TeamTwo { get; set; }
        /// <summary>
        /// Winner Team
        /// </summary>
        public virtual Team TeamWinner { get; set; }
    }
}
