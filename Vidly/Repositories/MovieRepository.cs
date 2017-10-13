using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;
using System.Data.Entity;

namespace Vidly.Repositories
{
    public class MovieRepository
    {
        private ApplicationDbContext _context;
        public MovieRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Movie getDetail(int Id)
        {
            return _context.Movies
                .Include(m => m.Genre)
                .SingleOrDefault(m => m.Id == Id);
        }

        public IEnumerable<Genre> getGenres()
        {
            return _context.Genres.ToList();
        }

        public void Add(Movie movie)
        {
            _context.Movies.Add(movie);
        }
    }
}