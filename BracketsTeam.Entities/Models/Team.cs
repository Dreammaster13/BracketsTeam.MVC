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
    ///
    /// </summary>
    public class Team
    {
        public Team() { }

        public int IdTeam { get; set; }
        public int IdGame { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        ///
        /// </summary>
        public string NameShort { get; set; }
        /// <summary>
        ///
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        ///
        /// </summary>
        public virtual Game Game { get; set; }
    }
}
