using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionExample
{
    interface IUser
    {
        bool Login(string UserName, string Password);
        bool Register(string UserName, string Password, string Email);
        void LogError(string Error);
        bool SendEmail(string EmailContent);
    }

    interface ILogger
    {
        void LogError(string Error);
        bool SendEmail(string EmailContent);
    }

    interface IEmail
    {
        bool SendEmail(string EmailContent);
    }
}
