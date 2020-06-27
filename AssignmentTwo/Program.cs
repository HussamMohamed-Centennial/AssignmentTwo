using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AssignmentTwo
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    enum Audience
    {
        World,
        Group,
        Special
    }

    class TikTok
    {
        private int _ID;

        public string Originator { get; }

        public int Length { get; }

        public string HashTag { get; }

        public Audience Audience { get; }

        public string ID { get; }

        public TikTok(string orginator, int length, string hashTag, Audience audience)
        {
            Originator = orginator;
            Length = length;
            HashTag = hashTag;
            Audience = audience;
        }

        private TikTok(string id, string originator, string length, string hashTAg, string audiance)
        {
            ID = id;
            Originator = originator;
            Length = Convert.ToInt32(originator);
            HashTag = hashTAg;
            Audience = (Audience) Enum.Parse(typeof(Audience), audiance);
        }

        public override string ToString()
        {
            return
                $"the orginator is: {Originator}, the length is: {Length} and # {HashTag} the audiance is {Audience} and id is {ID}";
        }

        public static TikTok Prase(string line)
        {
            string[] words = line.Split('\t');
            TikTok tikTok = new TikTok(words[0], words[1], words[2], words[3], words[4]);
            return tikTok;
        }
    }

    static class TikTokManger
    {
        private static List<TikTok> TIKTOKS;
        private static string FILENAME;

        static TikTokManger()
        {
            int numberLinesOfFile;

            numberLinesOfFile = File.ReadAllLines(FILENAME).Length;

            TIKTOKS = new List<TikTok>();

            FileStream fileStream = new FileStream(FILENAME, FileMode.Open, FileAccess.Read);
            StreamReader streamReader = new StreamReader(fileStream);

            for (int i = 0; i < numberLinesOfFile; i++)
            {

                string line = streamReader.ReadLine();
                if (line != null)
                {
                    TIKTOKS[i] = TikTok.Prase(line);
                }
            }

            streamReader.Close();
            fileStream.Close();
        }

        public static void Intializer()
        {
            TikTok tiktoks1= new TikTok("Canada",4,"SamTest",Audience.Group);
            TikTok tiktoks2 = new TikTok("USA", 5, "Sam", Audience.Group);
        }

        public static void Show()
        {
            foreach (var tiktok in TIKTOKS)
            {
                Console.WriteLine(tiktok);
            }
        }

        public static void Show(string tag)
        {
            foreach (var tiktok in TIKTOKS)
            {
                if (tiktok.HashTag == tag)
                {
                    Console.WriteLine(tiktok);
                }
            }
        }

        public static void Show(int length)
        {
            foreach (var tiktok in TIKTOKS)
            {
                if (tiktok.Length == length)
                {
                    Console.WriteLine(tiktok);
                }
            }
        }

        public static void Show(Audience audience)
        {
            foreach (var tiktok in TIKTOKS)
            {
                if (tiktok.Audience == audience)
                {
                    Console.WriteLine(tiktok);
                }
            }
        }



    }
}

