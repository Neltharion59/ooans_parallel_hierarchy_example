using System;
using System.Collections.Generic;

namespace ooans_par_inh_hier_ref1
{
    class PlainTextFile : File
    {
        public String Text { get; set; }
        public static List<(String, String, bool)> ActionHistory { get; } = new List<(string, string, bool)>();
        public PlainTextFile(List<string> Path, string Name) : base(Path, Name)
        {
            this.Text = "";
        }

        public override File CreateCopy(List<string> Path, string Name)
        {
            PlainTextFile Copy = new PlainTextFile(Path, Name);
            Copy.Text = this.Text;
            return Copy;
        }

        public override bool AddFileContent(string Content)
        {
            bool Success = !(Content == null);
            if (Success)
            {
                this.Text = Content;
            }
            return Success;
        }

        public override bool ValidFileType(File File)
        {
            return File is PlainTextFile;
        }

        public override string FileContentToString()
        {
            return this.Text;
        }

        public override string GetExtension()
        {
            return "txt";
        }

        public override void AddToActionHistory(string FullPath, string ActionLabel, bool Success)
        {
            PlainTextFile.ActionHistory.Add((FullPath, ActionLabel, Success));
        }

    }
}
