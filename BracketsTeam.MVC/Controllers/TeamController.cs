using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BracketsTeam.Logic;

namespace BracketsTeam.MVC.Controllers
{
    public class TeamController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.GameList = Game.ActiveList();
            return View();
        }

        [HttpPost]
        public JsonResult Create(string name, string shortName, int[] idsGame, bool isActive)
        {
            var genRes = Team.Insert(name, shortName, idsGame, isActive);
            string msg = "Placeholder";
            if (genRes.Registries.Count > 0) msg = genRes.Registries.First().IdRegistry > 0 ? Utilities.Messages.Team.AddTeam_Success : Utilities.Messages.Team.AddTeam_Error_General;

            return Json(new { msg });
        }
    }
}