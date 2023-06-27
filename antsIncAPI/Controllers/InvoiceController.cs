using antsIncAPI.Data;
using antsIncAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;

namespace antsIncAPI.Controllers
{
    [ApiController]
    [Route("invoices")]
    public class InvoiceController
    {
        /**
         *  Triggered by get request.
         *  Parameter _id: the invoice id which is retrieved.
         *  Returns the invoice corresponding with the id
         */
        [HttpGet]
        [Route("getAnInvoice")]
        public dynamic GetAnInvoice(string _id)
        {
            List<Parameter> parameters = new List<Parameter>()
            {
                new Parameter("@InvoiceID", _id)
            };
            DataTable tInvoice = DB.RetriveTable("GetAnInvoice", parameters);
            string jsonInvoice = JsonConvert.SerializeObject(tInvoice);
            return new
            {
                success = true,
                message = "success",
                result = new
                {
                    invoice = JsonConvert.DeserializeObject<List<Invoice>>(jsonInvoice)
                }
            };
        }
        /**
         *  Triggered by post request.
         *  Parameter _id: the invoice id which is to be deleted.
         *  Returns a message about the delete successness.
         */
        [HttpPost]
        [Route("deleteAnInvoice")]
        public dynamic DeleteAnInvoice(string _id)
        {
            List<Parameter> parameters = new List<Parameter>()
            {
                new Parameter("@InvoiceID", _id)
            };

            bool status = DB.UpdateTable("DeleteAnInvoice", parameters);

            return new
            {
                success = status,
                message = status ? "Invoice deleted" : "Error, could not delte",
                result = ""
            };
        }
    }
}
