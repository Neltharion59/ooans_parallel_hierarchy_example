using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ooans_par_inh_hier
{
    class PlainTextReaderWriter : FileReaderWriter
    {
        public PlainTextReaderWriter() : base()
        {
        }

        public override bool AddFileContent(File File, string Content)
        {
            bool Success = ValidFileType(File);
            if (Success)
            {
                PlainTextFile PTFile = (PlainTextFile)File;
                PTFile.Text = Content;
            }
            return Success;
        }

        public override File ConstructFile(List<string> Path, string Name)
        {
            return new PlainTextFile(Path, Name);
        }

        public override string FileContentToString(File File)
        {
            string Result = null;
            if (ValidFileType(File))
            {
                PlainTextFile PTFile = (PlainTextFile) File;
                Result = PTFile.Text;
            }
            return Result;
        }

        public override string GetExtension()
        {
            return "txt";
        }

        public override bool ValidFileType(File File)
        {
            return File is PlainTextFile;
        }
    }
}
