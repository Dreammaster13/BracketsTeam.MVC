using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketsTeam.Models
{
    public class User
    {
        public User() { }

        public int IdUser { get; set; }
        public int IdPlayer { get; set; }
        /// <summary>
        /// (Unique) Username of the player
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Password { get; set; }

        public virtual Player Player { get; set; }
    }
}
