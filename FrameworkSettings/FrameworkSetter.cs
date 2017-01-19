using System;

namespace FrameworkSettings
{
    public class FrameworkSetter
    {
        public string StreamNumber
        {
            get
            {
                var streamNumber = Environment.GetEnvironmentVariable("StreamNumber");
                return !string.IsNullOrEmpty(streamNumber) ? streamNumber : "http://www.valtech.com/";
            }
        }

        public string Browser
        {
            get
            {
                var browser = Environment.GetEnvironmentVariable("Browser");
                return !string.IsNullOrEmpty(browser) ? browser : "Chrome";
            }
        }

        public string WebDriverUrl
        {
            get
            {
                var webDriverUrl = Environment.GetEnvironmentVariable("WebDriverUrl");
                return !string.IsNullOrEmpty(webDriverUrl) ? webDriverUrl : Framework.Default.LocalDriverUrl;
            }
        }
    }
}
