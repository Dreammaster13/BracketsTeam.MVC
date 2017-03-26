using BracketsTeam.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MOD = BracketsTeam.Models;

namespace BracketsTeam.Logic
{
    public static class Game
    {
        public static Dictionary<int, string> ActiveList()
        {
            var dict = new Dictionary<int, string>();

            using (var ctx = new DBContext_BracketsTeam())
            {
                var gameList = ctx.Game.Where(x => x.IsActive).ToList();
                foreach (var item in gameList) dict.Add(item.IdGame, item.Name + " (" + item.Alias + ")");
            }

            return dict;
        }

        #region JSON

        public static string ActiveListJSON()
        {
            var jsonString = string.Empty;
            using (var ctx = new DBContext_BracketsTeam())
            {
                var gameList = ctx.Game.Where(x => x.IsActive).ToList();
                jsonString = JsonConvert.SerializeObject(gameList);
            }

            return jsonString;
        }

        #endregion
    }
}
