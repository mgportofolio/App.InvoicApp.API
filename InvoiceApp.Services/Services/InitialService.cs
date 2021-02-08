using InvoiceApp.Entities.Entities;
using InvoiceApp.Models.Responses.InitialResponse;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApp.Services.Services
{
    public class InitialService
    {
        private readonly InvoiceDbContext _DbMan;

        public InitialService(InvoiceDbContext db)
        {
            this._DbMan = db;
        }

        public async Task<InitialResponse> GetInitialData()
        {
            var res = new InitialResponse();
            var invoice = await this._DbMan.InvoiceHeaders.AsNoTracking().OrderByDescending(Q => Q.InvoiceId).FirstOrDefaultAsync();
            if (invoice == null)
            {
                res.InitialInvoiceNo = "INV-001";
            }
            else
            {
                res.InitialInvoiceNo = "INV-" + String.Format("{0:000}", invoice.InvoiceId++);
            }
            res.Dropdowns.Currency = this._DbMan.MasterCurrencies.AsNoTracking().Select(Q => new Models.Models.Commons.DropdownModel
            {
                KeyId = Q.CurrencyId,
                KeyName = Q.CurrencyName
            }).ToList();
            res.Dropdowns.Language = this._DbMan.MasterLanguages.AsNoTracking().Select(Q => new Models.Models.Commons.DropdownModel
            {
                KeyId = Q.LanguageId,
                KeyName = Q.LanguageName
            }).ToList();
            res.Dropdowns.Currency = this._DbMan.MasterMetrics.AsNoTracking().Select(Q => new Models.Models.Commons.DropdownModel
            {
                KeyId = Q.MetricId,
                KeyName = Q.MetricCode
            }).ToList();
            return res;
        }
    }
}
