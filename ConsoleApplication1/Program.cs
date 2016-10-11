using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Speech.Synthesis;
namespace ConsoleApplication1
{
    class Program
    {
        static string dir;
        static string file;
        static string path;


        static void Main(string[] args)
        {
            Teksteditor();
            Lees();

           // File.Delete(path);
        }

        static void Teksteditor()
        {
            dir = Directory.GetCurrentDirectory();
            file = "text.txt";
            path = Path.Combine(dir, file);
            StreamWriter writer = File.CreateText(path);
            string text;
            bool quit = false;
            while (!quit)
            {
                text = Console.ReadLine();
                if (text == "quit" | text == "q")
                {
                    quit = true;
                }
                else
                {
                    writer.WriteLine(text);
                }
                
            }

            writer.Close();

        }


        static void Lees()
        {
            StreamReader reader = new StreamReader(path);
            SpeechSynthesizer synth = new SpeechSynthesizer();
            var text = reader.ReadToEnd();
                Console.WriteLine(text);
            synth.Speak(text);
            reader.Close();
        }
    }
}