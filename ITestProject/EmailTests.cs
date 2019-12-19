using Allure.Commons;
using Atata;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System.IO;

namespace ITestProject
{
    [AllureNUnit]
    [TestFixture]
    public class EmailTests : UITestFixture
   {

        [OneTimeSetUp]
        public void ClearResultsDir()
        {
            AllureLifecycle.Instance.CleanupResultDirectory();
        }

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

        [Test]
        [AllureTag("TC-Email")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureIssue("ISSUE-1")]
        [AllureOwner("Andrii Hnatyshyn")]
        [AllureSuite("Email Suite")]
        [AllureSubSuite("Email")]
        public void emailNewEmailSaveInDrafts()
        {

           LoginToEmail()
                .MakeMessage.ClickAndGo<NewMessagePage>()
                .to.Set("Test@Test.com")
                .Subject.Set("Test")
                .SaveInDrafts.ClickAndGo<EmailPage>()
                .EmailSavedTxt.Should.Exist()
                .EmailSavedTxt.Should.Contain("Лист успішно збережено");

            AddAttachmentAfter();
        }

        [Test]
        [AllureTag("TC-Email")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureIssue("ISSUE-1")]
        [AllureOwner("Andrii Hnatyshyn")]
        [AllureSuite("Email Suite")]
        [AllureSubSuite("Email")]
        public void ValidateSendingAnEmailWithoutSubject()
        {
            LoginToEmail()
                .MakeMessage.ClickAndGo<NewMessagePage>()
                .to.Set("Test@Test.com")
                //"Ви хочете відправити повідомлення без теми?"
                .send.Click().AcceptAlert().AcceptAlert()
                .ConfirmationOfSendTxt.Should.Exist() 
                .ConfirmationOfSendTxt.Should.Contain("Лист успішно відправлено адресатам---");
            AddAttachmentAfter();
        }

 
        [Test]
        [AllureTag("TC-Email")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureIssue("ISSUE-1")]
        [AllureOwner("Andrii Hnatyshyn")]
        [AllureSuite("Email Suite")]
        [AllureSubSuite("Email")]
        public void DeleteItemFromDrafts()
        {
            LoginToEmail()
                .Drafts.ClickAndGo()
                .Products.Count.Get(out int count)
                .FirstDraft.Click()
                .DeleteBtn.Should.BeEnabled()
                .DeleteBtn.Click().AcceptAlert()
                .Products.Count.Should.Equal(count-1);

            AddAttachmentAfter();
        }

        [Test]
        [AllureTag("TC-Email")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureIssue("ISSUE-1")]
        [AllureOwner("Andrii Hnatyshyn")]
        [AllureSuite("Email Suite")]
        [AllureSubSuite("Email")]
        public void ValidationOfWelcomeMessage()
        {
            LoginToEmail()
                .Inbox.ClickAndGo()
                .WelcomeTxt.Should.Exist()
                .WelcomeTxt.Should.Contain("Ласкаво просимо на I.UA!")
                .WelcomeTxt.Hover()
                .WelcomeMsgPopupTxt.Wait(Until.Visible)
                .WelcomeMsgPopupTxt.Should.BeVisible()
                //.Report.Screenshot()
                .WelcomeMsgPopupTxt.Should.Contain(" Добрий день, Andrii Hnatyshyn.---");

            AddAttachmentAfter();
        }
    }
}
