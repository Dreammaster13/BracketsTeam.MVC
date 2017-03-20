using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BracketsTeam.Entities;
using MOD = BracketsTeam.Entities.Models;

namespace BracketsTeam.Logic
{
    public static class Team
    {
        public static GenericResponse Insert(string tName, string tNameShort, int tIdGame, bool tIsActive)
        {
            GenericResponse gr = new GenericResponse();

            string modName = tName.Left(Utilities.LengthDefinition.Team.Name);
            string modNameShort = tName.Left(Utilities.LengthDefinition.Team.NameShort).ToUpper();

            using (var ctx = new DBContext_BracketsTeam())
            {
                var newTeam = new MOD.Team()
                {
                    IdGame = tIdGame,
                    Name = modName,
                    NameShort = modNameShort,
                    IsActive = tIsActive
                };

                ctx.Team.Add(newTeam);

                int save = ctx.SaveChanges();

                var gt = new GenericTable((save.Equals(1) ? newTeam.IdTeam : 0), "Team");
                gr.Registries.Add(gt);
            }

            return gr;
        }
    }
}
