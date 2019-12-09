

using Atata;
using NUnit.Framework;
using System;
using System.Reflection;
using DescriptionAttribute = System.ComponentModel.DescriptionAttribute;


namespace ITestProject
{
    public class LoginTests : UITestFixture
    {
  
        [Test]
        public void testLogin()
        {
            Go.To<LoginPage>()
                .Login.Set("andrii.hnatyshyn")
                .Password.Set("Adrenalin1")
                .Domain.Set("email.ua")
                .SignIn.ClickAndGo<EmailPage>();
        }

        [Test]
        public void testLogOut()
        {
            Go.To<LoginPage>()
                .Login.Set("andrii.hnatyshyn")
                .Password.Set("Adrenalin1")
                .Domain.Set("email.ua")
                .SignIn.ClickAndGo<EmailPage>()
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
