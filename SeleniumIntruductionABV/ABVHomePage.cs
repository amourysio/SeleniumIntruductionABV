using OpenQA.Selenium;
using System.Threading;

namespace SeleniumIntruductionABV
{
    public class ABVHomePage : DriverHelper
    {
        private string _username;
        private string _password;
        const string USERNAME_FIELD_LOCATOR = "username";
        const string PASSWORD_FIELD_LOCATOR = "password";
        const string LOGIN_BUTTON_LOCATOR = "loginBut";
        const string HOME_PAGE_LOCATOR = "only_poker@abv.bg";


        public ABVHomePage(IWebDriver driver, string username, string password) : base(driver)
        {
            _username = username;
            _password = password;
        }
        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        
        public void SetUsernameString(string username) => GetElementById(USERNAME_FIELD_LOCATOR).SendKeys(username);

        public void SetPasswordString(string password) => GetElementById(PASSWORD_FIELD_LOCATOR).SendKeys(password);

        public void GoToLoginButton() => GetElementById(LOGIN_BUTTON_LOCATOR).Click();
       
        public void GoToInboxPage(string username, string password)
        {
            SetUsernameString(username);
            SetPasswordString(password);
            GoToLoginButton();
            Thread.Sleep(2000);
        }
        public bool CheckHomePageOpenned(string username)
        {
            GetElementByLinkText(HOME_PAGE_LOCATOR);
            if (username == HOME_PAGE_LOCATOR)
            {
                return true;

            }
            else
            {
                return false;
            }
        }
        public bool IsLogined(string username)
        {
            GetElementByLinkText(Username);
            if (username == Username)
            {
                return true;

            }
            else
            {
                return false;
            }
        }
    }
}
