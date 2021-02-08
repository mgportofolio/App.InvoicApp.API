using InvoiceApp.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvoiceApp.Models.Models.Invoices.ViewModel
{
    public class InvoiceViewModel
    {
        public InvoiceHeader Header { set; get; }
        public List<InvoiceDetail> Details { set; get; }
    }
}
