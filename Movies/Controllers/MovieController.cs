using Movies.Domain.Abstract;
using Movies.Domain.Entities;
using Movies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Movies.WebUI.Controllers
{
    public class MovieController : Controller
    {
        private IMovieRepository repository;
        public int pageSize = 4;

        public MovieController(IMovieRepository repo)
        {
            repository = repo;
        }

        public ViewResult List(string category, int page = 1)
        {
            MoviesListViewModel model = new MoviesListViewModel
            {
                Movies =
                    repository
                    .Movies
                    .Where(p => category == null || p.Category == category)
                    .OrderBy(movie => movie.MovieId)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = category == null
                        ? repository.Movies.Count()
                        : repository.Movies.Where(movie => movie.Category == category).Count()
                },
                CurrentCategory = category
            };

            return View(model);

        }
    }
}