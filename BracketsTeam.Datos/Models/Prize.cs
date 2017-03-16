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
    public class Prize
    {
        public Prize() { }

        public int IdPrize { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ExchangeRate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal Value { get; set; }
    }
}
