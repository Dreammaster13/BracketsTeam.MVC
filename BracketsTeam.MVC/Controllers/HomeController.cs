using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BracketsTeam.Datos;
using DBM = BracketsTeam.Datos.Models;

namespace BracketsTeam.MVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            using (var ctx = new DBContext_BracketsTeam())
            {
                /*var res = (from mp in ctx.Match_Player
                           join m in ctx.Match on mp.Match.IdMatch equals m.IdMatch
                           select mp); 
                
                foreach (var item in res)
                {
                    var id = item.IdMatch_Player;
                }*/
            }

            return View();
        }
    }
}