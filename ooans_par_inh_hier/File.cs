using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ooans_par_inh_hier
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

    }
}
