using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketsTeam.Entities.Models
{
    /// <summary>
    /// Player Class
    /// </summary>
    public class Player
    {
        public Player() { }

        public int IdPlayer { get; set; }

        /// <summary>
        /// "RUT" of the player
        /// </summary>
        public int RUT { get; set; }
        /// <summary>
        /// "Digito Verificador" of the player
        /// </summary>
        public string DV { get; set; }
        /// <summary>
        /// Name of the player
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Last name of the player
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// (Unique) Username of the player
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// Nickname of the player
        /// </summary>
        public string NickName { get; set; }
        /// <summary>
        /// Alternative nickname of the player
        /// </summary>
        public string AltNickName { get; set; }
        /// <summary>
        /// Birth date of the player
        /// </summary>
        public DateTime BirthDate { get; set; }
        /// <summary>
        /// Is the player active?
        /// </summary>
        public bool IsActive { get; set; }
    }
}
