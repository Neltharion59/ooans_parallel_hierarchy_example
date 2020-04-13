using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ooans_par_inh_hier
{
    class MP3File : File
    {
        private static int DefaultFrequency = 43000;
        public int Frequency { get; set; }
        public List<List<int>> Channels { get; set; }
        public MP3File(List<string> Path, string Name) : base(Path, Name)
        {
            this.Frequency = MP3File.DefaultFrequency;
            this.Channels = new List<List<int>>();
        }
        public override File CreateCopy(List<string> Path, string Name)
        {
            MP3File Copy = new MP3File(Path, Name);
            Copy.Frequency = this.Frequency;
            Copy.Channels = this.Channels.Select(channel => channel.ToList()).ToList();
            return Copy;
        }
    }
}
