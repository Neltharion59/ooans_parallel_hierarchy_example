using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ooans_par_inh_hier_ref1
{
    class XMLTag
    {
        public String Name { get; }
        public String Content { get; set; }
        public List<XMLTag> ChildrenNodes { get; set; }
        public List<XMLTagAttribute> Attributes { get; set; }
        public XMLTag(String Name)
        {
            this.Name = Name;
            this.Content = "";
            this.ChildrenNodes = new List<XMLTag>();
            this.Attributes = new List<XMLTagAttribute>();
        }
        public XMLTag CreateCopy()
        {
            XMLTag Copy = new XMLTag(this.Name);
            Copy.Content = this.Content;
            Copy.ChildrenNodes = this.ChildrenNodes.Select(node => node.CreateCopy()).ToList();
            Copy.Attributes = this.Attributes.Select(attr => attr.CreateCopy()).ToList();
            return Copy;
        }

        public String ToText(String indent = "")
        {
            string Result = indent + "<" + this.Name;
            foreach (XMLTagAttribute Attribute in this.Attributes)
            {
                Result += " " + Attribute.Name + "=\"" + Attribute.Value + "\"";
            }
            Result += ">\n";

            if (!"".Equals(this.Content))
            {
                Result += indent + "\t" + this.Content + "\n";
            }

            foreach(XMLTag Child in this.ChildrenNodes)
            {
                Result += Child.ToText(indent + "\t");
            }

            Result += indent + "</" + this.Name + ">\n";

            return Result;
        }

    }
}
