using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BracketsTeam.Datos.Models;

namespace BracketsTeam.Datos
{
    public class DBContext_BracketsTeam : DbContext
    {
        public DBContext_BracketsTeam () : base("name=ConStr-DB_BracketsTeam") { }

        public virtual DbSet<Player> Player { get; set; }
        public virtual DbSet<Team> Team { get; set; }
    }
}
