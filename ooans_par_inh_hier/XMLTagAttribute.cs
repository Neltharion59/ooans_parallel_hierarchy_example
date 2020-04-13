using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ooans_par_inh_hier
{
    class XMLTagAttribute
    {
        public String Name { get; }
        public String Value { get; }

        public XMLTagAttribute(String Name, String Value)
        {
            this.Name = Name;
            this.Value = Value;
        }
        public XMLTagAttribute CreateCopy()
        {
            return new XMLTagAttribute(Name, Value);
        }
    }
}
