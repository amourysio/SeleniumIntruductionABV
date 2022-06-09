using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace SeleniumIntruductionABV
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IWebDriver Driver = new ChromeDriver();
            Driver.Url = "https://www.abv.bg/";

            
            string email = "only_poker@abv.bg";
            string username = "only_poker@abv.bg";
            string password = "nokia58";
            string subject = "First automation Email";
            string text = "Hello, that is automation email!";

            ABVHomePage home = new ABVHomePage(Driver,username, password);

            home.GoToInboxPage(username, password);

            ABVInboxPage inbox = new ABVInboxPage(Driver);

            inbox.SendNewEmail(email, subject, text);
            inbox.RefreshPage();
            inbox.CheckNewUnreadMessage();
            Thread.Sleep(1000);

            Driver.Close();
        }
    }
}
