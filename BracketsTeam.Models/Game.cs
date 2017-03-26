using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketsTeam.Models
{
    /// <summary>
    /// Game Class
    /// </summary>
    public class Game
    {
        public Game() { }

        public int IdGame { get; set; }

        /// <summary>
        /// Name of the game
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Alias or short name for the game
        /// </summary>
        public string Alias { get; set; }
        /// <summary>
        /// Is the game active?
        /// </summary>
        public bool IsActive { get; set; }
    }
}
