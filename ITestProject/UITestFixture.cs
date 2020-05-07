using Allure.Commons;
using Atata;
using NUnit.Allure.Core;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;


namespace ITestProject
{

    [TestFixture]
    [AllureNUnit]
    [Parallelizable(ParallelScope.All)]
    public class UITestFixture
    {

        protected virtual DriverPoolUsage DriverPoolUsage => DriverPoolUsage.None;

        public AtataConfig Config
        {
            get { return AtataConfig.Current; }
        }

        [SetUp]
        public void SetUp()
        {
            ConfigureAtataContext(AtataContext.Configure()).
                Build();
        }

        protected virtual AtataContextBuilder ConfigureAtataContext(AtataContextBuilder builder)
        {
            if (DriverPoolUsage == DriverPoolUsage.Fixture)
                return builder.UseDriverPool(this);
            else if (DriverPoolUsage == DriverPoolUsage.Global)
                return builder.UseDriverPool();
            else
                return builder;
        }

        [TearDown]
        public void TearDown()
        {
            AddAttachmentAfter();
            AtataContext.Current?.CleanUp(quitDriver: true);
        }
        
        [OneTimeTearDown]
        public static void AddAttachmentAfter()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                AllureLifecycle.Instance.AddAttachment($"{ AtataContext.Current.TestName}.png",
                "image/png",
                ((ITakesScreenshot)AtataContext.Current.Driver).GetScreenshot().AsByteArray);
            }
        }

        protected EmailPage LoginToEmail()
        {
            return Go.To<LoginPage>()
                 .Login.Set(Config.Account.Email)
                 .Password.Set(Config.Account.Password)
                 .Domain.Set(Config.Account.Domain)
                 .SignIn.ClickAndGo();
        }
    }
}
