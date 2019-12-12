﻿using Atata;
using NUnit.Allure.Core;
using NUnit.Framework;


namespace ITestProject
{
    [TestFixture]
    public class UITestFixture
    {
        public AtataConfig Config
        {
            get { return AtataConfig.Current; }
        }
       
        [SetUp]
        public void SetUp()
        {
            AtataContext.Configure().
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
                TakeScreenshotOnNUnitError().
                AddScreenshotFileSaving().
                 WithFileName(screenshotInfo => $"{screenshotInfo.Number:D2} - {screenshotInfo.PageObjectFullName}{screenshotInfo.Title?.Prepend(" - ")}").
                Build();
        } 

        [TearDown]
        public void TearDown()
        {
            AtataContext.Current?.CleanUp();
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
