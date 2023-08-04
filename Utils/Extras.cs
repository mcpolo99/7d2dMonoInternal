using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenDTDMono.Utils
{
    internal class Extras
    {
        private static Random random = new Random();
        private const string ExtraChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        public static void LogAvailableBuffNames(string filePath)
        {
            SortedDictionary<string, BuffClass> sortedDictionary1 = new SortedDictionary<string, BuffClass>(BuffManager.Buffs, StringComparer.OrdinalIgnoreCase);
            try 
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.WriteLine("Buff Name,Damage Type,Description");

                    foreach (KeyValuePair<string, BuffClass> keyValuePair in sortedDictionary1)
                    {
                        if (keyValuePair.Key.Equals(keyValuePair.Value.LocalizedName))
                        {

                            //SingletonMonoBehaviour<SdtdConsole>.Instance.Output(" - " + keyValuePair.Key);

                            writer.WriteLine($"{keyValuePair.Key}");
                        }
                        else
                        {
                            writer.WriteLine($"{keyValuePair.Key} ({keyValuePair.Value.LocalizedName})");
                            /*
                            //SingletonMonoBehaviour<SdtdConsole>.Instance.Output(string.Concat(new string[]
                            //{
                            //    " - ",
                            //    keyValuePair.Key,
                            //    " (",
                            //    keyValuePair.Value.LocalizedName,
                            //    ")"
                            //}));
                            */

                        }
                    }

                }

                } catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while logging buff classes: {ex.Message}");
            }



            /*/SortedDictionary<string, BuffClass> sortedDictionary = new SortedDictionary<string, BuffClass>(BuffManager.Buffs, StringComparer.OrdinalIgnoreCase);
            //SingletonMonoBehaviour<SdtdConsole>.Instance.Output("Available buffs:");
            //foreach (KeyValuePair<string, BuffClass> keyValuePair in sortedDictionary)
            //{
            //    if (keyValuePair.Key.Equals(keyValuePair.Value.LocalizedName))
            //    {
            //        SingletonMonoBehaviour<SdtdConsole>.Instance.Output(" - " + keyValuePair.Key);
            //    }
            //    else
            //    {
            //        SingletonMonoBehaviour<SdtdConsole>.Instance.Output(string.Concat(new string[]
            //        {
            //        " - ",
            //        keyValuePair.Key,
            //        " (",
            //        keyValuePair.Value.LocalizedName,
            //        ")"
            //        }));
            //    }
            //}
            */

        }





        public static string ScrambleString(string input)
        {
            // Convert the input string to a character array
            char[] charArray = input.ToCharArray();

            // Shuffle the characters randomly
            for (int i = charArray.Length - 1; i > 0; i--)
            {
                int randomIndex = random.Next(0, i + 1);
                char temp = charArray[i];
                charArray[i] = charArray[randomIndex];
                charArray[randomIndex] = temp;
            }

            // Add a few extra random characters to the scrambled string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < charArray.Length; i++)
            {
                sb.Append(charArray[i]);
                if (random.Next(0, 4) == 0) // 25% chance of adding an extra character
                {
                    char extraChar = ExtraChars[random.Next(0, ExtraChars.Length)];
                    sb.Append(extraChar);
                }
            }

            // Convert the StringBuilder to a string and return it
            return sb.ToString();
        }
















    }  
}
