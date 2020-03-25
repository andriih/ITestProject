using AtataSamples.CsvDataSource;

namespace ITestProject
{
    class LoginModel
    {
        public string Login { get; set; }
        public string Password { get; set; }

        public override string ToString()
        {
            return TestParametersFormatter.Format(this);
        }
    }
}
