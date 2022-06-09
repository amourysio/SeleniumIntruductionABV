using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumIntruductionABV;
using System.Threading;

namespace ABVTests
{
    [TestClass]
    public class ABVTests
    {
        IWebDriver _driver;
        ABVInboxPage inbox;
        ABVHomePage home;
        private string _username { get; set; }
        private string _password { get; set; }
        private string _subject { get; set; }
        private string _text { get; set; }
        private string _email { get; set; }

        [TestInitialize]
        public void Initialize()
        {
            _driver = new ChromeDriver
            {
                Url = "https://www.abv.bg/"
            };
            _username = "only_poker@abv.bg";
            _password = "nokia58";
            _subject = "First automation Email";
            _text = "Hello, that is automation email!";
            _email = "only_poker@abv.bg";
            home = new ABVHomePage(_driver, _username, _password);
            inbox = new ABVInboxPage(_driver);
        }
       
        public void CheckHomePageOpenned()
        {
            var loginAbvLogo = "loginAbvLogo";
            
            
            
            Thread.Sleep(1000);

            Assert.IsTrue(home.CheckHomePageOpenned(loginAbvLogo));
        }

        [TestMethod]
        public void Login()
        {
            
            home.GoToInboxPage(_username, _password);

            Assert.IsTrue(home.IsLogined(_username));
        }
        [TestMethod]
        public void NewEmailWindow()
        {
            string newMessageWindowClassName = "sendPageWrapper";
            home.GoToInboxPage(_username, _password);
            inbox.GoToNewEmailWindow();
            Assert.IsTrue(inbox.CheckNewMessageWindowOpenned(newMessageWindowClassName));
        }
        [TestMethod]
        public void SendEmail()
        {
            string newUnreadMessage = "inbox-cellTableWidget";
            home.GoToInboxPage(_username, _password);
            inbox.SendNewEmail(_email, _subject, _text);
            home.RefreshPage();
            inbox.CheckNewUnreadMessage();
            Assert.IsTrue(inbox.ReceivedNewMessage(newUnreadMessage));
         
        }

        [TestCleanup]
        public void CleanUp()
        {
            _driver.Close();
        }
    }
}
