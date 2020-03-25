using Atata;

namespace ITestProject
{
    using _ = LoginPage;

    [VerifyTitle("І.UA - твоя пошта")]
    [VerifyContent("Пошта")]

    public class LoginPage : BasePage<_>
    {
        [FindByName("login")]
        public TextInput<_> Login { get; private set; }

        [FindByName("pass")]
        public PasswordInput<_> Password { get; private set; }

        [FindByLabel("I agree to terms of service and privacy policy")]
        public CheckBox<_> RememberMe { get; private set; }

        [FindByName("domn")]
        [Format("{0}")]
        public Select<string, _> Domain { get; private set; }

        [FindByTitle("Вхід на пошту")]
        public Button<EmailPage,_> SignIn { get; private set; }

        [FindByTitle("вийти")]
        public Button<_> Exit { get; private set; }
    }
}
