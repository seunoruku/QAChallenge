using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using PageObjectLibrary.Pages;
using TestProject.Hooks;
using TestProject.Support;


namespace TestProject.Steps
{
    [Binding]
    public class TestSteps 
    {
        private readonly WorldHelper helper;
        public TestSteps(WorldHelper worldHelper)
        {
            helper = worldHelper;
        }
          
        [Given(@"I am on Valtech Homepage")]
        public void GivenIAmOnValtechHomepage()
        {
            var text = helper.GetSearchPage().VerifyHomepage();
            System.Console.WriteLine(text);
            Assert.IsTrue(helper.GetSearchPage().VerifyHomepage().ToLower().Contains("valtech"));
        }

        [Then(@"I should be able to see the latest news section")]
        public void ThenIShouldBeAbleToSeeTheLatestNewsSection()
        {
            var text = helper.GetSearchPage().VerifyLatestNews();
            System.Console.WriteLine(text);
            Assert.IsTrue(helper.GetSearchPage().VerifyLatestNews().ToLower().Contains("latest news"));
        }

        [When(@"I choose to navigate to a (.*)")]
        public void WhenIChooseToNavigateToA(string menulink)
        {
            helper.GetSearchPage().ClickLink(menulink);
        }

        [Then(@"I should be directed to the (.*)")]
        public void ThenIShouldBeDirectedToThe(string menulink)
        {

            System.Console.WriteLine("Link from test: " + menulink);
            System.Console.WriteLine("Link from webpage: " + helper.GetSearchPage().ReturnPageTitle(menulink));
            Assert.IsTrue(helper.GetSearchPage().ReturnPageTitle(menulink).Contains(menulink.ToLower()));
        }


    }
}
