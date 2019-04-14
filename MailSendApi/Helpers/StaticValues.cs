using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MailSendApi.Helpers
{
    public class StaticValues
    {
        public static string smtp { get; set; }
        public static string UseDefaultCredentials { get; set; }
        public static string Credentials { get; set; }
        public static string Password { get; set; }
        public static string EnableSsl { get; set; }
        public static string Port { get; set; }

        //" value="smtp.gmail.com"/>
    //<add key = "UseDefaultCredentials" value="false"/>
    //<add key = "Credentials" value="sendermail589"/>
    //<add key = "Password" value=""/>
    //<add key = "EnableSsl" value="true"/>
    //<add key = "Port" value="587"/>
    }
}
