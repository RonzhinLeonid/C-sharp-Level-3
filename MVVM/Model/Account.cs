using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.Model
{
    public class Account : INotifyPropertyChanged
    {
        private string login = "None";
        private string password = "None";

        public string Login
        {
            get => login;
            set
            {
                if (value != login)
                {
                    login = value;
                    //Если у элемента OneWayToSource - PropertyChanged.Invoke не обновляет данные    
                    //Debug.WriteLine("Set Login");
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Login"));
                }
            }
        }
        public string Password { get => password; set => password = value; }

        public Account(string login, string password)
        {
            Login = login;
            Password = password;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
