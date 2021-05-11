using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfMailSender
{
    public static class Settings
    {
        static string _host = "smtp.gmail.com";
        static int _port = 587;

        static public string Host
        {
            get
            {
                return _host;
            }
        }
        static public int Port
        {
            get
            {
                return _port;
            }
        }
    }
}
