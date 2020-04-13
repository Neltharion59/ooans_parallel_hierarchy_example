using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ooans_par_inh_hier
{
    class XMLFile : File
    {
        private static float DefaultXMLVersion = 1.0f;
        private static string DefaultEncoding = "UTF-8";
        public XMLTag RootNode { get; set; }
        public float XMLVersion { get; set; }
        public String Encoding { get; set; }
        public XMLFile(List<string> Path, string Name) : base(Path, Name)
        {
            this.RootNode = null;
            this.XMLVersion = XMLFile.DefaultXMLVersion;
            this.Encoding = Encoding;
        }
        public override File CreateCopy(List<string> Path, string Name)
        {
            XMLFile Copy = new XMLFile(Path, Name);
            Copy.RootNode = this.RootNode == null ? null : this.RootNode.CreateCopy();
            Copy.XMLVersion = this.XMLVersion;
            Copy.Encoding = this.Encoding;
            return Copy;
        }
    }
}
