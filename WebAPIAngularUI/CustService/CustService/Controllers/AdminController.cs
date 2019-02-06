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
    [Route("api/Admin")]
    public class AdminController : Controller
    {
        private readonly IAdminService _AdminService;
        private readonly IOptions<AppSettings> _appSettingsOption;

        public AdminController(IAdminService _AdminService, IOptions<AppSettings> _appSettingsOption)
        {
            this._AdminService = _AdminService;
            this._appSettingsOption = _appSettingsOption;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public UserLogin Authenticate([FromBody]UserLogin userParam)
        {
            return _AdminService.Authenticate(userParam.Username, userParam.Password);
        }
    }
}