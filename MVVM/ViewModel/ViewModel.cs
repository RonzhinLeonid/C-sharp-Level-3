using MVVM.Model;
using MVVM.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVM.ViewModel
{
    class ViewModel:INotifyPropertyChanged
    {
        public Model.Account Account { get; set; } = new Model.Account("root", "root");

        public int AttemptCount 
        {
            get { return AccessToApp.Attempt; }
        }

        public ICommand ClickAccess
        {
            get
            {
                return new DelegateCommand((p) => { 
                    Debug.WriteLine("Click access " + AccessToApp.Attempt);
                    AccessToApp.Checks(Account);
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("AttemptCount"));
                }, (p) => AccessToApp.Attempt < 3);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
