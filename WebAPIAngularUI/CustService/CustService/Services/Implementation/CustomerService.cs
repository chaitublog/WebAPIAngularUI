using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustService.Models;
using Microsoft.Extensions.Options;
using CustService.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;


namespace CustService.Services
{
    public class CustomerService:ICustomerService
    {

       private readonly CustomerDBContext _custDBContext;
        private readonly IOptions<AppSettings> _appSettings;

        public CustomerService(CustomerDBContext _custDBContext, IOptions<AppSettings> _appSettings)
        {
            this._custDBContext = _custDBContext;
            this._appSettings = _appSettings;
        }

        

        public List<Customer> GetAllCustomer()
        {
            return _custDBContext.Customer.ToList();
        }
        public int CreateCustomer(Customer cust)
        {
            _custDBContext.Customer.Add(cust);
            _custDBContext.SaveChanges();
            return cust.CustId;
        }
        public int DeleteCustomer(Customer cust)
        {
            _custDBContext.Customer.Remove(cust);
            _custDBContext.SaveChanges();
            return cust.CustId;
        }
        public Customer GetCustomerbyID(int CustID)
        {
          return  _custDBContext.Customer.FirstOrDefault(c=> c.CustId== CustID);
           
        }
    }
}
