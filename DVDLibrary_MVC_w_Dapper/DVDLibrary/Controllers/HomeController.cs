using System;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using DVDLibrary.Data;
using DVDLibrary.Models;
using Microsoft.SqlServer.Server;

namespace DVDLibrary.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAllDVDs()
        {
            var repo = new DVDRepo();

            var results = repo.GetAllDVDs();

            ViewBag.Title = "DVDs in Collection";

            if (results.Count == 0)
                return View("NoResults");

            return View("ListDVDsByTitle", results);
        }

        public ActionResult AddDVD()
        {
            var repo = new DVDRepo();
            var vm = new AddDVDVM();

            vm.CreateActorList(repo.GetAllActors());
            vm.CreateMPAAList(repo.GetAllMPAA());
            vm.CreateStudioList(repo.GetAllStudios());

            return View("AddDVD", vm);
        }

        [HttpPost]
        public ActionResult AddDVD(AddDVDVM vm)
        {
            var repo = new DVDRepo();

            if (ModelState.IsValid)
            {

                int dvdid = repo.AddDVD(vm.DvdToAdd);

                foreach (var actorId in vm.ActorSelectedValues)
                {
                    repo.AddDVDActorDetails(dvdid, actorId);
                }

                return View("SuccessPage");
            }

            else
            {
                vm.CreateActorList(repo.GetAllActors());
                vm.CreateMPAAList(repo.GetAllMPAA());
                vm.CreateStudioList(repo.GetAllStudios());
                return View("AddDVD", vm);
            }

        }

        [HttpPost]
        public ActionResult ListDVDsByTitle(string title)
        {
            var repo = new DVDRepo();

            var results = repo.GetDVDByTitle(title);
            ViewBag.title = "Search Results";

            if (title == String.Empty)
            {
                return View("EmptySearch");
            }
            
            if(results.Count == 0)
                return View("NoResults");

            //redirect to List DVDs View
            return View(results);
        }
        
        public ActionResult SearchByTitle()
        {
            //redirect to List DVDs View
            return View();
        }

        public ActionResult DVDDetails(int id)
        {
            var vm = new DVDDetailVM();
            var repo = new DVDRepo();
            var results = new List<DVDActorDetail>();
            results = repo.GetActorDetails(id);

            vm.Dvd = repo.GetDVDById(id);
            vm.StudioDescription = repo.GetStudioDescription(vm.Dvd.StudioID);
            vm.ActorNames = repo.GetActorById(results);

            return View(vm);
        }

        public ActionResult ListBorrowersByDVD(int id)
        {
            var vm = new DvdBorrowerDetailVM();
            var dvdRepo = new DVDRepo();
            var borrowerRepo = new BorrowerRepo();

            vm.Dvd = dvdRepo.GetDVDById(id);
            vm.BorrowerDetails = borrowerRepo.GetAllBorrowerDetails(id);
            vm.Borrowers = borrowerRepo.GetBorrowerById(vm.BorrowerDetails);

            return View(vm);
        }

        public ActionResult RemoveDVD(int id)
        {
            var repo = new DVDRepo();

            repo.RemoveDVD(id);

            return View("SuccessPage");
        }

    }
}