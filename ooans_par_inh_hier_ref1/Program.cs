using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ooans_par_inh_hier_ref1
{
    class Program
    {
        static void Main(string[] args)
        {
            FileSystem.GetInstance().AddFile("root/etc/passwords.txt", "zajac zajac\noma_de_sal annubis\nmaria unikatne_heslo\n");

            PlainTextFile TextFile = new PlainTextFile(new List<string>(new string[] { "root", "etc" }), "passwords");
            TextFile.ReadFile();

            Console.WriteLine(TextFile.ConstructFullPath());
            Console.WriteLine(TextFile.Name + ":");
            Console.WriteLine(TextFile.Text);
            Console.WriteLine("-----------------------");
            
            PlainTextFile CopiedTextFile = (PlainTextFile) TextFile.CopyFile(new List<string>(new string[] { "root", "hack" }), "stolen");
            Console.WriteLine(CopiedTextFile is PlainTextFile);

            Console.WriteLine(CopiedTextFile.ConstructFullPath());
            Console.WriteLine(CopiedTextFile.Name + ":");
            Console.WriteLine(CopiedTextFile.Text);
            Console.WriteLine("-----------------------");

            FileSystem.GetInstance().AddFile("root/music/drove_all_night.mp3", "43000 | 42 55 84 22 | 96 102 11 5 | 4 15 6 12");

            MP3File MP3File = new MP3File(new List<string>(new string[] { "root", "music" }), "drove_all_night");
            MP3File.ReadFile();

            Console.WriteLine(MP3File.ConstructFullPath());
            Console.WriteLine(MP3File.Name + ":");
            Console.WriteLine(MP3File.FileContentToString());
            Console.WriteLine("-----------------------");
            
            MP3File CopiedMP3File = (MP3File)MP3File.CopyFile(new List<string>(new string[] { "root", "music" }), "drove_all_day");
            
            Console.WriteLine(CopiedMP3File.ConstructFullPath());
            Console.WriteLine(CopiedMP3File.Name + ":");
            Console.WriteLine(CopiedMP3File.FileContentToString());
            Console.WriteLine("-----------------------");

            FileSystem.GetInstance().AddFile("root/xml/message.xml", "dajaky xml subor");
            
            XMLFile XMLFile = new XMLFile (new List<string>(new string[] { "root", "xml" }), "message");
            XMLFile.ReadFile();

            Console.WriteLine(XMLFile.ConstructFullPath());
            Console.WriteLine(XMLFile.Name + ":");
            Console.WriteLine(XMLFile.FileContentToString());
            Console.WriteLine("-----------------------");
            
            XMLFile CopiedXMLFile = (XMLFile)XMLFile.CopyFile(new List<string>(new string[] { "root", "xml" }), "message_copy");

            Console.WriteLine(CopiedXMLFile.ConstructFullPath());
            Console.WriteLine(CopiedXMLFile.Name + ":");
            Console.WriteLine(CopiedXMLFile.FileContentToString());
            Console.WriteLine("-----------------------");

            Console.ReadLine();
        }
    }
}
