using InvoiceApp.Models.Models.Company;
using InvoiceApp.Models.Responses.Commons;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvoiceApp.Models.Responses.CompanyResponse
{
    public class CompanyResponse : BaseResponse
    {
        public CompanyResponse()
        {
            this.Companies = new List<CompanyViewModel>();
        }
        public List<CompanyViewModel> Companies { set; get; }
    }
}
