﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace backend_ih.Controllers
{
    public class Requests
    {
        public class LoginRequest
        {
            public string Usuario { get; set; }
            public string Password { get; set; }
        }
    }
}