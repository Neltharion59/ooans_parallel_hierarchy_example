using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ooans_par_inh_hier_ref1
{
    abstract class File
    {
        public List<String> Path { get; }
        public String Name { get; }
        public File(List<String> Path, String Name)
        {
            this.Path = Path;
            this.Name = Name;
        }

        public abstract File CreateCopy(List<String> Path, String Name);
        public bool ReadFile()
        {
            String FullPath = ConstructFullPath();
            String Content = FileSystem.GetInstance().GetFileContent(FullPath);
            bool Success = false;
            if (Content != null)
            {
                Success = this.AddFileContent(Content);
            }
            AddToActionHistory(FullPath, "R", Success);
            return Success;
        }
        public File CopyFile(List<String> Path, String Name)
        {
            File Copy = this.CreateCopy(Path, Name);
            bool Success = FileSystem.GetInstance().AddFile(Copy.ConstructFullPath(), Copy.FileContentToString());
            return Success ? Copy : null;
        }
        public abstract void AddToActionHistory(String FullPath, String ActionLabel, bool Success);
        public abstract bool AddFileContent(String Content);
        public abstract bool ValidFileType(File File);
        public abstract String FileContentToString();
        public String ConstructFullPath()
        {
            String Result = "";
            foreach (String Node in this.Path)
            {
                Result += ("".Equals(Result) ? "" : "/") + Node;
            }
            Result += "/" + this.Name + "." + GetExtension();
            return Result;
        }
        public abstract String GetExtension();
    }
}
