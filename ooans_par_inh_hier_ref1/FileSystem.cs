using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ooans_par_inh_hier_ref1
{
    class FileSystem
    {
        public Dictionary<String, String> Files { get; }
        private static FileSystem Instance= null;
        private FileSystem()
        {
            this.Files = new Dictionary<string, string>();
        }
        public static FileSystem GetInstance()
        {
            if (FileSystem.Instance == null)
            {
                FileSystem.Instance = new FileSystem();
            }

            return FileSystem.Instance;
        }
        public bool AddFile(String Name, String Content)
        {
            bool Success = !this.Files.ContainsKey(Name);
            if (Success)
            {
                this.Files[Name] = Content;
            }
            return Success;
        }
        public String GetFileContent(String Name)
        {
            String Result = null;
            if (this.Files.ContainsKey(Name))
            {
                Result = this.Files[Name];
            }
            return Result;
        }

        public void PrintState()
        {
            foreach (var item in this.Files)
            {
                Console.WriteLine("key:" + item.Key + "\n"  + item.Value);
            }
        }
    }
}
