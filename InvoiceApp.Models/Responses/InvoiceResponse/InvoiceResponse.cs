using InvoiceApp.Models.Models.Invoices.ViewModel;
using InvoiceApp.Models.Responses.Commons;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvoiceApp.Models.Responses.InvoiceResponse
{
    public class InvoiceResponse : BaseResponse
    {
        public InvoiceResponse()
        {
            InvoiceViewModel = new InvoiceViewModel();
        }

        public InvoiceViewModel InvoiceViewModel { set; get; }
    }
}
