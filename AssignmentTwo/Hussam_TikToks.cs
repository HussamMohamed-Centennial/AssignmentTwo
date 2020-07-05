using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.CompilerServices;


namespace AssignmentTwo
{
    class Hussam_TikToks
    {
        static void Main(string[] args)
        {
            Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++");
            Console.WriteLine("+  Printing all objects using show methods +");
            Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++");
            TikTokManger.Show();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
            Console.WriteLine("+  Printing all objects using show methods after adding 5 objects by using intializer method +");
            Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
            TikTokManger.Intializer();
            TikTokManger.Show();
            Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
            Console.WriteLine("Searching menu :  ");
            Console.WriteLine("1 to search by Tiktok HashTag.");
            Console.WriteLine("2 to search by Tiktok Length. ");
            Console.WriteLine("3 to search by Tiktok audiance ");
            Console.WriteLine("Please make a selection from the menu then enter your searching value ?");
            int firstInput = Convert.ToInt32(Console.ReadLine());
            if (firstInput == 1)
            {
                string userInput = Console.ReadLine();
                string updatedUserInput = userInput.ToUpper();
                TikTokManger.Show(updatedUserInput);
            }
            if (firstInput == 2)
            {
                int userInput = Convert.ToInt32(Console.ReadLine());
                TikTokManger.Show(userInput);
            }
            if (firstInput == 3)
            {
                Audience secondInput = (Audience)Enum.Parse(typeof(Audience), Console.ReadLine());
                TikTokManger.Show(secondInput);
            }
            Console.ReadLine();

        }

        public enum Audience
        {
            World,
            Group,
            Special
        }

        public class TikTok
        {
            private static int _ID ;

            public string Originator
            {
                get;
            }

            public int Length
            {
                get;
            }

            public string HashTag
            {
                get;
            }

            public Audience Audience
            {
                get;
            }

            public string ID
            {
                get;
            }

            public TikTok(string orginator, int length, string hashTag, Audience audience)
            {
                _ID++;
                Originator = orginator;
                Length = length;
                HashTag = hashTag;
                Audience = audience;
            }

            private TikTok(string id, string originator, string length, string hashTAg, string audiance)
            {
                _ID = int.Parse(id);
                Originator = originator;
                Length = Convert.ToInt32(length);
                HashTag = hashTAg;
                Audience = (Audience) Enum.Parse(typeof(Audience), audiance);
            }

            public override string ToString()
            {
                return
                    $"#{HashTag} is a TikTok made by: {Originator} with length of: {Length} second, and  the audiance is {Audience}";
            }

            public static TikTok Prase(string line)
            {
                string[] words = line.Split('\t');
                string org = words[0];
                int len = Convert.ToInt32(words[1]);
                string hash = words[2];
                Audience aud = (Audience) Enum.Parse(typeof(Audience), words[3]);
                TikTok tikTok= new TikTok(org, len, hash, aud);
                return tikTok;
            }
        }

        static class TikTokManger
        {
            private static List<TikTok> TIKTOKS;
            private static string FILENAME = "tikTok.txt";

            static TikTokManger()
            {
                TIKTOKS = new List<TikTok>();
                TextReader reader = new StreamReader(FILENAME);
                
                int linesCount = File.ReadAllLines(FILENAME).Length;
                for (int i = 0; i < linesCount; i++)
                {
                    string line = reader.ReadLine();
                    if (line != null)
                    {
                        TIKTOKS.Add(TikTok.Prase(line));
                    }

                }
            }

            public static void Intializer()
            {
                //TIKTOKS = new List<TikTok>();
                TikTok tiktok1 = new TikTok("Lora", 4, "Note10", Audience.World);
                TikTok tiktok2 = new TikTok("james", 29, "SunSet", Audience.Special);
                TikTok tikTok3 = new TikTok("Rogy",19,"Funny",Audience.Special);
                TikTok tikTok4 = new TikTok("Qusai",19,"Playstation",Audience.Group);
                TikTok tikTok5= new TikTok("Sara",28,"Centennial",Audience.World);
                TIKTOKS.Add(tiktok1);
                TIKTOKS.Add(tiktok2);
                TIKTOKS.Add(tikTok3);
                TIKTOKS.Add(tikTok4);
                TIKTOKS.Add(tikTok5);
            }

            public static void Show()
            {
                foreach (var tiktok in TIKTOKS)
                {
                    Console.WriteLine(tiktok.ToString());
                }
            }

            public static void Show(string tag)
            {
                foreach (var tiktok in TIKTOKS)
                {
                    if (tiktok.HashTag.ToUpper() == tag)
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
}

