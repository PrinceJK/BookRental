using AutoMapper;
using BookRental.Dtos;
using BookRental.Models;
using System;
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
        [HttpGet]
        public IHttpActionResult GetCustomers()
        {
            var customers = _context.Customers.ToList().Select(Mapper.Map<Customer, CustomerDto>);
            return Ok(customers);
        }

        //GET /api/customers/1
        [HttpGet]
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<Customer, CustomerDto>(customer));
        }

        //POST /api/customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDto.Id = customer.Id;
            return Created(new Uri(Request.RequestUri + "/" + customer), customerDto);
        }

        //PUT /api/customer/1
        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var customerIdDb = _context.Customers.SingleOrDefault(x => x.Id == id);
            if (customerIdDb == null)
            {
                return NotFound();
            }

            Mapper.Map(customerDto, customerIdDb);

            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var customerIdDb = _context.Customers.SingleOrDefault(x => x.Id == id);
            if (customerIdDb == null)
            {
                return NotFound();
            }
            _context.Customers.Remove(customerIdDb);
            _context.SaveChanges();
            return Ok();
        }
    }
}
