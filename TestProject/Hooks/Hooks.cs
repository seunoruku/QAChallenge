using System.Reflection;
using log4net;
using log4net.Config;
using PageObjectLibrary.Drivers;
using TechTalk.SpecFlow;


namespace TestProject.Hooks
{
    [Binding]
    public class Hooks 
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks
        private readonly TestBase testBase;
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public Hooks(TestBase testBase)
        {
            this.testBase = testBase;
        }
       
        [BeforeScenario]
        public void BeforeScenario()
        {
            XmlConfigurator.Configure();
            Logger.Info("Starting Scenario: " + ScenarioContext.Current.ScenarioInfo.Title);
            testBase.BaseOneTimeSetUp();
            testBase.BaseSetup();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            Logger.Info("Completed Scenario: " + ScenarioContext.Current.ScenarioInfo.Title);
            testBase.BaseOneTimeTearDown();

        }
    }
}
