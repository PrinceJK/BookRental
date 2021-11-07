using BookRental.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace BookRental.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        //Get /api/customers
        [HttpGet]
        public IEnumerable<Customer> GetCustomers()
        {
            return _context.Customers.ToList();
        }

        //GET /api/customers/1
        public Customer GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return customer;
        }

        //POST /api/customers
        [HttpPost]
        public Customer CreateCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            _context.Customers.Add(customer);
            _context.SaveChanges();

            return customer;
        }

        //PUT /api/customer/1
        [HttpPut]
        public void UpdateCustomer(int id, Customer customer)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var customerIdDb = _context.Customers.SingleOrDefault(x => x.Id == id);
            if (customerIdDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            customerIdDb.Name = customer.Name;
            customerIdDb.Birthdate = customer.Birthdate;
            customerIdDb.IsSubScribedToNewsLetter = customer.IsSubScribedToNewsLetter;
            customerIdDb.MembershipType = customer.MembershipType;

            _context.SaveChanges();
        }

        [HttpDelete]
        public void DeleteCustomer(int id, Customer customer)
        {
            var customerIdDb = _context.Customers.SingleOrDefault(x => x.Id == id);
            if (customerIdDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            _context.Customers.Remove(customerIdDb);
            _context.SaveChanges();
        }
    }
}
