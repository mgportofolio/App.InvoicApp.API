using InvoiceApp.Models.Models.Dropdowns;
using InvoiceApp.Models.Responses.Commons;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvoiceApp.Models.Responses.InitialResponse
{
    public class InitialResponse : BaseResponse
    {
        public InitialResponse()
        {
            this.Dropdowns = new MultiDropdown();
            this.InitialInvoiceNo = "";
        }
        public MultiDropdown Dropdowns { set; get; }
        public string InitialInvoiceNo { set; get; }
    }
}
