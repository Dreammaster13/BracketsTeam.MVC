using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BracketsTeam.Logic;

namespace BracketsTeam.MVC.Controllers
{
    public class GameController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public string List()
        {
            var res = Game.ActiveListJSON();
            return res;
        }
    }
}