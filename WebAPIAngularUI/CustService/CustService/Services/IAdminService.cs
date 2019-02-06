using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using CustService.Models;

namespace CustService.Services
{
    public interface IAdminService
    {
        UserLogin Authenticate(string Username, string Password);
    }
}
