﻿using System;
using System.Collections.Generic;

namespace CustService.Models
{
    public partial class UserLogin
    {
        public int Uid { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }
    }
}
