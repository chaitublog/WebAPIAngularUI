using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CustService.Services;
using CustService.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using CustService.Configuration;

namespace CustService.Controllers
{
    [Produces("application/json")]
    [Route("api/Customer")]
    [Authorize]
    public class CustomerController : Controller
    {

        private readonly ICustomerService _CustomerService;
        private readonly IOptions<AppSettings> _appSettingsOption;

        public CustomerController(ICustomerService _CustomerService, IOptions<AppSettings> _appSettingsOption)
        {
            this._CustomerService = _CustomerService;
            this._appSettingsOption = _appSettingsOption;
        }

      

        [HttpGet("GetAllCustomer")]
        public IActionResult GetAllCustomer()
        {
            List<Customer> customers = _CustomerService.GetAllCustomer();            
        //    customers.Select(u => { u.CustPassword = null; return u; }).ToList();

            return Ok(customers);
        }
        [HttpPost("CreateCustomer")]
        public IActionResult CreateCustomer([FromBody]Customer cust)
        {
            cust.CustRegisterData = System.DateTime.Now;
            if (_CustomerService.CreateCustomer(cust) > 0)
            {
                return Ok("Customer Created Successfully");
            }else
            {
                return StatusCode(500, "error Occured");
            }
        }

        [HttpDelete("DeleteCustomer")]
        public IActionResult DeleteCustomer(Customer cust)
        {
            if (_CustomerService.DeleteCustomer(cust) > 0)
            {
                return Ok();
            }else
            {
                return NotFound("Customer not Deleted");
            }
        }

        [HttpGet("GetCustomerbyID")]
        public IActionResult GetCustomerbyID(int CustID)
        {
            return Ok(_CustomerService.GetCustomerbyID(CustID));
            

        }
    }
}