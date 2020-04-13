using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ooans_par_inh_hier
{
    class MP3ReaderWriter : FileReaderWriter
    {
        public override bool AddFileContent(File File, string Content)
        {
            bool Success = ValidFileType(File);
            if (Success)
            {
                MP3File MP3File = (MP3File)File;

                string[] Channels = Content.Split('|');

                int Frequency;
                if (!int.TryParse(Regex.Replace(Channels[0], @"\s+", ""), out Frequency))
                {
                    return false;
                }

                MP3File.Frequency = Frequency;

                int TempValue;
                foreach (String Channel in Channels.Skip(1).ToArray())
                {
                    MP3File.Channels.Add(new List<int>());
                    String Temp = Channel.Trim();
                    String[] Tokens = Temp.Split(' ');
                    foreach (String Token in Tokens)
                    {
                        if (!int.TryParse(Regex.Replace(Token, @"\s+", ""), out TempValue))
                        {
                            return false;
                        }
                        MP3File.Channels.Last().Add(TempValue);
                    }
                }
            }
            return Success;
        }

        public override File ConstructFile(List<string> Path, string Name)
        {
            return new MP3File(Path, Name);
        }

        public override string FileContentToString(File File)
        {
            string Result = null;
            if (ValidFileType(File))
            {
                MP3File MP3File = (MP3File)File;
                Result = "";

                Result += MP3File.Frequency;

                foreach (List<int> Channel in MP3File.Channels)
                {
                    Result += " |";
                    foreach (int Value in Channel)
                    {
                        Result += " " + Value;
                    }
                }
            }
            return Result;
        }

        public override string GetExtension()
        {
            return "mp3";
        }

        public override bool ValidFileType(File File)
        {
            return File is MP3File;
        }
    }
}
