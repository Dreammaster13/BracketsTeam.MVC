using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketsTeam.Datos.Models
{
    public class Match
    {
        public Match() { }

        public int IdMatch { get; set; }

        public int IdTeamOne { get; set; }
        public int IdTeamTwo { get; set; }
        public int IdTeamWinner { get; set; }

        public DateTime DatePlayed { get; set; }
        public string MatchCode { get; set; }
        public string Observation { get; set; }

        public virtual Team TeamOne { get; set; }
        public virtual Team TeamTwo { get; set; }
        public virtual Team TeamWinner { get; set; }
    }
}
