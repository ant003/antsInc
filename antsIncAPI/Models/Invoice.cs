namespace antsIncAPI.Models
{
    public class Invoice
    {
        public required string InvoiceID { get; set; }
        public required string InvoiceDate { get; set; }
        public required string Details { get; set; }
        public required string TotalCost { get; set; }
        public required string CustomerDNI { get; set; }
    }
}
