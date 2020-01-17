using Movies.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Movies.Controllers
{
    public class NavController : Controller
    {
        private IMovieRepository repository;

        public NavController(IMovieRepository repo)
        {
            repository = repo;
        }

        public PartialViewResult Menu(string category = null)
        {
            ViewBag.SelectedCategory = category;
            IEnumerable<string> categories = repository.Movies
                .Select(game => game.Category)
                .Distinct()
                .OrderBy(x => x);
            return PartialView(categories);
        }
    }
}