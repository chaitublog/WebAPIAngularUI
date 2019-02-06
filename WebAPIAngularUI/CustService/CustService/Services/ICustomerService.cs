using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustService.Models;

namespace CustService.Services
{
   public interface ICustomerService
    {
      
        List<Customer> GetAllCustomer();
        int CreateCustomer(Customer cust);
        int DeleteCustomer(Customer cust);
        Customer GetCustomerbyID(int CustID);
        
    }
}
