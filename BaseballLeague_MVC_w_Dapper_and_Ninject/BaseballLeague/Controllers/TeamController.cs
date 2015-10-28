using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BaseballLeague.Data;
using BaseballLeague.Models;

namespace BaseballLeague.Controllers
{
    public class TeamController : Controller
    {
        public ActionResult Index()
        {
            var repo = new TeamRepo();
            var teams = repo.GetTeams(1);

            return View(teams);
        }

        public ActionResult AddTeam()
        {
            var repo = new TeamRepo();
            var VM = new AddTeamVM();
            VM.TeamList = repo.GetTeams(1);

            return View(VM);
        }

        [HttpPost]
        public ActionResult AddTeam(AddTeamVM VM)
        {
            var repo = new TeamRepo();


            if (ModelState.IsValid)
            {
                int teamID = repo.AddTeam(VM.NewTeam);
                repo.AddLeagueTeamDetails(teamID, 1);

                return View("SuccessPage");
            }

            return View(VM);
        }
    }
}