using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITestProject
{
    class DomainItem
    {
            private List<object> _domains = new List<object>();

            public void Add(string part)
            {
                this._domains.Add(part);
            }

            public string ListItems()
            {
                string str = string.Empty;

                for (int i = 0; i < this._domains.Count; i++)
                {
                    str += this._domains[i];
                }

                return str;
            }
        }
}
