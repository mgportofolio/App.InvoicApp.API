using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InvoiceApp.Models.Responses.DiscountResponse;
using InvoiceApp.Services.Services.DiscountServices;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InvoicApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DiscountController : Controller
    {
        private readonly DiscountService _DiscountMan;

        public DiscountController(DiscountService discountService)
        {
            this._DiscountMan = discountService;
        }

        /// <summary>
        /// Check Discount
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        [HttpGet("{code}")]
        public async Task<IActionResult> Get(string code)
        {
            var res = new DiscountResponse();
            try
            {
                res = await this._DiscountMan.GetDiscountResponseAsync(code);
            }
            catch (Exception ex)
            {
                res.Message = ex.Message;
                res.SetFailedtatsus();
            }
            if(res.DiscountPercentage == 0)
            {
                res.SetFailedtatsus();
                res.SetMessage("Code doesn't exist", 3);
            }
            return Ok(res);
        }
    }
}
