using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InvoiceApp.Models.Responses.CompanyResponse;
using InvoiceApp.Services.Services.CompanyServices;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InvoicApp.API.Controllers
{
    [Route("api/[controller]")]
    public class CompanyController : Controller
    {
        private readonly CompanyService _CompanyMan;

        public CompanyController(CompanyService companyService)
        {
            this._CompanyMan = companyService;
        }
        // GET: api/<controller>
        [HttpGet]
        public async Task<IActionResult> Get(string code)
        {
            var res = new CompanyResponse();
            try
            {
                res = await this._CompanyMan.GetCompanyResponseAsync();
            }
            catch (Exception ex)
            {
                res.Message = ex.Message;
                res.SetFailedtatsus();
            }
            if (res.Companies.Count == 0)
            {
                res.SetFailedtatsus();
                res.SetMessage("Companies doesn't exist", 3);
            }
            return Ok(res);
        }
    }
}
