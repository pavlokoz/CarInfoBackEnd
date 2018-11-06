using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarInfoInfrastructure.Constants
{
    public static class Constants
    {
        public static class CORSConstants
        {
            public const string FrontEndUrl = "http://localhost:4200";
        }

        public static class EmailServiceConstants
        {
            public const string SmtpClientHost = "smtp.gmail.com";

            public const int SmtpClientPort = 587;

            public static class Credentials
            {
                public const string Email = "shostakpavlo@gmail.com";

                public const string Password = "pavlokozova";
            }
        }

        public static class ConnectionStrings
        {
            public static string DatabaseConnectionString = ConfigurationManager
                .ConnectionStrings["CarInfoConnectionString"].ConnectionString;
        }

        public static class AccountControllerConstants
        {
            public const string UrlForRedirectAfterEmailConfirmation = "https://localhost:4200/main";

            public const string LocalLoginProvider = "Local";

            public const int BitsPerByte = 8;
        }

        public static class DataValidationConstants
        {
            public const int MinimumPasswordLength = 8;

            public const string EmailPattern = @"[a-zA-Z0-9_\.\+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-\.]+";

            public const string PasswordPattern = @"((?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%!]).{8,20})$";

            public const string NamePattern = @"^[а-яА-ЯёЁa-zA-Zʼ'ї Ї і І є Є-]{2,40}$";
        }

        public static class LoggerConstants
        {
            public static string PathForFileStream = $@"E:\EasyTravelLog.txt";
        }
    }
}
