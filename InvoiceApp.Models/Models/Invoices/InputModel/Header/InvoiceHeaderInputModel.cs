using System;
using System.Collections.Generic;
using System.Text;

namespace InvoiceApp.Models.Models.Invoices.InputModel.Header
{
    public class InvoiceHeaderInputModel
    {
        public string AddressFrom { get; set; }
        public int CompanyId { get; set; }
        public int CurrencyId { get; set; }
        public int LanguageId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public DateTime InvoiceDue { get; set; }
        public string InvoicePON { get; set; }
        public string InvoiceNo { get; set; }
        public int InvoiceStatus { get; set; }
    }
}
