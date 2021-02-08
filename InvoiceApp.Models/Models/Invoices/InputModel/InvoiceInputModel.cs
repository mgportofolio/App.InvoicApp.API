using InvoiceApp.Models.Models.Invoices.InputModel.Detail;
using InvoiceApp.Models.Models.Invoices.InputModel.Header;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvoiceApp.Models.Models.Invoices.InputModel
{
    public class InvoiceInputModel
    {
        public InvoiceHeaderInputModel InvoiceHeadder { set; get; }
        public List<InvoiceDetailInputModel> invoiceDetails{ set; get; }
        public string DiscountCode { set; get; }
        public decimal DiscountPercantage { set; get; }
        public decimal DiscountValue { set; get; }
        public decimal InvoiceSubTotal { set; get; }
        public decimal InvoiceTotal { set; get; }
    }
}
