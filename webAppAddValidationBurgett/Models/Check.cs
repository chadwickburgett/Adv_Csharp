using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webAppAddValidationBurgett.Models
{
    public static class Check
    {
        public static string EmailExists(CustomerContext context, string email)
        {
            string msg = "";
            if (!string.IsNullOrEmpty(email))
            {
                var customer = context.Customers.FirstOrDefault(
                    c => c.EmailAddress.ToLower() == email.ToLower());
                if (customer != null)
                    msg = $"Email address {email} already in use.";
            }
            return msg;
        }
    }
}
