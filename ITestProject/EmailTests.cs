using Atata;
using NUnit.Framework;

namespace ITestProject
{
   public class EmailTests : UITestFixture
   {
        [Test]
        public void emailNewEmailSaveInDrafts()
        {
            Go.To<LoginPage>()
                .Login.Set("andrii.hnatyshyn")
                .Password.Set("Adrenalin1")
                .Domain.Set("email.ua")
                .SignIn.ClickAndGo<EmailPage>()
            .MakeMessage.ClickAndGo<NewMessagePage>()
            .to.Set("Test@Test.com")
            .Subject.Set("Test")
            .SaveInDrafts.ClickAndGo<EmailPage>()
            .EmailSavedTxt.Should.Exist()
            .EmailSavedTxt.Should.Contain("Лист успішно збережено");
        }
   }
}
