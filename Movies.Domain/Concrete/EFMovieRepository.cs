using Movies.Domain.Abstract;
using Movies.Domain.Entities;
using System.Collections.Generic;

namespace Movies.Domain.Concrete
{
    public class EFMovieRepository : IMovieRepository
    {
        EFDbContext context = new EFDbContext();

        public IEnumerable<Movie> Movies
        {
            get { return context.Movies; }
        }

        public void SaveGame(Movie movie)
        {
            if (movie.MovieId == 0)
                context.Movies.Add(movie);
            else
            {
                Movie dbEntry = context.Movies.Find(movie.MovieId);
                if (dbEntry != null)
                {
                    dbEntry.Name = movie.Name;
                    dbEntry.Description = movie.Description;
                    dbEntry.Link = movie.Link;
                    dbEntry.Category = movie.Category;
                }
            }
            context.SaveChanges();
        }

        public Movie DeleteGame(int gameId)
        {
            Movie dbEntry = context.Movies.Find(gameId);
            if (dbEntry != null)
            {
                context.Movies.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
