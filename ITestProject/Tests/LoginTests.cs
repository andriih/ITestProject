﻿using Allure.Commons;
using Atata;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;

namespace ITestProject
{
    [AllureNUnit]
    [TestFixture]
    public class LoginTests : UITestFixture
    {
        protected override DriverPoolUsage DriverPoolUsage => DriverPoolUsage.None;

        [OneTimeSetUp]
        public void ClearResultsDir()
        {
            AllureLifecycle.Instance.CleanupResultDirectory();
        }

        [Test]
        [AllureTag("TC-Email")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureIssue("ISSUE-1")]
        [AllureOwner("Andrii Hnatyshyn")]
        [AllureSuite("Login Suite")]
        [AllureSubSuite("Login")]
        public void testLogin()
        {
            AllureLifecycle.Instance.WrapInStep(() =>
            {
              LoginToEmail();
            }, "Login");
        }

        [Test]
        [AllureTag("TC-Email")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureIssue("ISSUE-1")]
        [AllureOwner("Andrii Hnatyshyn")]
        [AllureSuite("Login Suite")]
        [AllureSubSuite("Login")]
        public void testLogOut()
        {
            LoginToEmail()
                .Settings.Click()
                .Exit.ClickAndGo<LoginPage>();
        }

        [Test]
        [AllureTag("TC-Email")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureIssue("ISSUE-1")]
        [AllureOwner("Andrii Hnatyshyn")]
        [AllureSuite("Login Suite")]
        [AllureSubSuite("Login")]
        public void testLoginWithWrongCreds()
        {
            Go.To<LoginPage>()
                .Login.SetRandom()
                .Password.Set("Adrenalin1")
                .Domain.Set("email.ua")
                .SignIn.ClickAndGo<PassportPage>();
        }
    }
}