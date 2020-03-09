using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITestProject
{
    public interface IMessageBuilder<TPage, TBuilder> 
        where TPage: NewMessagePage
        where TBuilder: EmailBuilder
    {
        TBuilder To(string email);

        TBuilder Subject(string subjText);

        TPage Build();
    }
}
