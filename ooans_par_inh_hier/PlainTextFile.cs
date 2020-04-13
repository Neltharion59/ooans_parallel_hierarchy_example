using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ooans_par_inh_hier
{
    class PlainTextFile : File
    {
        public String Text { get; set; }
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
    }
}
