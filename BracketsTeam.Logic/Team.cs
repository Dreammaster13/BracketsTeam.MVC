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
        public static GenericResponse Insert(string tName, string tNameShort, int[] tIdsGame, bool tIsActive)
        {
            GenericResponse gr = new GenericResponse();

            string modName = tName.Left(Utilities.LengthDefinition.Team.Name);
            string modNameShort = tName.Left(Utilities.LengthDefinition.Team.NameShort).ToUpper();

            using (var ctx = new DBContext_BracketsTeam())
            {
                var newTeam = new MOD.Team()
                {
                    Name = modName,
                    NameShort = modNameShort,
                    IsActive = tIsActive
                };

                ctx.Team.Add(newTeam);
                int saveTeam = ctx.SaveChanges();

                var gt = new GenericTable(newTeam.IdTeam, "Team");
                gr.Registries.Add(gt);

                /* foreach (var item in tIdsGame)
                 {
                     var newTeamGame = new MOD.Team_Game()
                     {
                         IdGame = item,
                         IdTeam = newTeam.IdTeam
                     };

                     ctx.Team_Game.Add(newTeamGame);
                 }

                 int saveTeam_Games = ctx.SaveChanges();*/
            }

            return gr;
        }
    }
}
