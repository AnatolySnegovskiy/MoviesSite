using Movies.Domain.Entities;
using System.Collections.Generic;

namespace Movies.Domain.Abstract
{
    public interface IMovieRepository
    {
        IEnumerable<Movie> Movies { get; }
    }
}
