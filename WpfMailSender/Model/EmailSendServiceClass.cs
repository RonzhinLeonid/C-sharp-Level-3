using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.Windows.Media;

namespace WpfMailSender
{
    public class EmailSendServiceClass
    {
        string _login;
        string _password;
        string _toWriter;
        string _fromWriter;
        string _subject;
        string _body;
        bool _isBodyHtml;

        public string ToWriter
        {
            set
            {
                _toWriter = value;
            }
        }
        public string FromWriter
        {
            set
            {
                _fromWriter = value;
            }
        }
        public string Subject
        {
            set
            {
                _subject = value;
            }
        }
        public string Body
        {
            set
            {
                _body = value;
            }
        }
        public bool IsBodyHtml
        {
            set
            {
                _isBodyHtml = value;
            }
        }
        public EmailSendServiceClass(string login, string password)
        {
            _login = login;
            _password = password;
        }
        public EmailSendServiceClass(string login, string password, string toWriter, string fromWriter, string subject, string body, bool isBodyHtml)
        {
            _login = login;
            _password = password;
            _toWriter = toWriter;
            _fromWriter = fromWriter;
            _subject = subject;
            _body = body;
            _isBodyHtml = isBodyHtml;
        }

        public void SendMessage()
        {
            using (MailMessage mm = new MailMessage(_fromWriter, _toWriter))
            {
                // Формируем письмо
                mm.Subject = _subject;     // Заголовок письма
                mm.Body = _body;       // Тело письма
                mm.IsBodyHtml = _isBodyHtml;           // Не используем html в теле письма
                // Авторизуемся на smtp-сервере и отправляем письмо
                using (SmtpClient sc = new SmtpClient(Settings.Host, Settings.Port))
                {
                    sc.EnableSsl = true;
                    sc.DeliveryMethod = SmtpDeliveryMethod.Network;
                    sc.UseDefaultCredentials = false;
                    sc.Credentials = new NetworkCredential(_login, _password);
                    sc.DeliveryFormat = SmtpDeliveryFormat.SevenBit;
                    try
                    {
                        sc.Send(mm);
                        var formOk = new UserMessageBox();
                        formOk.Title = "Информация.";
                        formOk.Width = 300;
                        formOk.Height = 200;
                        formOk.lblMessage.Content = "Письмо отправлено.";
                        formOk.lblMessage.Foreground = Brushes.Black;
                        formOk.ShowDialog();
                    }
                    catch (Exception ex)
                    {
                        var formError = new UserMessageBox();
                        formError.Title = "Ошибка";
                        formError.lblMessage.Content = "Невозможно отправить письмо " + ex.ToString();
                        formError.lblMessage.Foreground = Brushes.Red;
                        formError.ShowDialog();
                    }
                }
            }
        }
    }
}
