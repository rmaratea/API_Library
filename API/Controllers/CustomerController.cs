﻿using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace API.Controllers
{

    public class CustomerController : ApiController
    {
        static readonly ICustomerRepository repository = new CustomerRepository();

        public IEnumerable<Customer> GetAllCustomers()
        {
            return repository.GetAll();
        }

        public Customer GetCustomer(string customerID)
        {
            Customer customer = repository.Get(customerID);
            if (customer == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return customer;
        }

        public IEnumerable<Customer> GetCustomersByCountry(string country)
        {
            return repository.GetAll().Where(
                c => string.Equals(c.Country, country,
                         StringComparison.OrdinalIgnoreCase));
        }

        public Customer PostProduct(Customer customer)
        {
            customer = repository.Add(customer);
            return customer;
        }

        public HttpResponseMessage PostCustomer(Customer customer)
        {
            customer = repository.Add(customer);
            var response = Request.CreateResponse
                    <Customer>(HttpStatusCode.Created, customer);

            string uri = Url.Link("DefaultApi",
                            new { customerID = customer.CustomerID });
            response.Headers.Location = new Uri(uri);
            return response;
        }

        public void PutProduct(string customerID, Customer customer)
        {
            customer.CustomerID = customerID;
            if (!repository.Update(customer))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        public void DeleteProduct(string customerID)
        {
            Customer customer = repository.Get(customerID);
            if (customer == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            repository.Remove(customerID);
        }
    }

}
