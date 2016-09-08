using AGL.DevelopersTest.Interfaces;
using AGL.DevelopersTest.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AGL.DevelopersTest.Web.Controllers
{
    public class HomeController : Controller
    {
        IPersonRepository repo;
        public HomeController(IPersonRepository repo)
        {
            this.repo = repo;
        }

        // GET: Home
        public ActionResult Index()
        {
            var people = repo.GetPeople();
            var cats = people.Where(x => x.pets != null &&  x.pets.Any(c => c.type == Enums.PetType.Cat)).SelectMany(x => x.pets).Where(x => x.type == Enums.PetType.Cat).ToList().OrderBy(x => x.name).ToList();
            return View(cats);
        }
    }
}