using Atata;
using OpenQA.Selenium;

namespace ITestProject
{
    using _ = NewMessagePage;

    //andrii.hnatyshyn@email.ua
    [VerifyContentMatches(TermMatch.Contains, "andrii.hnatyshyn@email.ua")]
    public class NewMessagePage : Page<_>
    {
        [WaitFor]
        [FindById]
        public TextArea<_> to { get; private set; }

        [FindByName("subject")]
        public TextInput<_> Subject { get; private set; }

        //save_in_drafts
        [FindByName("save_in_drafts")]
        public Button<_> SaveInDrafts { get; private set; }

        [FindByName]
        public Button<_> send { get; private set; }

        [CloseConfirmBox]
        public ButtonDelegate<_> FirstConfirmation{ get; private set; }

        public _ AcceprAlert()
        {
            IAlert alert = Driver.SwitchTo().Alert();
            alert.Accept();
            return Owner;
        }

        [FindByXPath("//*[@class='block_confirmation']/div[contains(@class,'content')]")]
        public Text<_> ConfirmationOfSendTxt { get; private set; }
    }
}
