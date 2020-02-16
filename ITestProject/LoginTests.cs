using Allure.Commons;
using Atata;
using ITestProject.bin.Debug;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.IO;

namespace ITestProject
{

    [AllureNUnit]
    [TestFixture]
    public class LoginTests : UITestFixture
    {
        [TearDown]
        public void AddAttachmentAfter()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                AllureLifecycle.Instance.AddAttachment($"{ AtataContext.Current.TestName}.png",
                "image/png",
                ((ITakesScreenshot)AtataContext.Current.Driver).GetScreenshot().AsByteArray);
            }
         }

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

            AddAttachmentAfter();

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
           AddAttachmentAfter();
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
           AddAttachmentAfter();
        }

        [Test]
        [AllureTag("TC-Email")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureIssue("ISSUE-1")]
        [AllureOwner("Andrii Hnatyshyn")]
        [AllureSuite("Login Suite")]
        [AllureSubSuite("Login")]
        public void testLoginWithWrongCredsDomain()
        {
            var director = new DomainDirector();
            var builder = new DomainBuilder();

            director.Builder = builder;
            //director.loginWithFeaturedDonain();
            builder.buildUafmDomain();

            Go.To<LoginPage>()
                .Login.Set("andrii.hnatyshyn")
                .Password.Set("Adrenalin1")
                .Domain.Set(builder.GetDomain().ListItems())
                .SignIn.ClickAndGo<PassportPage>();
            AddAttachmentAfter();
        }
    }
}