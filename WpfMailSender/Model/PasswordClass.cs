using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WpfMailSender.Model
{
    public static class PasswordClass
    {
        public static string getPassword(string p_sPassw)
        {
            string password = "";
            foreach (char a in p_sPassw)
            {
                char ch = a;
                ch--;
                password += ch;
            }

            return password;
        }
        /// <summary>
        /// На вход подаем пароль, на выходе получаем зашифрованный пароль
        /// </summary>
        /// <param name="p_sPassword"></param>
        /// <returns></returns>
        public static string getCodPassword(string p_sPassword)
        {
            string sCode = "";
            foreach (char a in p_sPassword)
            {
                char ch = a;
                ch++;
                sCode += ch;
            }
            return sCode;
        }

        /// <summary>
        /// Проверка пароля с MD5
        /// </summary>
        /// <param name="password"></param>
        /// <param name="hashPassword"></param>
        /// <returns></returns>
        public static bool ValidatePassword(string password, string hashPassword)
        { 
            return hashPassword == GetHashString(password);
        }
        /// <summary>
        /// Преобразование пароля в MD5
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string GetHashString(string s)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(s);
            MD5CryptoServiceProvider CSP = new MD5CryptoServiceProvider();
            byte[] byteHash = CSP.ComputeHash(bytes);
            string hash = string.Empty;
            foreach (byte b in byteHash)
                hash += string.Format("{0:x2}", b);
            return hash;
        }
    }
}
