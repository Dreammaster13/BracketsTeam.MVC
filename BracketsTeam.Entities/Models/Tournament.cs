using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketsTeam.Entities.Models
{
    /// <summary>
    /// Tournament Class
    /// </summary>
    public class Tournament
    {
        public Tournament() { }

        public int IdTournament { get; set; }

        /// <summary>
        /// Tournament name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Maximum amount of players per tournament
        /// </summary>
        public int MaxPlayers { get; set; }
        /// <summary>
        /// Maximum amount of players per team
        /// </summary>
        public int MaxPlayersTeam { get; set; }
        /// <summary>
        /// Has the tournament started?
        /// </summary>
        public bool HasStarted { get; set; }
        /// <summary>
        /// Has the tournament ended?
        /// </summary>
        public bool HasEnded { get; set; }
    }
}
