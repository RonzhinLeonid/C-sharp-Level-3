using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfMailSender.ViewModel
{
    class EmailValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string email = value.ToString();
            Regex regex = new Regex(@"[a-zA-Z0-9]+@[a-zA-Z0-9]+\.[a-zA-Z0-9]+");
            if (!regex.IsMatch(email)) return new ValidationResult(false, "Все плохо");
            return new ValidationResult(true, "Все ок");
        }
    }
}
