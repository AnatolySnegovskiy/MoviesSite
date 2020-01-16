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

        public ViewResult List(int page = 1)
        {
            MoviesListViewModel model = new MoviesListViewModel
            {
                Movies =
                    repository
                    .Movies
                    .OrderBy(movie => movie.MovieId)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = repository.Movies.Count()
                }
            };

            return View(model);

        }
    }
}