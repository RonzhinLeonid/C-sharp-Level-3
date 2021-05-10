using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net;
using System.Net.Mail;

namespace WpfTestMailSender
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class WpfMailSender : Window
    {
        public WpfMailSender()
        {
            InitializeComponent();
        }

        private void btnSendEmail_Click(object sender, RoutedEventArgs e)
        {
            //string from = "JIeHuH87@yandex.ru";
            //MailMessage mail = new MailMessage();
            //mail.From = new MailAddress("jiehuh87@gmail.com"); // Адрес отправителя
            //mail.To.Add(new MailAddress(from)); // Адрес получателя
            //mail.Subject = "Заголовок";
            //mail.Body = "Письмо........................";

            //var smtp = new SmtpClient
            //{
            //    Host = "smtp.gmail.com",
            //    Port = 587,
            //    EnableSsl = true,
            //    DeliveryMethod = SmtpDeliveryMethod.Network,
            //    UseDefaultCredentials = false,
            //    Credentials = new NetworkCredential("jiehuh87@gmail.com", "Rfhnjirf8791")
            //};


            //SmtpClient client = new SmtpClient();
            //client.Host = "smtp.yandex.ru";
            //client.Port = 25; // Обратите внимание что порт 587
            //client.EnableSsl = true;
            //client.Credentials = new NetworkCredential(from, "Rfhnjirf78911987"); // Ваши логин и пароль
            //smtp.Send(mail);

            List<string> listStrMails = new List<string> { "JIeHuH87@yandex.ru", "JIeHuH87@yandex.ru", "JIeHuH87@yandex.ru" };
            string strPassword = passwordBox.Password;
            foreach (string mail in listStrMails)
            {
                using (MailMessage mm = new MailMessage("JIeHuH87@yandex.ru", mail))
                {
                    // Формируем письмо
                    mm.Subject = "Привет из C#";     // Заголовок письма
                    mm.Body = "Hello, world!";       // Тело письма
                    mm.IsBodyHtml = false;           // Не используем html в теле письма
                                                     // Авторизуемся на smtp-сервере и отправляем письмо
                    using (SmtpClient sc = new SmtpClient("smtp.gmail.com", 587))
                    {
                        sc.EnableSsl = true;
                        sc.DeliveryMethod = SmtpDeliveryMethod.Network;
                        sc.UseDefaultCredentials = false;
                        sc.Credentials = new NetworkCredential("jiehuh87@gmail.com", strPassword);
                        sc.DeliveryFormat = SmtpDeliveryFormat.SevenBit;
                        try
                        {
                            sc.Send(mm);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Невозможно отправить письмо " + ex.ToString());
                        }
                    }
                } //using (MailMessage mm = new MailMessage("sender@yandex.ru", mail))
            }
            MessageBox.Show("Работа завершена.");
        }
    }
}
//mail.SmtpPort = 25;
//mail.EnableSsl = true;
//mail.UseDefaultCredentials = false;
//mail.Сredentials = new NetworkCredential(account.SenderAddress, account.Password); // Домен не указывать!
//mail.DeliveryMethod = SmtpDeliveryMethod.Network;
//mail.DeliveryFormat = SmtpDeliveryFormat.SevenBit;