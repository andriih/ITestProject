using Atata;
using NUnit.Framework;

namespace ITestProject
{
    [TestFixture]
    public class UITestFixture
    {
        public AtataConfig Config
        {
            get { return AtataConfig.Current; }
        }

        [SetUp]
        public void SetUp()
        {
            AtataContext.Configure().
                ApplyJsonConfig<AtataConfig>().
                UseChrome().
                WithArguments("start-maximized").
                UseBaseUrl("https://www.i.ua/").
                UseCulture("en-us").
                UseNUnitTestName().
                AddNUnitTestContextLogging().
                LogNUnitError().
                UseAssertionExceptionType<NUnit.Framework.AssertionException>().
                UseNUnitAggregateAssertionStrategy().
                Build();
        }

        [TearDown]
        public void TearDown()
        {
            AtataContext.Current?.CleanUp();
        }

        protected EmailPage LoginToEmail()
        {
            return Go.To<LoginPage>()
                 .Login.Set(Config.Account.Email)
                 .Password.Set(Config.Account.Password)
                 .Domain.Set(Config.Account.Domain)
                 .SignIn.ClickAndGo();
        }
    }
}
