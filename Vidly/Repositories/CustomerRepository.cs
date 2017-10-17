using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Vidly.Models;
using Vidly.Interfaces;

namespace Vidly.Repositories
{
    public class CustomerRepository : ICustomerRepository
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

        public IEnumerable<MembershipType> getMembershipTypes()
        {
            return _context.MembershipTypes.ToList();
        }

        public void Add(Customer customer)
        {
            _context.Customers.Add(customer);
        }

    }
}