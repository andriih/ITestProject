using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITestProject.bin.Debug
{
    class DomainBuilder : Domain
    {

        private DomainItem _domain = new DomainItem();

        public DomainBuilder()
        {
            this.Reset();
        }
        public void Reset()
        {
            this._domain = new DomainItem();
        }

        public void buildIuaDomain()
        {
            this._domain.Add("i.ua");
        }

        public void buildUafmDomain()
        {
            this._domain.Add("ua.fm");
        }

        public DomainItem GetDomain()
        {
            DomainItem result = this._domain;

            this.Reset();

            return result;
        }
        
    }
}
