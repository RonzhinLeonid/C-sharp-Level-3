using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WpfMailSender.ViewModel
{
    class ViewModel
    {
        static string fromPassword = System.IO.File.ReadAllText("C:\\Пароль.txt");

        public EmailSendServiceClass EmailSend { get; set; } = new EmailSendServiceClass("jiehuh87@gmail.com", fromPassword);

        public string FromWriter { get; set; }
        public string ToWriter { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

        bool IsBodyHtml { get; set; }

        public ICommand SendEmail
        {
            get
            {
                return new DelegateCommand((p) =>
                {
                    EmailSend.FromWriter = FromWriter;
                    EmailSend.ToWriter = ToWriter;
                    EmailSend.Subject = Subject;
                    EmailSend.Body = Body;
                    EmailSend.IsBodyHtml = false;
                }, (p) => true);
            }
        }
    }
}
