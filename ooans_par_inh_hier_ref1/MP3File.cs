using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ooans_par_inh_hier_ref1
{
    class MP3File : File
    {
        private static int DefaultFrequency = 43000;
        public int Frequency { get; set; }
        public List<List<int>> Channels { get; set; }
        public static List<(String, String, bool)> ActionHistory { get; } = new List<(string, string, bool)>();
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
        public override void AddToActionHistory(string FullPath, string ActionLabel, bool Success)
        {
            MP3File.ActionHistory.Add((FullPath, ActionLabel, Success));
        }

        public override bool AddFileContent(string Content)
        {
            string[] Channels = Content.Split('|');

            int Frequency;
            if (!int.TryParse(Regex.Replace(Channels[0], @"\s+", ""), out Frequency))
            {
                return false;
            }

            this.Frequency = Frequency;

            int TempValue;
            foreach (String Channel in Channels.Skip(1).ToArray())
            {
                this.Channels.Add(new List<int>());
                String Temp = Channel.Trim();
                String[] Tokens = Temp.Split(' ');
                foreach (String Token in Tokens)
                {
                    if (!int.TryParse(Regex.Replace(Token, @"\s+", ""), out TempValue))
                    {
                        return false;
                    }
                    this.Channels.Last().Add(TempValue);
                }
            }
            return true;
        }

        public override bool ValidFileType(File File)
        {
            return File is MP3File;
        }

        public override string FileContentToString()
        {
            string Result = null;

            Result = "";

            Result += this.Frequency;

            foreach (List<int> Channel in this.Channels)
            {
                Result += " |";
                foreach (int Value in Channel)
                {
                    Result += " " + Value;
                }
            }

            return Result;
        }

        public override string GetExtension()
        {
            return "mp3";
        }
    }
}
