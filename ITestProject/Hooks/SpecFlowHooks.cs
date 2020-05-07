using Allure.Commons;
using Atata;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace ITestProject.Hooks
{
  
    [Binding]
    public sealed class SpecFlowHooks : UITestFixture
    {
        [BeforeTestRun]
        public static void SetUpTestRun()
        {
            AtataContext.GlobalConfiguration.
                UseChrome().
                    WithArguments("start-maximized").
                    WithLocalDriverPath().
                UseBaseUrl("https://www.i.ua/").
                UseCulture("en-us").
                UseAllNUnitFeatures();
        }

        [BeforeScenario (Order = 0)]
        public static void SetUpScenario()
        {
            AtataContext.Configure().
                Build();
        }

        [AfterScenario]
        public static void TearDownScenario()
        {
            AddAttachmentAfter();
            AtataContext.Current?.CleanUp();
        }
    }
}
