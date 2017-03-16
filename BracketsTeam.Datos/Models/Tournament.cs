using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketsTeam.Datos.Models
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
        /// Has the tournament started?
        /// </summary>
        public bool HasStarted { get; set; }
        /// <summary>
        /// Has the tournament ended?
        /// </summary>
        public bool HasEnded { get; set; }
    }
}
