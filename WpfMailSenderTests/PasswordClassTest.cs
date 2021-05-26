using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WpfMailSender.Model;

namespace WpfMailSenderTests
{
    [TestClass]
    public class PasswordClassTest
    {
        [TestMethod]
        public void GetHashString_myparol()
        {
            string password = PasswordClass.GetHashString("myparol");
            string expected = "1306b1dbf201d74b03a144ab22e6d203";
            Assert.AreEqual(expected, password);
        }

        [TestMethod]
        public void GetHashString_1()
        {
            string password = PasswordClass.GetHashString("1");
            string expected = "06d49632c9dc9bcb62aeaef99612ba6b";
            Assert.AreEqual(expected, password);
        }

        [TestMethod]
        public void ValidatePassword_myparol()
        {
            bool password = PasswordClass.ValidatePassword("myparol", "1306b1dbf201d74b03a144ab22e6d203");
            bool expected = true;
            Assert.AreEqual(expected, password);
        }

        [TestMethod]
        public void ValidatePassword_1()
        {
            bool password = PasswordClass.ValidatePassword("1", "06d49632c9dc9bcb62aeaef99612ba6b");
            bool expected = true;
            Assert.AreEqual(expected, password);
        }
    }
}
