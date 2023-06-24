using antsIncAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Numerics;

namespace antsIncAPI.Controllers
{
    [ApiController]
    [Route("customers")]
    public class CustomerController : ControllerBase
    {
        /**
         *  Triggered by get request.
         *  No parameters.
         *  Returns the entire customer table from the DB.
         */
        [HttpGet]
        [Route("getAllCustomers")]
        public dynamic GetAllCustomers()
        {

            List<Customer> customers = new List<Customer>
            {
                new Customer
                {
                    DNI = "19236845",
                    FirstName = "Juan",
                    LastName = "Martinez",
                    Phone = "1594-3682"
                },
                new Customer
                {
                    DNI = "35789154",
                    FirstName = "Marco",
                    LastName = "Lopez",
                    Phone = "2295-3665"
                },
                new Customer
                {
                    DNI = "14725836",
                    FirstName = "Marta",
                    LastName = "Sanchez",
                    Phone = "3698-2358"
                }
            };

            return customers;

        }
        /**
         * Triggered by post request.
         * Parameter customer: a row for the database to update.
         * Returns a message with information about the request succesness. 
         */
        [HttpPost]
        [Route("modifyCustomer")]
        public dynamic ModifyCustomer(Customer customer)
        {
            return new
            {
                sucess = true,
                message = "Customer modified",
                tryBack = customer.FirstName,
                result = ""
            };
        }
    }
}
