using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Repositories;
using Vidly.Models;
using Vidly.Interfaces;

namespace Vidly.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _context;
        public ICustomerRepository Customers { get; private set; }
        public IMovieRepository Movies { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Customers = new CustomerRepository(_context);
            Movies = new MovieRepository(_context);
        }
        
        public void Complete()
        {
            _context.SaveChanges();
        }

    }
}