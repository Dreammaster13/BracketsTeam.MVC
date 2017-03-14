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
                /*var playercst = new DBM.Player()
                {
                    FullName = "Test Full Name",
                    NickName = "Nickname Test",
                    BirthDate = new DateTime(1992, 5, 15)
                };

                var res = ctx.Player.Add(playercst);
                ctx.SaveChanges();*/
            }

            return View();
        }
    }
}