using Movies.Domain.Abstract;
using Movies.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Movies.Controllers
{
    public class AdminController : Controller
    {
        IMovieRepository repository;

        public AdminController(IMovieRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index()
        {
            return View(repository.Movies);
        }

        public ViewResult Edit(int movieId)
        {
            Movie movie = repository.Movies
                .FirstOrDefault(g => g.MovieId == movieId);
            return View(movie);
        }

        [HttpPost]
        public ActionResult Edit(Movie movie)
        {
            if (ModelState.IsValid)
            {
                repository.SaveGame(movie);
                TempData["message"] = string.Format("Изменения в Фильме \"{0}\" были сохранены", movie.Name);
                return RedirectToAction("Index");
            }
            else
            {
                return View(movie);
            }
        }

        public ViewResult Create()
        {
            return View("Edit", new Movie());
        }

        [HttpPost]
        public ActionResult Delete(int movieId)
        {
            Movie deletedGame = repository.DeleteGame(movieId);
            if (deletedGame != null)
            {
                TempData["message"] = string.Format("Фильм \"{0}\" был удален", deletedGame.Name);
            }
            return RedirectToAction("Index");
        }
    }
}