using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiApp.Models;

namespace WebApiApp.Controllers.Api
{
    public class CustomerController : ApiController
    {
        //GET
        public IHttpActionResult GetAllCustomer()
        {
            IList<CustomerViewModel> customers = null;
            using (var x = new WebApiEntities())
            {
                customers = x.Customers
                    .Select(c => new CustomerViewModel()
                    {
                        Id = c.id,
                        Name = c.name,
                        Email = c.email,
                        Address = c.address,
                        Phone = c.phone
                    }).ToList<CustomerViewModel>();

                if (customers.Count == 0)
                    return NotFound();
                return Ok(customers);

            }
        }
        //GET BY ID
        public IHttpActionResult GetCustomer(int id)
        {
            CustomerViewModel customers = null;
            using (var x = new WebApiEntities())
            {
                customers = x.Customers
                    .Where(i => i.id == id)
                    .Select(c => new CustomerViewModel()
                    {
                        Id = c.id,
                        Name = c.name,
                        Email = c.email,
                        Address = c.address,
                        Phone = c.phone
                    }).FirstOrDefault();

                return Ok(customers);

            }
        }

        //POST
        public IHttpActionResult PostNewCustomer(CustomerViewModel customer)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data, please check your input value");

            using (var x = new WebApiEntities())
            {
                x.Customers.Add(new Customer()
                {
                    name = customer.Name,
                    email = customer.Email,
                    address = customer.Address,
                    phone = customer.Phone
                });

                x.SaveChanges();
            }

            return Ok();
        }

        public IHttpActionResult PutCustomer(CustomerViewModel customer)
        {
            if (!ModelState.IsValid)
                return BadRequest("This is invalid model. Please recheck!");

            using (var x = new WebApiEntities())
            {
                var checkExistingCustomer = x.Customers.Where(c => c.id == customer.Id)
                    .FirstOrDefault<Customer>();
                if (checkExistingCustomer != null)
                {
                    checkExistingCustomer.name = customer.Name;
                    checkExistingCustomer.address = customer.Address;
                    checkExistingCustomer.phone = customer.Phone;

                    x.SaveChanges();
                }
                else
                    return NotFound();
            }

            return Ok();
        }

        public IHttpActionResult DeleteCustomer(int id)
        {
            if (id <= 0)
                return BadRequest("PLease enter valid customer Id");

            using (var x = new WebApiEntities())
            {
                var customer = x.Customers
                    .Where(c => c.id == id)
                    .FirstOrDefault();

                x.Entry(customer).State = System.Data.Entity.EntityState.Deleted;
                x.SaveChanges();
            }

            return Ok();
        }
    }
}
