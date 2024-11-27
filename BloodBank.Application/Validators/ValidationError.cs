﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Application.Validators
{
    public class ValidationError
    {

        public string PropertyName { get; set; }
        public string ErrorMessage { get; set; }

        public override string ToString() => $"({PropertyName}, '{ErrorMessage}')";
    }
}