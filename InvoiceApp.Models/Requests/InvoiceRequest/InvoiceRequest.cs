using InvoiceApp.Models.Models.Invoices.InputModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvoiceApp.Models.Requests.InvoiceRequest
{
    public class InvoiceRequest
    {
        public InvoiceRequest()
        {
            this.Invoice = new InvoiceInputModel();
        }
        public InvoiceInputModel Invoice { set; get; }
    }
}
