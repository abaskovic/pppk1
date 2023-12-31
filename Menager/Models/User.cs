﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menager.Models
{
    public class User
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Oib { get; set; }
        public string? Email { get; set; }

        public override string? ToString() => $"{FirstName} {LastName}";
    }
}
