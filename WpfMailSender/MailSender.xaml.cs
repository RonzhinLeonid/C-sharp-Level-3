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
using WpfMailSender.Model;

namespace WpfMailSender
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MailSender : Window
    {
        string fromPassword;
        public MailSender()
        {
            fromPassword = System.IO.File.ReadAllText("C:\\Пароль.txt");
            InitializeComponent();

            cbSenderSelect.ItemsSource = VariablesClass.Senders;
            cbSenderSelect.DisplayMemberPath = "Key";
            cbSenderSelect.SelectedValuePath = "Value";

            cbServer.ItemsSource = VariablesClass.Server;
            cbServer.DisplayMemberPath = "Key";
            cbServer.SelectedValuePath = "Value";
        }

        private void btnSendEmail_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbBody.Text))
            {
                MessageBox.Show("Письмо не заполнено.");
                tbBody.Focus();
                return;
            }
            if (string.IsNullOrEmpty(tbTo.Text))
            {
                MessageBox.Show("Не указан получатель.");
                tbTo.Focus();
                return;
            }

            var email = new EmailSendServiceClass("jiehuh87@gmail.com", fromPassword);
            email.FromWriter = tbFrom.Text;
            email.ToWriter = tbTo.Text;
            email.Subject = tbSubject.Text;
            email.Body = tbBody.Text;
            email.IsBodyHtml = false;
            email.SendMessage();

            var formOk = new UserMessageBox();
            formOk.Title = "Письмо отправлено.";
            formOk.Width = 300;
            formOk.Height = 200;
            formOk.lblMessage.Content = "Работа завершена.";
            formOk.lblMessage.Foreground = Brushes.Black;
            formOk.ShowDialog();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var formAbout = new UserMessageBox();
            formAbout.Title = "О себе";
            formAbout.Width = 500;
            formAbout.Height = 300;
            formAbout.lblMessage.Content = "Добрый день.\nЯ Ронжин Леонид, 34года из С-Пб.\nПо специальности проектировщик.\n" +
                "Изучаю C# для себя(смена профиля работы)\nи для написания различных макросов/команд необходимых для текущей работы.";
            formAbout.lblMessage.Foreground = Brushes.Black;
            formAbout.ShowDialog();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void pnBtnUI_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
