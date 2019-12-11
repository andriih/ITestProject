using Atata;
using OpenQA.Selenium;

namespace ITestProject
{
    public abstract class BasePage<TOwner> : Page<TOwner>
        where TOwner : BasePage<TOwner>
    {
        public TOwner AcceptAlert()
        {
            IAlert alert = Driver.SwitchTo().Alert();
            alert.Accept();
            return Owner;
        }
    }
}
