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
    
    
















    }  
}
