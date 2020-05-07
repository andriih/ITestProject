using Allure.Commons;
using Atata;
using NUnit.Allure.Core;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;

namespace ITestProject
{
    [TestFixture]
    [AllureNUnit]
    [SetUpFixture]
    public class SetUpFixture
    {

        [OneTimeSetUp]
        public void GlobalSetUp()
        {
            AtataContext.GlobalConfiguration.
                ApplyJsonConfig<AtataConfig>().
                UseChrome().
                WithArguments("start-maximized").
                UseBaseUrl("https://www.i.ua/").
                UseCulture("en-us").
                UseNUnitTestName().
                AddNUnitTestContextLogging().
                LogNUnitError().
                UseAssertionExceptionType<NUnit.Framework.AssertionException>().
                UseNUnitAggregateAssertionStrategy().
                UseAllNUnitFeatures();
        }

        [OneTimeTearDown]
        public void GlobalTearDown()
        {
            DriverPool.CloseAll();
        }
    }
}
