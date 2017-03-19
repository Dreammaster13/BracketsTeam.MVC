using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using BracketsTeam.Entities;

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
                foreach (var item in gameList) dict.Add(item.IdGame, item.Name);
            }

            return dict;
        }
    }
}
