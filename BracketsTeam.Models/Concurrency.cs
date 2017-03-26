using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketsTeam.Models
{
    public class Concurrency
    {
        public Concurrency() { }

        public int IdConcurrency { get; set; }
        public int IdUser { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string TableName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string JSON { get; set; }

        public virtual User User { get; set; }
    }
}
