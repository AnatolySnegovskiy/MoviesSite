using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Movies.Domain.Abstract;
using Movies.Domain.Entities;
using Movies.HtmlHelpers;
using Movies.Models;
using Movies.WebUI.Controllers;

namespace Movies.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
        }

        [TestMethod]
        public void Can_Paginate()
        {
            // Организация (arrange)
            Mock<IMovieRepository> mock = new Mock<IMovieRepository>();
            mock.Setup(m => m.Movies).Returns(new List<Movie>
            {
                new Movie { MovieId = 1, Name = "Игра1"},
                new Movie { MovieId = 2, Name = "Игра2"},
                new Movie { MovieId = 3, Name = "Игра3"},
                new Movie { MovieId = 4, Name = "Игра4"},
                new Movie { MovieId = 5, Name = "Игра5"}
            });
            MovieController controller = new MovieController(mock.Object)
            {
                pageSize = 3
            };

            // Действие (act)
            IEnumerable<Movie> result = (IEnumerable<Movie>)controller.List(2).Model;

            // Утверждение (assert)
            List<Movie> movies = result.ToList();
            Assert.IsTrue(movies.Count == 2);
            Assert.AreEqual(movies[0].Name, "Игра4");
            Assert.AreEqual(movies[1].Name, "Игра5");
        }


        [TestMethod]
        public void Can_Generate_Page_Links()
        {

            // Организация - определение вспомогательного метода HTML - это необходимо
            // для применения расширяющего метода
            HtmlHelper myHelper = null;

            // Организация - создание объекта PagingInfo
            PagingInfo pagingInfo = new PagingInfo
            {
                CurrentPage = 2,
                TotalItems = 28,
                ItemsPerPage = 10
            };

            // Организация - настройка делегата с помощью лямбда-выражения
            Func<int, string> pageUrlDelegate = i => "Page" + i;

            // Действие
            MvcHtmlString result = myHelper.PageLinks(pagingInfo, pageUrlDelegate);

            // Утверждение
            Assert.AreEqual(@"<a class=""btn btn-default"" href=""Page1"">1</a>"
                + @"<a class=""btn btn-default btn-primary selected"" href=""Page2"">2</a>"
                + @"<a class=""btn btn-default"" href=""Page3"">3</a>",
                result.ToString());
        }
    }
}
