using Atata;
using NUnit.Framework;

namespace ITestProject
{
   public class EmailTests : UITestFixture
   {
        [Test]
        public void emailNewEmailSaveInDrafts()
        {

           LoginToEmail()
                .MakeMessage.ClickAndGo<NewMessagePage>()
                .to.Set("Test@Test.com")
                .Subject.Set("Test")
                .SaveInDrafts.ClickAndGo<EmailPage>()
                .EmailSavedTxt.Should.Exist()
                .EmailSavedTxt.Should.Contain("Лист успішно збережено");
        }

        [Test]
        public void ValidateSendingAnEmailWithoutSubject()
        {
            LoginToEmail()
                .MakeMessage.ClickAndGo<NewMessagePage>()
                .to.Set("Test@Test.com")
                //"Ви хочете відправити повідомлення без теми?"
                .send.Click().AcceprAlert().AcceprAlert()
                .ConfirmationOfSendTxt.Should.Exist() 
                .ConfirmationOfSendTxt.Should.Contain("Лист успішно відправлено адресатам");
        }

        [Test]
        public void DeleteItemFromDrafts()
        {
            LoginToEmail()
                .Drafts.ClickAndGo()
                .Products.Count.Get(out int count)
                .Products.Count.Should.Equal(count)
                .FirstDraft.Click()
                .DeleteBtn.Should.BeEnabled()
                .DeleteBtn.Click().AcceptAlert()
                .Products.Count.Should.Equal(count-1);
        }

    }
}
