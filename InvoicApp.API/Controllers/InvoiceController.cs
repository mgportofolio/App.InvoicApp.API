using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InvoiceApp.Models.Requests.InvoiceRequest;
using InvoiceApp.Services.Services.InvoiceServices;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InvoicApp.API.Controllers
{
    [Route("api/v1/invoice")]
    public class InvoiceController : Controller
    {
        private readonly InvoiceService _InvoiceMan;

        public InvoiceController(InvoiceService invoiceService)
        {
            this._InvoiceMan = invoiceService;
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var res = await this._InvoiceMan.GetAsync(id);
            return Ok(res);
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]InvoiceRequest request)
        {
            var res = await this._InvoiceMan.PostAsync(request);
            return Ok(res);
        }
    }
}
