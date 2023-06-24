using antsIncAPI.Data;
using antsIncAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using System.Net;
using System.Numerics;
using System.Text.Json.Serialization;

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
            DataTable tCustomer = DB.RetriveTable("GetAllCustomers");
            string jsonCustomer = JsonConvert.SerializeObject(tCustomer);
            return new
            {
                success = true,
                message = "success",
                result = new
                {
                    customer = JsonConvert.DeserializeObject<List<Customer>>(jsonCustomer)
                }
            };
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
            List<Parameter> parameters = new List<Parameter>()
            {
                new Parameter("@DNI", customer.DNI),
                new Parameter("@FirstName", customer.FirstName),
                new Parameter("@LastName", customer.LastName),
                new Parameter("@Phone", customer.Phone)                
            };

            bool result = DB.UpdateTable("ModifyCustomer", parameters);

            return new
            {
                sucess = result,
                message = result ? "Customer modified" : "Error, could not modify",
                result = ""
            };
        }

        [HttpGet]
        [Route("getCustomerInvoices")]
        public dynamic GetCustomerInvoices(string _id)
        {
            List<Parameter> parameters = new List<Parameter>()
            {
                new Parameter("@DNI", _id)
            };

            DataTable tInvoices = DB.RetriveTable("GetCustomerInvoices", parameters);
            string jsonInvoices = JsonConvert.SerializeObject(tInvoices);

            return new
            {
                success = true,
                message = "success",
                result = new
                {
                    customer = JsonConvert.DeserializeObject<List<Invoice>>(jsonInvoices)
                }
            };
        }
    }
}
