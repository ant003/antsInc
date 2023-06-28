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
         *  Returns a customers list
         */
        [HttpGet]
        [Route("getAllCustomers")]
        public dynamic GetAllCustomers()
        {
            DataTable tCustomer = DB.RetriveTable("GetAllCustomers");
            string jsonCustomer = JsonConvert.SerializeObject(tCustomer);
            return JsonConvert.DeserializeObject<List<Customer>>(jsonCustomer);
        }
        /**
         * Triggered by post request.
         * Parameter customer: a row for the database to update.
         * Parameter oldDNI: the original DNI before update it (if applicable)
         * Returns a message with information about the request successness. 
         */
        [HttpPost]
        [Route("modifyCustomer")]
        public dynamic ModifyCustomer(Customer customer, string oldDNI)
        {
            List<Parameter> parameters = new List<Parameter>()
            {
                new Parameter("@CurrentDNI", oldDNI),
                new Parameter("@NewDNI", customer.DNI),
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

        /**
         * Triggered by get request.
         * Parameter _id: The customer DNI which invoices are retrieve.
         * Returns that customer invoices in a list from the DB. 
         */
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
            return JsonConvert.DeserializeObject<List<Invoice>>(jsonInvoices);
        }

        /**
         *  Triggered by get request.
         *  Parameter DNI: the customer dni, from the customer retrieved.
         *  Returns the customer corresponding with the dni
         */
        [HttpGet]
        [Route("getACustomer")]
        public dynamic GetAnInvoice(string dni)
        {
            List<Parameter> parameters = new List<Parameter>()
            {
                new Parameter("@DNI", dni)
            };
            DataTable tCustomer = DB.RetriveTable("GetACustomer", parameters);
            string jsonCustomer = JsonConvert.SerializeObject(tCustomer);
            return JsonConvert.DeserializeObject<List<Customer>>(jsonCustomer);
        }
    }
}
