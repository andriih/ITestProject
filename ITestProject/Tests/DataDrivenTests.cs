using Atata;
using AtataSamples.CsvDataSource;
using NUnit.Framework;

namespace ITestProject
{
    class DataDrivenTests : UITestFixture
    {
        public static TestCaseData[] LoginModels => CsvSource.Get<LoginModel>("Data/login-models.csv");

        [TestCaseSource(nameof(LoginModels))]
        public void LoginWithDifferentCreds(LoginModel model)
        {
            Go.To<LoginPage>()
                 .Login.Set(model.Login)
                 .Password.Set(model.Password.Trim())
                 .Domain.Set("email.ua")
                 .SignIn.ClickAndGo<EmailPage>();
        }
    }
}
