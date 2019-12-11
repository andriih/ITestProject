using Atata;
using NUnit.Framework;

namespace ITestProject
{
    public class LoginTests : UITestFixture
    {
  
        [Test]
        public void testLogin()
        {
            LoginToEmail();
        }

        [Test]
        public void testLogOut()
        {
            LoginToEmail()
                .Settings.Click()
                .Exit.ClickAndGo<LoginPage>();
        }

        [Test]
        public void testLoginWithWrongCreds()
        {
            Go.To<LoginPage>()
                .Login.SetRandom()
                .Password.Set("Adrenalin1")
                .Domain.Set("email.ua")
                .SignIn.ClickAndGo<PassportPage>();
        }
    }
}
