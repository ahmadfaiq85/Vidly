using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vidly.Models;

namespace Vidly.Interfaces
{
   public interface IMovieRepository
    {
        Movie getDetail(int Id);
        IEnumerable<Genre> getGenres();
        void Add(Movie movie);
    }
}