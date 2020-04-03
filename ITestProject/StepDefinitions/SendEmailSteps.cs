using Atata;
using TechTalk.SpecFlow;

namespace ITestProject.StepDefinitions
{
    [Binding]
    public class SendEmailSteps : BaseSteps
    {
        [Given(@"I am on Email Page")]
        public void GivenIAmOnEmailPage()
        {
            Go.To<LoginPage>()
                .Login.Set("andrii.hnatyshyn")
                .Password.Set("Adrenalin1")
                .Domain.Set("email.ua")
                .SignIn.Click();
        }
        
        [When(@"I navigate to New Message Page by Make Message button")]
        public void WhenINavigateToNewMessagePageByMakeMessageButton()
        {
            On<EmailPage>().MakeMessage.Click();
        }
        
        [When(@"I type (.*) and (.*) to the form")]
        public void WhenITypeAndrii_HnatyshynGmail_ComAndTestSubjectToTheForm(string To, string Subject)
        {
            On<NewMessagePage>()
                .to.Set(To)
                .Subject.Set(Subject);
        }
        
        [When(@"I also type (.*)")]
        public void WhenIAlsoTypeTest(string Body)
        {
            On<NewMessagePage>()
                  .text.Set(Body);
        }
        
        [When(@"I click Send")]
        public void WhenIClickSend()
        {
            On<NewMessagePage>().send.Click();
        }
        
        [Then(@"I verify that message was sent")]
        public void ThenIVerifyThatMessageWasSent()
        {
            On<EmailPage>();
        }
    }
}
