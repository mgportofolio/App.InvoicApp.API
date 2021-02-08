using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InvoiceApp.Models.Responses.InitialResponse;
using InvoiceApp.Services.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InvoicApp.API.Controllers
{
    [Route("api/v1/initial")]
    public class InitialController : Controller
    {
        private readonly InitialService _InitMan;

        public InitialController(InitialService initialService)
        {
            this._InitMan = initialService;
        }
        // GET: api/<controller>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = new InitialResponse();
            try
            {
                response = await this._InitMan.GetInitialData();
            }catch(Exception ex)
            {
                response.Message = ex.Message;
                response.SetFailedtatsus();
            }
            return Ok(response);
        }
    }
}
