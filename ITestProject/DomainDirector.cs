using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITestProject
{
    class DomainDirector
    {
        private Domain _builder;

        public Domain Builder
        {
            set { _builder = value; }
        }

        public void loginWithDefaultDomain()
        {
            this._builder.buildIuaDomain();
        }

        public void loginWithFeaturedDonain()
        {
            this._builder.buildIuaDomain();
        }
    }
}
