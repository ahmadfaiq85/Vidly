using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Repositories;
using Vidly.Models;

namespace Vidly.Persistence
{
    public class UnitOfWork
    {
        private ApplicationDbContext _context;
        public CustomerRepository CustomerRepository;
        public MovieRepository MovieRepository;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            CustomerRepository = new CustomerRepository(_context);
            MovieRepository = new MovieRepository(_context);
        }



        public void Complete()
        {
            _context.SaveChanges();
        }

    }
}