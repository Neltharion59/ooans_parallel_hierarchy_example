using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ooans_par_inh_hier
{
    class XMLFileReaderWriter : FileReaderWriter
    {
        public override bool AddFileContent(File File, string Content)
        {
            bool Success = ValidFileType(File);
            if (Success)
            {
                XMLFile XMLFile = (XMLFile)File;

                XMLFile.Encoding = "UTF-16";
                XMLFile.XMLVersion = 1.3F;

                XMLFile.RootNode = new XMLTag("root");
                XMLTag Sentences = new XMLTag("sentences");
                Sentences.Attributes.Add(new XMLTagAttribute("count", "2"));
                XMLFile.RootNode.ChildrenNodes.Add(Sentences);
                XMLTag Sentence1 = new XMLTag("sentence");
                Sentences.ChildrenNodes.Add(Sentence1);
                Sentence1.Content = "Dnes je pekne.";
                XMLTag Sentence2 = new XMLTag("sentence");
                Sentences.ChildrenNodes.Add(Sentence2);
                Sentence2.Content = "Zajtra je skôr nepekne.";
            }
            return Success;
        }

        public override File ConstructFile(List<string> Path, string Name)
        {
            return new XMLFile(Path, Name);
        }

        public override string FileContentToString(File File)
        {
            string Result = null;
            if (ValidFileType(File))
            {
                XMLFile XMLFile = (XMLFile)File;
                Result = "<? xml version = \"" + XMLFile.XMLVersion + "\" encoding = \"" + XMLFile.Encoding + "\" ?>\n" + XMLFile.RootNode.ToText();
            }
            return Result;
        }

        public override string GetExtension()
        {
            return "xml";
        }

        public override bool ValidFileType(File File)
        {
            return File is XMLFile;
        }
    }
}
