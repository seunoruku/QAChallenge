using System;
using System.Diagnostics;
using System.Reflection;
using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using FrameworkSettings;

namespace PageObjectLibrary.Drivers
{
    public class TestBase
    {
        protected static IWebDriver driver;
        private DesiredCapabilities _cap;
        private static readonly FrameworkSetter framework = new FrameworkSetter();
        private static readonly Framework frameworkSettings = new Framework();
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        protected string Environment;

        protected string Browser
        {
            get { return framework.Browser; }
        }

        public TestBase BaseOneTimeSetUp()
        {
            Environment = framework.StreamNumber;
            var remoteDriverUrl = framework.WebDriverUrl;
            SetBrowser(remoteDriverUrl);
            driver.Manage().Window.Maximize();
            return new TestBase();
        }

        private void SetBrowser(string remoteDriverUrl)
        {
            if (frameworkSettings.ActivateStandaloneServer.Equals("True"))
            {
                Debug.Assert(Browser != null, "Browser != null");
                switch (Browser.ToLower())
                {
                    case "chrome":
                        _cap = DesiredCapabilities.Chrome();
                        var options = new ChromeOptions();
                        options.AddArguments("--test-type");
                        _cap = options.ToCapabilities() as DesiredCapabilities;
                        break;
                    case "firefox":
                        var fp = new FirefoxProfile();
                        _cap = DesiredCapabilities.Firefox();
                        _cap.SetCapability(FirefoxDriver.ProfileCapabilityName, fp);
                        break;
                    case "internetexplorer":
                        _cap = DesiredCapabilities.InternetExplorer();
                        _cap.SetCapability("nativeEvents", false);
                        _cap.SetCapability("ignoreZoomSetting", true);
                        break;
                }
                var commandTimeout = TimeSpan.FromSeconds(frameworkSettings.WebDriverTimeoutSeconds);
                driver = new RemoteWebDriver(new Uri(remoteDriverUrl), _cap, commandTimeout);
            }
            else
            {
                driver = new FirefoxDriver();
            }
        }

        public TestBase BaseSetup()
        {
            driver.Manage().Cookies.DeleteAllCookies();
            driver.Navigate().GoToUrl(Environment);
            return new TestBase();
        }


        public TestBase BaseOneTimeTearDown()
        {
            try
            {
                driver.Quit();
                Logger.Info("The browser has been quit");
                driver = null;
            }
            catch (Exception e)
            {
                Logger.Error("DestroyDriver has encountered error: ", e);
            }
            return new TestBase();
        }
    }
}
