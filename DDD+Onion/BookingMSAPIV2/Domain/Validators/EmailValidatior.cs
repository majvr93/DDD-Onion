using System;
using System.Net.Mail;

namespace Domain
{
    public static class EmailValidatior
    {
        public static string Validate(string email)
        {
            try
            {
                MailAddress mail = new MailAddress(email);
            }
            catch (Exception)
            {
                return "email: The email is invalid";
            }

            return null;
        }
    }
}
