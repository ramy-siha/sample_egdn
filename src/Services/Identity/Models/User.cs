﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.WebApi.Models
{
    public class User
    {
        public string FullName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public decimal UserId { get; set; }
    }
}
