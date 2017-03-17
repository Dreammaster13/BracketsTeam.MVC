using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BracketsTeam.MVC.Controllers
{
    public class TeamController : Controller
    {
        // GET: Team
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public string Create(string name, string shortName, bool isActive)
        {
            return "FAK";
        }
    }
}