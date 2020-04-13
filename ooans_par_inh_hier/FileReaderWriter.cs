using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ooans_par_inh_hier
{
    abstract class FileReaderWriter
    {
        public List<(String, String, bool)> ActionHistory { get; }
        public FileReaderWriter()
        {
            this.ActionHistory = new List<(String, String, bool)>();
        }
        public File ReadFile(List<String> Path, String Name)
        {
            File File = ConstructFile(Path, Name);
            String FullPath = ConstructFullPath(Path, Name);
            String Content = FileSystem.GetInstance().GetFileContent(FullPath);
            bool Success = false;
            if (Content != null)
            {
                Success = this.AddFileContent(File, Content);
            } 
            this.ActionHistory.Add((
                FullPath,
                "R",
                Success
            ));
            if (!Success)
            {
                File = null;
            }
            return File;
        }
        public File CopyFile(File File, List<String> Path, String Name)
        {
            File Copy = null;
            bool Success = ValidFileType(File);
            if (Success)
            {
                Copy = File.CreateCopy(Path, Name);
                Success = FileSystem.GetInstance().AddFile(ConstructFullPath(Path, Name), FileContentToString(Copy));
            }
            return Success ? Copy : null;
        }
        public abstract File ConstructFile(List<String> Path, String Name);
        public abstract bool AddFileContent(File File, String Content);
        public abstract bool ValidFileType(File File);
        public abstract String FileContentToString(File File);
        public String ConstructFullPath(List<String> Path, String Name)
        {
            String Result = "";
            foreach (String Node in Path)
            {
                Result += ("".Equals(Result) ? "" : "/") + Node;
            }
            Result += "/" + Name + "." + GetExtension();
            return Result;
        }
        public abstract String GetExtension();
    }
}
