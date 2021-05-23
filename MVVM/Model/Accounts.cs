using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.Model
{
    class Accounts
    {
        static List<Account> accounts = new List<Account>() {
                                  new Account("root", "root"),
                                  new Account("login","password"),
                                  new Account("admin","admin")
                                  };

        static public bool Find(Account account)
        {
            return accounts.Select(acc => acc.Login == account.Login && acc.Password == account.Password).FirstOrDefault();
        }

        public static IEnumerable<Account> ListAccounts
        {

            get => accounts;
        }

        public static void Add(Account account)
        {

        }

        public static void Remove(Account account)
        {

        }

        public static void RemoveAt(int index)
        {

        }
    }
}
