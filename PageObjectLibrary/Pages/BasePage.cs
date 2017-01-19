using System;
using System.Linq;
using System.Reflection;
using System.Threading;
using FrameworkSettings;
using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace PageObjectLibrary.Pages
{
    public class BasePage
    {
        protected readonly IWebDriver driver;
        private static readonly TimeSpan Timeout = TimeSpan.FromSeconds(Framework.Default.DefaultTimeoutSeconds);
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private string _exmessage;

        protected BasePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

           
        protected bool WaitForUrl(string expectedUrl, int numberOfSeconds)
        {
            for (var i = 0; i < numberOfSeconds; i++)
            {
                var currentUrl = new Uri(driver.Url.ToLower());
                if (currentUrl.LocalPath.Contains(expectedUrl.ToLower()))
                {
                    return true;
                }
                Thread.Sleep(TimeSpan.FromSeconds(1));
            }
            return false;
        }

        protected void WaitUntilDisplayed(IWebElement element, int timeout)
        {
            for (var i = 0; i < timeout; i++)
            {
                try
                {
                    if (element.Displayed)
                    {
                        return;
                    }
                }
                catch (NoSuchElementException)
                {
                }
                Thread.Sleep(TimeSpan.FromSeconds(1));
            }
            throw new Exception("Element is not displayed");
        }

        protected void WaitUntilDisplayed(IWebElement element)
        {
            var timeout = (int)Framework.Default.DefaultTimeoutSeconds;
            for (var i = 0; i < timeout; i++)
            {
                try
                {
                    if (element.Displayed)
                    {
                        return;
                    }
                }
                catch (NoSuchElementException)
                {
                }
                Thread.Sleep(TimeSpan.FromSeconds(1));
            }
            throw new Exception("Element is not displayed");
        }

    }
}
