using InvoiceApp.Entities.Entities;
using InvoiceApp.Models.Models.Company;
using InvoiceApp.Models.Responses.CompanyResponse;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApp.Services.Services.CompanyServices
{
    public class CompanyService
    {
        private readonly InvoiceDbContext _DbMan;

        public CompanyService(InvoiceDbContext db)
        {
            this._DbMan = db;
        }

        public async Task<CompanyResponse> GetCompanyResponseAsync()
        {
            var res = new CompanyResponse();
            res.Companies = await this._DbMan.MasterCompanies.Select(Q => new CompanyViewModel
            {
                CompanyId = Q.CompanyId,
                CompanyName = Q.CompanyName,
                CompanyAddress = Q.CompanyAddress,
                CompanyLogo = Q.CompanyLogo
            }).ToListAsync();
            return res;
        }
    }
}
