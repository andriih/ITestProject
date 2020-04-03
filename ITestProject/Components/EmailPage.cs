using Atata;

namespace ITestProject
{

    using _ = EmailPage;
    [VerifyContentMatches(TermMatch.Contains, "Вхідні")]

    public class EmailPage : BasePage<_>
    {
        [FindByXPath("//*[contains(@class, 'ho_menu_item')] /span[@class='icon-ho ho_settings ho_i_settings']")]
        public Clickable<_> Settings { get; private set; }

        //Вийти
        [FindByXPath("//*[@id='accountSettingsPopup']/ul/li[7]/a")]       
        public Clickable<LoginPage,_> Exit { get; private set; }

        [FindByXPath("//*[contains(@class, 'make_message')]/a")]
        public Link<NewMessagePage, _> MakeMessage { get; private set; }

        //Лист успішно збережено
        [FindByContent("Лист успішно збережено")]
        public Text<_> EmailSavedTxt { get; private set; }

        [FindByXPath("//*[@class='block_confirmation']/div[contains(@class,'content')]")]
        public Text<_> ConfirmationOfSendTxt { get; private set; }

        [FindByXPath("//*[@class='list_underlined']/li[3]/a")]
        public Link<DraftsPage,_> Drafts { get; private set; }

        [FindByXPath("//*[@class='list_underlined']/li[1]/a")]
        public Link<InboxPage, _> Inbox { get; private set; }
    }
}
