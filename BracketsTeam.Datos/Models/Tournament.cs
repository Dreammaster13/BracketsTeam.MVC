using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketsTeam.Datos.Models
{
    public class Tournament
    {
        public Tournament() { }

        public int IdTournament { get; set; }
        public int IdPrize { get; set; }

        public string Name { get; set; }
        public bool HasEnded { get; set; }

        public virtual Prize Prize { get; set; }
    }
}
