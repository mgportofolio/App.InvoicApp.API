using InvoiceApp.Entities.Entities;
using InvoiceApp.Models.Requests.InvoiceRequest;
using InvoiceApp.Models.Responses.Commons;
using InvoiceApp.Models.Responses.InitialResponse;
using InvoiceApp.Models.Responses.InvoiceResponse;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApp.Services.Services.InvoiceServices
{
    public class InvoiceService
    {
        private readonly InvoiceDbContext _DbMan;

        public InvoiceService(InvoiceDbContext db)
        {
            this._DbMan = db;
        }

        public async Task<InvoiceResponse> GetAsync(int id)
        {
            var res = new InvoiceResponse();
            res.InvoiceViewModel.Header = await this._DbMan.InvoiceHeaders.Where(Q => Q.InvoiceId == id).FirstOrDefaultAsync();
            if(res.InvoiceViewModel.Header == null)
            {
                res.SetFailedtatsus();
                res.Message = "Data Not Found";
                return res;
            }
            res.InvoiceViewModel.Details = await this._DbMan.InvoiceDetails.Where(Q => Q.InvoiceId == id).ToListAsync();
            if (res.InvoiceViewModel.Details == null)
            {
                res.SetFailedtatsus();
                res.Message = "Data Not Found";
                return res;
            }
            return res;
        }

        public async Task<BaseResponse> PostAsync(InvoiceRequest invoiceRequest)
        {
            var res = new BaseResponse();
            var newInvoiceHeadder = new InvoiceHeader();
            newInvoiceHeadder.CompanyId = invoiceRequest.Invoice.InvoiceHeadder.CompanyId;
            newInvoiceHeadder.CurrencyId = invoiceRequest.Invoice.InvoiceHeadder.CurrencyId;
            newInvoiceHeadder.LanguageId = invoiceRequest.Invoice.InvoiceHeadder.LanguageId;
            newInvoiceHeadder.InvoiceFrom = invoiceRequest.Invoice.InvoiceHeadder.AddressFrom;
            newInvoiceHeadder.InvoiceDate = invoiceRequest.Invoice.InvoiceHeadder.InvoiceDate;
            newInvoiceHeadder.InvoiceDue = invoiceRequest.Invoice.InvoiceHeadder.InvoiceDue;
            newInvoiceHeadder.InvocieNo = invoiceRequest.Invoice.InvoiceHeadder.InvoiceNo;
            newInvoiceHeadder.InvoicePon = invoiceRequest.Invoice.InvoiceHeadder.InvoicePON;
            newInvoiceHeadder.DiscountCode = invoiceRequest.Invoice.DiscountCode;
            newInvoiceHeadder.DiscountPercentage = invoiceRequest.Invoice.DiscountPercantage;
            newInvoiceHeadder.DiscountValue = invoiceRequest.Invoice.DiscountValue;
            newInvoiceHeadder.InvoiceSubTotal = invoiceRequest.Invoice.InvoiceSubTotal;
            newInvoiceHeadder.InvoiceTotal = invoiceRequest.Invoice.InvoiceTotal;
            newInvoiceHeadder.InvoiceStatus = invoiceRequest.Invoice.InvoiceHeadder.InvoiceStatus;
            this._DbMan.InvoiceHeaders.Add(newInvoiceHeadder);

            var newInvoiceDetails = new List<InvoiceDetail>();
            foreach(var model in invoiceRequest.Invoice.invoiceDetails)
            {
                var amount = model.ItemQty * model.ItemRate;
                //Correction Backend
                if(amount != model.ItemAmount)
                {
                    model.ItemAmount = amount;
                }
                newInvoiceDetails.Add(new InvoiceDetail
                {
                    ItemName = model.ItemName,
                    ItemQty = model.ItemQty,
                    ItemRate = model.ItemRate,
                    ItemAmount = model.ItemAmount,
                    MetricId = model.MetricId,
                    InvoiceId = newInvoiceHeadder.InvoiceId
                });
            }
            var subTotal = newInvoiceDetails.Sum(Q => Q.ItemAmount);
            var isSubTotalTrue = subTotal == newInvoiceHeadder.InvoiceSubTotal;
            if(isSubTotalTrue == false)
            {
                newInvoiceHeadder.InvoiceSubTotal = subTotal;
                newInvoiceHeadder.InvoiceTotal = subTotal - (subTotal * newInvoiceHeadder.DiscountPercentage);
            }
            this._DbMan.InvoiceDetails.AddRange(newInvoiceDetails);
            try
            {
                await this._DbMan.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                res.Message = ex.Message;
                res.SetFailedtatsus();
                return res;
            }
            return res;
        }
    }
}
