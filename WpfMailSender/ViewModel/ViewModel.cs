using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using WpfMailSender.Model;

namespace WpfMailSender.ViewModel
{
    class ViewModel : INotifyPropertyChanged
    {

        string _subject = "";
        string _body = "";

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        //static string fromPassword = System.IO.File.ReadAllText("C:\\Пароль.txt");
        static string fromPassword = "root";

        public EmailSendServiceClass EmailSend { get; set; } = new EmailSendServiceClass("jiehuh87@gmail.com", fromPassword);

        public string FromWriter { get; set; } = "jiehuh87@yandex.ru";
        public string ToWriter { get; set; } = "jiehuh87@yandex.ru";
        public string Subject { 
            get => _subject;
            set
            {
                _subject = value;
                RaisePropertyChanged("Subject");
            }
        }
        public string Body
        {
            get => _body;
            set
            {
                _body = value;
                RaisePropertyChanged("Body");
            }
        }

        private int _selectedListener;
        public int SelectedListener
        {
            get { return _selectedListener; }
            set
            {
                _selectedListener = value;
                RaisePropertyChanged("SelectedListener");
            }
        }

        bool IsBodyHtml { get; set; } = false;
        public Dictionary<string, string> Senders { get; set; } = VariablesClass.Senders;
        public Dictionary<string, int> Server { get; set; } = VariablesClass.Server;

        public ICommand SendEmail
        {
            get
            {
                return new DelegateCommand((p) =>
                {
                    Debug.WriteLine("Test");
                    EmailSend.FromWriter = FromWriter;
                    EmailSend.ToWriter = ToWriter;
                    EmailSend.Subject = _subject;
                    EmailSend.Body = _body;
                    EmailSend.IsBodyHtml = IsBodyHtml;
                    EmailSend.SendMessage();
                }, (p) => Subject != "" && Body != "" );
            }
        }

        public ICommand About
        {
            get
            {
                return new DelegateCommand((p) =>
                {
                    var formAbout = new UserMessageBox();
                    formAbout.Title = "О себе";
                    formAbout.Width = 500;
                    formAbout.Height = 300;
                    formAbout.lblMessage.Content = "Добрый день.\nЯ Ронжин Леонид, 34года из С-Пб.\nПо специальности проектировщик.\n" +
                        "Изучаю C# для себя(смена профиля работы)\nи для написания различных макросов/команд необходимых для текущей работы.";
                    formAbout.lblMessage.Foreground = Brushes.Black;
                    formAbout.ShowDialog();
                }, (p) => true);
            }
        }

        public ICommand NextTab
        {
            get
            {
                return new DelegateCommand((p) =>
                {
                    Debug.WriteLine("Click access ");
                    _selectedListener++;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SelectedListener"));
                }, (p) => _selectedListener < 5);
            }
        }

        public ICommand PrevTab
        {
            get
            {
                return new DelegateCommand((p) =>
                {
                    Debug.WriteLine("Click access ");
                    _selectedListener--;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SelectedListener"));
                }, (p) => _selectedListener > 0);
            }
        }
    }
}
