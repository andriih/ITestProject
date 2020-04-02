using Atata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace ITestProject.Hooks
{
    [Binding]
    public sealed class SpecFlowHooks
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

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

        [BeforeScenario]
        public static void SetUpScenario()
        {
            AtataContext.Configure().
                Build();
        }

        [AfterScenario]
        public static void TearDownScenario()
        {
            AtataContext.Current?.CleanUp();
        }
    }
}
