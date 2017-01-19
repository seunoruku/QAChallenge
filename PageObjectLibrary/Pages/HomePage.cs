using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace PageObjectLibrary.Pages
{
    public class HomePage : BasePage
    {
        
        [FindsBy(How = How.XPath, Using = ".//*[@id='container']/div[2]/div[3]/div[1]/header/h2")]
        public IWebElement LatestNews;

        [FindsBy(How = How.XPath, Using = ".//*[@id='navigationMenuWrapper']/div/ul/li[1]/a/span")]
        public IWebElement Work;

        [FindsBy(How = How.XPath, Using = ".//*[@id='navigationMenuWrapper']/div/ul/li[2]/a/span")]
        public IWebElement Service;

        [FindsBy(How = How.XPath, Using = ".//*[@id='navigationMenuWrapper']/div/ul/li[3]/a/span")]
        public IWebElement Industries;

        [FindsBy(How = How.XPath, Using = ".//*[@id='navigationMenuWrapper']/div/ul/li[4]/a/span")]
        public IWebElement Insights;

        [FindsBy(How = How.XPath, Using = ".//*[@id='navigationMenuWrapper']/div/ul/li[5]/a/span")]
        public IWebElement Careers;

        [FindsBy(How = How.XPath, Using = ".//*[@id='navigationMenuWrapper']/div/ul/li[6]/a/span")]
        public IWebElement Investors;

        
        public string GetPageURL()
        {
            return driver.Url;
        }

        public HomePage(IWebDriver driver): base(driver)
        {
            
        }

       
        public void ClickLink(string menulink)
        {

            switch (menulink)
            {
                case "cases":
                    WaitUntilDisplayed(Work);
                    Work.Click();
                    break;
                case "services":
                    WaitUntilDisplayed(Service);
                    Service.Click();
                    break;
                case "industries":
                    WaitUntilDisplayed(Industries, 5);
                    Industries.Click();
                    break;
                case "blog":
                    WaitUntilDisplayed(Investors, 5);
                    Insights.Click();
                    break;
                case "jobs":
                    WaitUntilDisplayed(Insights);
                    Careers.Click();
                    break;
                case "investors":
                    WaitUntilDisplayed(Careers);
                    Investors.Click();
                    break;
                
                default:
                    Console.WriteLine("Link not found");
                    break;
            }

        }

        public string ReturnPageTitle(string menulink)
        {
            var url = "https://www.valtech.com/" + menulink;
            WaitForUrl(url, 5);
            return driver.Url.ToLower();
                    
        }

        
        public string VerifyHomepage()
        {
            
            return driver.Title.ToLower();
        }

        public string VerifyLatestNews()
        {
            return LatestNews.Text;
        }
    }
}
