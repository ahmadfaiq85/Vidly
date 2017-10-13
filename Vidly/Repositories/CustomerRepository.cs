using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Vidly.Models;

namespace Vidly.Repositories
{

    public class CustomerRepository
    {
        private readonly ApplicationDbContext _context;

        public CustomerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Customer getDetail(int Id)
        {
            return _context.Customers
                  .Include(c => c.MembershipType)
                  .SingleOrDefault(c => c.Id == Id);
        }


    }
}