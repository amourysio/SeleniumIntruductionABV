using OpenQA.Selenium;
using System.Threading;

namespace SeleniumIntruductionABV
{
    public class ABVInboxPage : DriverHelper
    {
        const string NEW_EMAIL_WINDOW_LOCATOR = "/html/body/div[1]/div/div[4]/div/div[4]/div/div[2]/div/div[2]/div/div[3]";
        const string SEND_TO_FIELD_LOCATOR = "/html/body/div[1]/div/div[4]/div/div[4]/div/div[4]/div/div[2]/div/div[2]/div/div[2]/div[1]/table/tbody/tr[2]/td[2]/div/input";
        const string RESULT_OF_EMAIL_LOCATOR = "item";
        const string SUBJECT_LOCATOR = "/html/body/div[1]/div/div[4]/div/div[4]/div/div[4]/div/div[2]/div/div[2]/div/div[2]/div[1]/table/tbody/tr[5]/td[2]/div/input";
        const string TEXT_LOCATOR = "gwt-RichTextArea";
        const string SEND_EMAIL_BUTTON_LOCATOR = "/html/body/div[1]/div/div[4]/div/div[4]/div/div[4]/div/div[2]/div/div[2]/div/div[1]/div[1]";
        const string NEW_UNREAD_MESSAGE_LOCATOR = "inbox-cellTableWidget";
        const string NEW_MESSAGE_WINDOWS_LOCATOR = "sendPageWrapper";
        public ABVInboxPage(IWebDriver Driver) : base(Driver)
        {
        }
        public void GoToNewEmailWindow() => GetElementByXpath(NEW_EMAIL_WINDOW_LOCATOR).Click();
        public void SetEmailSendToString(string sendTo) => GetElementByXpath(SEND_TO_FIELD_LOCATOR).SendKeys(sendTo);
        public void GetResultOfEmail() => GetElementByClassName(RESULT_OF_EMAIL_LOCATOR).Click();
        public void SetSubjectString(string subject) => GetElementByXpath(SUBJECT_LOCATOR).SendKeys(subject);
        public void SetTextString(string text) => GetElementByClassName(TEXT_LOCATOR).SendKeys(text);
        public void GoToSendEmailButton() => GetElementByXpath(SEND_EMAIL_BUTTON_LOCATOR).Click();
        public void CheckNewUnreadMessage() => GetElementByClassName(NEW_UNREAD_MESSAGE_LOCATOR).Click();
        public bool CheckNewMessageWindowOpenned(string newMessageWindow)
        {
            GetElementByClassName(newMessageWindow);
            if (newMessageWindow == NEW_MESSAGE_WINDOWS_LOCATOR)
            {
                return true;

            }
            else
            {
                return false;
            }
        }
        public bool ReceivedNewMessage(string className)
        {
            GetElementByClassName(className);
            if (className == NEW_UNREAD_MESSAGE_LOCATOR)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void SendNewEmail(string sendTo, string subject, string text)
        {
            GoToNewEmailWindow();
            SetEmailSendToString(sendTo);
            GetResultOfEmail();
            SetSubjectString(subject);
            SetTextString(text);
            GoToSendEmailButton();
            Thread.Sleep(3000);
        }

    }
}
