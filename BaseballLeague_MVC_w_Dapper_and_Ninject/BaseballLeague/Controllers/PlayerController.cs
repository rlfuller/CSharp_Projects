using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BaseballLeague.Data;
using BaseballLeague.Models;
using System.Configuration;

namespace BaseballLeague.Controllers
{
    public class PlayerController : Controller
    {
        public static readonly string Mode = ConfigurationManager.AppSettings["Mode"];
        private IPlayerRepo _playerRepo;
        private ITeamRepo _teamRepo;

        public PlayerController(IPlayerRepo playerRepo, ITeamRepo teamRepo)
        {
            _playerRepo = playerRepo;
            _teamRepo = teamRepo;
        }

        public ActionResult AddPlayer()
        {
            var vm = new AddPlayerVM();
            
            vm.CreateTeamList(_teamRepo.GetTeams());
            vm.CreatePositionList(_playerRepo.GetPositions());

            return View("AddPlayer", vm);
        }

        [HttpPost]
        public ActionResult AddPlayer(AddPlayerVM vm)
        {
            if (ModelState.IsValid)
            {
                var successVM = new AddPlayerSuccessVM();
                Player player = _playerRepo.AddPlayer(vm.PlayerToAdd);
                successVM.PlayerToAdd = player;
                successVM.Position = _playerRepo.GetPositionByID(vm.PlayerToAdd.PositionID);
                successVM.Team = _playerRepo.GetTeamByID(vm.PlayerToAdd.TeamID);
                
                return View("AddPlayerSuccess", successVM);
            }

            else
            {
                vm.CreateTeamList(_teamRepo.GetTeams());
                vm.CreatePositionList(_playerRepo.GetPositions());
                return View("AddPlayer", vm);
            }
        }

        public ActionResult GetPlayers()
        {
            var vm = new ListPlayersVM();

            vm.CreateTeamList(_teamRepo.GetTeams());
            

            return View("GetPlayersByTeam", vm);
        }

        [HttpPost]
        public ActionResult ListPlayers(ListPlayersVM vm)
        {
            
            var results = _playerRepo.GetPlayers(vm.SelectedValue);
            ViewBag.Team = _playerRepo.GetTeamByID(vm.SelectedValue);

            return View(results);
        }
    }
}