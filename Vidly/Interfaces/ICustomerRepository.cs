using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vidly.Repositories;
using Vidly.Models;

namespace Vidly.Interfaces
{
    public interface ICustomerRepository 
    {
        Customer getDetail(int Id);
        IEnumerable<MembershipType> getMembershipTypes();
        void Add(Customer customer);

    }
}
