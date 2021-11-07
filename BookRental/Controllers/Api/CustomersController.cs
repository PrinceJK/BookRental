using BookRental.Models;
using System.Collections.Generic;
using System.Linq;
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
        public IEnumerable<Customer> GetCustomers()
        {
            return _context.Customers.ToList();
        }
    }
}
