﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BindingSourceCode
{
    public class MyValidationRule : ValidationRule
    {
        private string? validName;
        public string ValidName
        {
            get { return validName!; }
            set { validName = value; }
        }
        public override ValidationResult Validate(object value,
        CultureInfo cultureInfo)
        { // parameter value holds the data subject for validation
            string enteredName = value?.ToString() ?? "";
            if (enteredName == validName)
            { // the rule fails, throws and exception with text “Hey,….
                return new ValidationResult(false, "Hey, That's random name!");
            }
            else
            { // the rule passed
                return new ValidationResult(true, null);
            }
        }
    }
}
