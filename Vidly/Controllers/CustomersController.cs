using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using Vidly.Interfaces;

namespace Vidly.Controllers
{
    [Authorize]
    public class CustomersController : Controller
    { 
        private IUnitOfWork _unitOfWork;

        public CustomersController(IUnitOfWork unitOfWork)
        { 
            _unitOfWork = unitOfWork;
        }
         
        // GET: Customers
        //[Authorize]
        public ActionResult Index()
        {
            //var customers = _context.Customers.Include(c => c.MembershipType).ToList(); //getCustomers();
            // don't use unless necessary 
            //if (MemoryCache.Default["Genres"] == null)
            //{
            //    MemoryCache.Defualt["Genres"] = _context.Genres.ToList();
            //}

            //var genres = MemoryCache.Default["Genres"] as IEnumerable<Genre>;
            return View(); 
        }

        public ActionResult New()
        {
            var membershipTypes = _unitOfWork.Customers.getMembershipTypes();
            var viewModel = new CustomerFormViewModel
            {
                Customer = new Customer(),
                MembershipTypes = membershipTypes
            };

            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _unitOfWork.Customers.getMembershipTypes()
                };

                return View("CustomerForm", viewModel);
            }

            if (customer.Id == 0)
                _unitOfWork.Customers.Add(customer);
            else
            {
                var customerInDb = _unitOfWork.Customers.getDetail(customer.Id);

                customerInDb.Name = customer.Name;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            }
            _unitOfWork.Complete();

            return RedirectToAction("Index", "Customers");
        }

        public ActionResult Details(int Id)
        {
            var customer = _unitOfWork.Customers.getDetail(Id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        public ActionResult Edit(int Id)
        {
            var customer = _unitOfWork.Customers.getDetail(Id);

            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _unitOfWork.Customers.getMembershipTypes()
            };

            return View("CustomerForm", viewModel);
        }

        //IEnumerable<Customer> getCustomers()
        //{
        //    return new List<Customer>
        //    {
        //        new Customer { Id = 1, Name = "Taha" },
        //        new Customer { Id = 2, Name = "Hosa" }
        //    };
        //}
    }
}