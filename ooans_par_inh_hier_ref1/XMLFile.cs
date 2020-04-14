using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ooans_par_inh_hier_ref1
{
    class XMLFile : File
    {
        private static float DefaultXMLVersion = 1.0f;
        private static string DefaultEncoding = "UTF-8";
        public XMLTag RootNode { get; set; }
        public float XMLVersion { get; set; }
        public String Encoding { get; set; }
        public static List<(String, String, bool)> ActionHistory { get; } = new List<(string, string, bool)>();
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

        public override void AddToActionHistory(string FullPath, string ActionLabel, bool Success)
        {
            XMLFile.ActionHistory.Add((FullPath, ActionLabel, Success));
        }

        public override bool AddFileContent(string Content)
        {
            this.Encoding = "UTF-16";
            this.XMLVersion = 1.3F;

            this.RootNode = new XMLTag("root");
            XMLTag Sentences = new XMLTag("sentences");
            Sentences.Attributes.Add(new XMLTagAttribute("count", "2"));
            this.RootNode.ChildrenNodes.Add(Sentences);
            XMLTag Sentence1 = new XMLTag("sentence");
            Sentences.ChildrenNodes.Add(Sentence1);
            Sentence1.Content = "Dnes je pekne.";
            XMLTag Sentence2 = new XMLTag("sentence");
            Sentences.ChildrenNodes.Add(Sentence2);
            Sentence2.Content = "Zajtra je skôr nepekne.";
            
            return true;
        }

        public override bool ValidFileType(File File)
        {
            return File is XMLFile;
        }

        public override string FileContentToString()
        {
            return "<? xml version = \"" + this.XMLVersion + "\" encoding = \"" + this.Encoding + "\" ?>\n" + this.RootNode.ToText();
        }

        public override string GetExtension()
        {
            return "xml";
        }
    }
}
