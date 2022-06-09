using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SeleniumIntruductionABV
{
   public abstract class DriverHelper
    {
        private IWebDriver _driver;

        public DriverHelper(IWebDriver driver)
        {
            this._driver = driver;
        }
        public IWebDriver Driver
        {
            get { return _driver; }
            set { _driver = value; }
        }
     
        public IWebElement GetElementByXpath(string xPath)
        {
            IWebElement webElement = null;
            
            while(webElement == null)
            {
                try
                {
                    webElement = _driver.FindElement(By.XPath(xPath));
                }
                catch (Exception)
                {
                    Thread.Sleep(10);
                }
            }
            return webElement;
        }
        public IWebElement GetElementById(string Id)
        {
            IWebElement webElement = null;

            while (webElement == null)
            {
                try
                {
                    webElement = _driver.FindElement(By.Id(Id));
                }
                catch (Exception)
                {
                    Thread.Sleep(10);
                }
            }
            return webElement;
        }
        public IWebElement GetElementByClassName(string className)
        {
            IWebElement webElement = null;

            while (webElement == null)
            {
                try
                {
                    webElement = _driver.FindElement(By.ClassName(className));
                }
                catch (Exception)
                {
                    Thread.Sleep(10);
                }
            }
            return webElement;
        }
        public IWebElement GetElementByLinkText(string linkText)
        {
            IWebElement webElement = null;

            while (webElement == null)
            {
                try
                {
                    webElement = _driver.FindElement(By.ClassName(linkText));
                }
                catch (Exception)
                {
                    Thread.Sleep(10);
                }
            }
            return webElement;
        }
        public void RefreshPage() => Driver.Navigate().Refresh();
    }
}
