using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ooans_par_inh_hier
{
    class Program
    {
        static void Main(string[] args)
        {
            FileSystem.GetInstance().AddFile("root/etc/passwords.txt", "nina 222\nalex heslo\nivan password123\n");

            PlainTextReaderWriter PlainTextRW = new PlainTextReaderWriter();
            PlainTextFile TextFile = (PlainTextFile) PlainTextRW.ReadFile(new List<string>(new string[] { "root", "etc"}), "passwords");

            Console.WriteLine(PlainTextRW.ConstructFullPath(TextFile.Path, TextFile.Name));
            Console.WriteLine(TextFile.Name + ":");
            Console.WriteLine(TextFile.Text);
            Console.WriteLine("-----------------------");

            PlainTextFile CopiedTextFile = (PlainTextFile)PlainTextRW.CopyFile(TextFile, new List<string>(new string[] { "root", "hacked" }), "stolen_passwords");

            Console.WriteLine(PlainTextRW.ConstructFullPath(CopiedTextFile.Path, CopiedTextFile.Name));
            Console.WriteLine(CopiedTextFile.Name + ":");
            Console.WriteLine(CopiedTextFile.Text);
            Console.WriteLine("-----------------------");

            FileSystem.GetInstance().AddFile("root/music/first_love.mp3", "43000 | 42 55 84 22 | 96 102 11 5 | 4 15 6 12");

            MP3ReaderWriter MP3RW = new MP3ReaderWriter();
            MP3File MP3File = (MP3File)MP3RW.ReadFile(new List<string>(new string[] { "root", "music" }), "first_love");

            Console.WriteLine(MP3RW.ConstructFullPath(MP3File.Path, MP3File.Name));
            Console.WriteLine(MP3File.Name + ":");
            Console.WriteLine(MP3RW.FileContentToString(MP3File));
            Console.WriteLine("-----------------------");

            MP3File CopiedMP3File = (MP3File)MP3RW.CopyFile(MP3File, new List<string>(new string[] { "root", "music" }), "second_love");
            
            Console.WriteLine(MP3RW.ConstructFullPath(CopiedMP3File.Path, CopiedMP3File.Name));
            Console.WriteLine(CopiedMP3File.Name + ":");
            Console.WriteLine(MP3RW.FileContentToString(CopiedMP3File));
            Console.WriteLine("-----------------------");

            FileSystem.GetInstance().AddFile("root/xml/message.xml", "dajaky xml subor");

            XMLFileReaderWriter XMLRW = new XMLFileReaderWriter();
            XMLFile XMLFile = (XMLFile)XMLRW.ReadFile(new List<string>(new string[] { "root", "xml" }), "message");

            Console.WriteLine(XMLRW.ConstructFullPath(XMLFile.Path, XMLFile.Name));
            Console.WriteLine(XMLFile.Name + ":");
            Console.WriteLine(XMLRW.FileContentToString(XMLFile));
            Console.WriteLine("-----------------------");

            XMLFile CopiedXMLFile = (XMLFile)XMLRW.CopyFile(XMLFile, new List<string>(new string[] { "root", "xml" }), "message_copy");

            Console.WriteLine(XMLRW.ConstructFullPath(CopiedXMLFile.Path, CopiedXMLFile.Name));
            Console.WriteLine(CopiedXMLFile.Name + ":");
            Console.WriteLine(XMLRW.FileContentToString(CopiedXMLFile));
            Console.WriteLine("-----------------------");

            Console.ReadLine();
        }
    }
}
