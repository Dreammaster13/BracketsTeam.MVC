using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketsTeam.Models
{
    public class Tournament_Prize
    {
        public int IdTournament_Prize { get; set; }
        public int IdTournament { get; set; }
        public int IdPrize { get; set; }

        /// <summary>
        ///
        /// </summary>
        public decimal ApproximateValue { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Tournament Tournament { get; set; }
        /// <summary>
        ///
        /// </summary>
        public virtual Prize Prize { get; set; }
    }
}
