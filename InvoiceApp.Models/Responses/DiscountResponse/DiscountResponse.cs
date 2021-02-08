using InvoiceApp.Models.Responses.Commons;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvoiceApp.Models.Responses.DiscountResponse
{
    public class DiscountResponse : BaseResponse
    {
        public decimal DiscountPercentage { set; get; }
    }
}
