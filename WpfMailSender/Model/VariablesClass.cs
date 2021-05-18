using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfMailSender.Model
{
    public static class VariablesClass
    {
        public static Dictionary<string, string> Senders
        {
            get { return dicSenders; }
        }

        public static Dictionary<string, int> Server
        {
            get { return dicServer; }
        }


        private static Dictionary<string, string> dicSenders = new Dictionary<string, string>()
        {
            { "jiehuh87@yandex.ru",System.IO.File.ReadAllText("C:\\Пароль.txt") },
            { "79257443993@yandex.ru",PasswordClass.getPassword("1234l;i") },
            { "sok74@yandex.ru",PasswordClass.getPassword(";liq34tjk") }
        };

        private static Dictionary<string, int> dicServer = new Dictionary<string, int>()
        {
            { "smtp.gmail.com", 587 },
            { "smtp.gmail.ru", 465 },
            { "smtp.yandex.ru", 25 }
        };

    }
}
