using Atata;

namespace ITestProject
{
    using _ = InboxPage;

    public class InboxPage : BasePage<_>
    {
        //*[@class='sbj']/span[text()='Ласкаво просимо на I.UA!']
        [FindByXPath("//*[@class='sbj']/span[text()='Ласкаво просимо на I.UA!']")]
        public Text<_> WelcomeTxt { get; private set; }

        [FindByXPath("//*[@id='prflpudvmbox_userInfoPopUp']/ul/li[2][text()=' Добрий день, Andrii Hnatyshyn.']")]
        public Text<_> WelcomeMsgPopupTxt { get; private set; }
    }
}
