using Atata;
using TechTalk.SpecFlow;


namespace ITestProject.StepDefinitions
{
    [Binding]
    public class LoginSteps : BaseSteps
    {
        [Given(@"I am on Login page")]
        public void GivenIAmOnLoginPage()
        {
            Go.To<LoginPage>();
        }
        
        [Given(@"I type (.*) and (.*) to the form")]
        public void GivenITypeAndrii_HnatyshynAndAdrenalinToTheForm(string login, string password)
        {
            On<LoginPage>()
                .Login.Set(login)
                .Password.Set(password);
        }
        
        [Given(@"I also choose (.*)")]
        public void GivenIAlsoChooseEmail_Ua(string domain)
        {
            On<LoginPage>().Domain.Set(domain);
        }
        
        [When(@"I press login")]
        public void WhenIPressLogin()
        {
            On<LoginPage>().SignIn.Click();
        }
        
        [Then(@"the result should be successfull login to the I\.UA")]
        public void ThenTheResultShouldBeSuccessfullLoginToTheI_UA()
        {
            On<EmailPage>();
        }
    }
}
