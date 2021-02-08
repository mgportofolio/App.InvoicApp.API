using InvoiceApp.Entities.Entities;
using InvoiceApp.Models.Responses.DiscountResponse;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApp.Services.Services.DiscountServices
{
    public class DiscountService
    {
        private readonly InvoiceDbContext _DbMan;

        public DiscountService(InvoiceDbContext db)
        {
            this._DbMan = db;
        }

        public async Task<DiscountResponse> GetDiscountResponseAsync(string code)
        {
            var res = new DiscountResponse();
            res.DiscountPercentage = await this._DbMan.Discounts.Where(Q => Q.DiscountCode == code).Select(Q => Q.DiscountValue).FirstOrDefaultAsync();
            return res;
        }
    }
}
