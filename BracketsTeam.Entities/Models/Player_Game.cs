using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketsTeam.Entities.Models
{
    public class Player_Game
    {
        public Player_Game() { }

        public int IdPlayer_Game { get; set; }
        public int IdPlayer { get; set; }
        public int IdGame { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Player Player { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Game Game { get; set; }
    }
}
