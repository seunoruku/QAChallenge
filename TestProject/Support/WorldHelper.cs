using PageObjectLibrary.Pages;
using PageObjectLibrary.Drivers;

namespace TestProject.Support
{
    public class WorldHelper : TestBase  
    {
        private HomePage homePage;

        public HomePage GetSearchPage()
        {
            if (homePage == null)
            {
                homePage = new HomePage(driver);
            }
            return homePage;
        }

        
    }
}
