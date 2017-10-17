using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vidly.Interfaces
{
    public interface IUnitOfWork
    {
        ICustomerRepository Customers { get; }
        IMovieRepository Movies { get; }
        void Complete();
    }
}