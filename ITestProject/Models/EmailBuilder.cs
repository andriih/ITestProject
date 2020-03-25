using Atata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITestProject
{
    public class EmailBuilder : IMessageBuilder<NewMessagePage,EmailBuilder>
    {
        private string email = "andrii.hnatyshyh@gmail.com";
        private string subjText = "test subject - test";
        private string cc = "test-copy@mail.com";

        private static NewMessagePage _message;
        public EmailBuilder(NewMessagePage obj)
        {
            _message = obj;
        }
        public EmailBuilder To(string email)
        {
            _message.to.Set(email);
            return this;
        }

        public EmailBuilder BuildEmailWithoutBody()
        {
            _message.to.Set(email);
            _message.Subject.Set(subjText);
            return this;
        }
        public EmailBuilder BuildEmailWithCopy()
        {
            _message.CopyButton.Click();
            _message.to.Set(email);
            _message.Subject.Set(subjText);
            _message.cc.Set(cc);

            return this;
        }

        public EmailBuilder Subject(string subjText)
        {
            _message.Subject.Set(subjText);
            return this;
        }

        public EmailBuilder WithBody(string body)
        {
            _message.text.Set(body);
            return this;
        }
        public NewMessagePage Build() => new NewMessagePage();
    }
}
