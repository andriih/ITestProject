using Atata;
using OpenQA.Selenium;

namespace ITestProject
{
    using _ = NewMessagePage;

    //andrii.hnatyshyn@email.ua
    [VerifyContentMatches(TermMatch.Contains, "andrii.hnatyshyn@email.ua")]
    public class NewMessagePage : BasePage<_>
    {

        [WaitFor]
        [FindById]
        public TextArea<_> to { get; protected set; }

        [FindById]
        public TextArea<_> text { get; protected set; }

        [FindByName("subject")]
        public TextInput<_> Subject { get; private set; }

        //save_in_drafts
        [FindByName("save_in_drafts")]
        public Button<_> SaveInDrafts { get; private set; }

        [FindByName]
        public Button<_> send { get; private set; }

        [CloseConfirmBox]
        public ButtonDelegate<_> FirstConfirmation { get; private set; }

        [FindByXPath("//*[@class='block_confirmation']/div[contains(@class,'content')]")]
        public Text<_> ConfirmationOfSendTxt { get; private set; }

        //cc_sw
        [FindById("cc_sw")]
        public Control<_> CopyButton { get; private set; }

        [FindById]
        public TextArea<_> cc{ get; private set; }
    }
}
