using System;
using System.Reflection;
using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Safari;

namespace PageObjectLibrary.Drivers
{
    public class DriverLauncher
    {
        protected static IWebDriver driver;
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public DriverLauncher InstantiateDriver()
        {
            string browserName = FrameworkSettings.Framework.Default.Browser;

            if (browserName.ToLower().Contains("chrome"))
            {
                driver = new ChromeDriver();
                Logger.Info("Test exeuted on the Chrome Browser");
            }
            else if (browserName.ToLower().Contains("firefox"))
            {
                driver = new FirefoxDriver();
                Logger.Info("Test exeuted on the Firefox Browser");
            }
            else if (browserName.ToLower().Contains("internetexplorer"))
            {
                driver = new InternetExplorerDriver();
                Logger.Info("Test executed on the Internet Explorer Browser");
            }
            else if (browserName.ToLower().Contains("safari"))
            {
                driver = new SafariDriver();
                Logger.Info("Test executed on the Safari Browser");
            }
            else if (browserName.ToLower().Contains("phantomjs"))
            {
                driver = new PhantomJSDriver();
                Logger.Info("Test executed on the PhantomJs Browser");
            }
            else
            {
                Logger.Error("There is no such browser as " + browserName);
                throw new Exception("There is no such browser as " + browserName);
            }
            return new DriverLauncher();
        }


        public DriverLauncher SetUpCleanDriver()
        {
            try
            {
                Logger.Info("SetUpCleanDriver started successfully");
                driver.Manage().Window.Maximize();
                Logger.Info("The browser has been maximized");
                driver.Manage().Cookies.DeleteAllCookies();
                Logger.Info("The browser Cookies have all been cleared");
                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(25));
                Logger.Info("The browser has now applied implicit wait ");
            }
            catch (Exception e)
            {
                Logger.Error("SetUpCleanDriver encountered an error: ", e);
            }
            return new DriverLauncher();
        }

     
        public void DestroyDriver()
        {
            try
            {
                Logger.Info("DestroyDriver has started");
                driver.Quit();
                Logger.Info("The browser has been quit");
                driver = null;
                Logger.Info("There is no active browser");
            }
            catch (Exception e)
            {
                Logger.Error("DestroyDriver has encountered error: ", e);
            }
        }
    }
}
