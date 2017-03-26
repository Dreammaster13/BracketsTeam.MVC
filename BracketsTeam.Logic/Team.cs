using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BracketsTeam.Entities;
using MOD = BracketsTeam.Models;
using Newtonsoft.Json;
using Firefrog.Crypto;

namespace BracketsTeam.Logic
{
    public static class Team
    {
        public static GenericResponse Insert(string tName, string tNameShort, int[] tIdsGame, bool tIsActive)
        {
            GenericResponse gr = new GenericResponse();

            string modName = tName.Trim().Left(Utilities.LengthDefinition.Team.Name);
            string modNameShort = tName.Trim().Left(Utilities.LengthDefinition.Team.NameShort).ToUpper();

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

                var ltg = new List<MOD.Team_Game>();
                foreach (var item in tIdsGame)
                {
                    var newTeamGame = new MOD.Team_Game()
                    {
                        IdGame = item,
                        IdTeam = newTeam.IdTeam
                    };

                    ctx.Team_Game.Add(newTeamGame);
                    ltg.Add(newTeamGame);
                }

                int saveTeam_Games = ctx.SaveChanges();

                foreach (var item in ltg)
                {
                    var gtn = new GenericTable(item.IdTeam_Game, "Team_Game");
                    gr.Registries.Add(gtn);
                }
            }

            return gr;
        }

        public static string Search(int? idTeam = null, string nameTeam = null, string nameShortTeam = null, bool? isActiveTeam = null)
        {
            var jsonString = string.Empty;
            using (var ctx = new DBContext_BracketsTeam())
            {
                var searchedTeam = ctx.Team.Where(x => x.IdTeam == (idTeam ?? x.IdTeam))
                                    .Where(x => x.Name.Contains(nameTeam ?? x.Name))
                                    .Where(x => x.NameShort.Contains(nameShortTeam ?? x.NameShort))
                                    .Where(x => x.IsActive == (isActiveTeam ?? x.IsActive)).ToList();
                jsonString = JsonConvert.SerializeObject(searchedTeam);
            }
            return jsonString;
        }

        public static void test(string pass)
        {
            string dbpass = "dbpass";

            //(new)generate pass
            var crypt = new Crypter(pass, false);
            string guardar_pass_db = crypt.GenerateNewSaltedHash();
            
            //compare entered pass
            var crypt2 = new Crypter(dbpass, true);
            if (crypt2.CompareSaltedHash(pass))
            {
                //pass is correct
            }
        }
    }
}
