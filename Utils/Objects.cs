//using HarmonyLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using UnityEngine;
using static ImageEffectManager;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;
using SevenDTDMono;
using System.Runtime.InteropServices;
using System.Collections;
//using HarmonyLib;

namespace SevenDTDMono
{
    public class Objects : MonoBehaviour
    {

        public static List<EntityZombie> zombieList;
        public static List<EntityEnemy> enemylist;
        public static List<EntityItem> itemList;

        public static EntityPlayerLocal ELP; // my final EntityPlayerLocal, This is the player on this pc
        public static EntityPlayerLocal _entityplayerLocal; // not sure why i have this one
        public static EntityPlayer _entityplayer;

        public static Entity entity;
        public static EntityEnemy entity1;
        public static GameObject Gobj;
        public static BuffManager buffManager = new BuffManager();
        public static GameManager _gameManager;
        public static XUiM_PlayerInventory _playerinv;

        private float lastCachePlayer;
        private float lastCacheZombies;
        private float lastCacheItems;

        public static List<BuffClass> buffClasses;
        public static BuffClass _buffClass;
        public static List<string> _BuffNames;
        private bool checkCompleted = false;



        private void Start()
        {
             

            lastCachePlayer = Time.time + 5f;
            lastCacheZombies = Time.time + 3f;
            lastCacheItems = Time.time + 4f;
            lastCacheItems = Time.time + 1000f;

            //_gameManager = new GameManager();
            zombieList = new List<EntityZombie>();
            enemylist = new List<EntityEnemy>();
            itemList = new List<EntityItem>();
            buffClasses = new List<BuffClass>();

           

            _entityplayerLocal = FindObjectOfType<EntityPlayerLocal>();
            _entityplayer = FindObjectOfType<EntityPlayer>();
            entity = FindObjectOfType<Entity>();

           //entity1.e

            Log.Out("End of start objects");
            Log.Out("End of start objects and _gameManger= " + _gameManager);

            //_gameManager.GetGameStateManager();
            //InvokeRepeating("CheckFunction", 0f, 60f);

        }

        IEnumerator CheckOncePerMinute()
        {

            while (!Settings.Istarted)
            {
                Log.Out("inside while");
                if (_gameManager == null)
                {
                    Log.Out("_gamemanager was null");
                    _gameManager = FindObjectOfType<GameManager>();
                    Log.Out($"Gamemanager {_gameManager} is now present");
                }
                
                else
                {
                    Log.Out("After else now _gameManger= " + _gameManager);
                    // Only perform the check if it hasn't been done already
                    if (_gameManager.gameStateManager.IsGameStarted()!=false)
                    {
                        Log.Out($"Debug World Isstarted? =  : " + Settings.Istarted);
                        Settings.Istarted = true;

                    }
                    else
                    {
                        // Conditions are not met, log the current status and wait for one minute before checking again
                        Log.Out($"Debug World Isstarted? =  : " + _gameManager.gameStateManager.IsGameStarted());
                        Log.Out($"Debug Settings.Istarted: {Settings.Istarted}");

                        // Wait for one minute before checking again
                        yield return new WaitForSeconds(60f);
                    }
                }                  
            }
        }

        private void Update()
        {
            /* 
             * Only a little bit of spaghetti : ^)
             * This is much more efficient than Coroutines are, which is why I'm using this spaghetti over them.
             * I could and should have made a helper util which lets you plug in an entity list and it will fetch it every x seconds,
             * but this will do just fine.
             */

            StartCoroutine(CheckOncePerMinute());



            if (ELP != null && Settings.reloadBuffs == true && buffClasses.Count == 0)
            {
                buffClasses = GetAvailableBuffClasses();
                Settings.reloadBuffs = false;
            }


            if (Time.time >= lastCachePlayer)
            {
                ELP = FindObjectOfType<EntityPlayerLocal>();
                lastCachePlayer = Time.time + 5f;
            }
            else if (Time.time >= lastCacheZombies)
            {
                zombieList = FindObjectsOfType<EntityZombie>().ToList();
                enemylist = FindObjectsOfType<EntityEnemy>().ToList();

                lastCacheZombies = Time.time + 3f;
            }
            else if (Time.time >= lastCacheItems)
            {
                itemList = FindObjectsOfType<EntityItem>().ToList();

                lastCacheItems = Time.time + 4f;
            }
        }



        public static List<EntityPlayer> PlayerList
        {
            get
            {
                if (GameManager.Instance != null)
                    if (GameManager.Instance.World != null)
                        return GameManager.Instance.World.GetPlayers();
                return new List<EntityPlayer>();
            }


        }

        public static List<string> GetAvailableBuffNames()
        {
            SortedDictionary<string, BuffClass> sortedDictionary = new SortedDictionary<string, BuffClass>(BuffManager.Buffs, StringComparer.OrdinalIgnoreCase);
            List<string> buffNames = new List<string>();

            foreach (KeyValuePair<string, BuffClass> keyValuePair in sortedDictionary)
            {
                if (keyValuePair.Key.Equals(keyValuePair.Value.LocalizedName))
                {
                    buffNames.Add(keyValuePair.Key);
                }
                else
                {
                    buffNames.Add(keyValuePair.Key);
                }

            }

            return buffNames;
        }
        public static List<BuffClass> GetAvailableBuffClasses()  // gets the buffclasses??
        {
            // Clear the list to ensure it's up-to-date.
            buffClasses.Clear();
            //buffClasses.
            if (BuffManager.Buffs != null)
            {

                BuffManager.Buffs.OfType<BuffClass>();
                foreach (var buffEntry in BuffManager.Buffs)
                {
                    //buffEntry.Value.Effects.EffectGroups.
                    buffClasses.Add(buffEntry.Value);

                    if (buffEntry.Value.Equals(BuffManager.Buffs.Last().Value))
                    {
                        // Do something specific for the last buff class (if needed)
                        // ...

                        // Stop the loop after adding the last buff class
                        //break;
                    }
                    LogBuffClassesToFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "load", "Test.txt"));

                }
            }
            buffClasses.Sort((buff1, buff2) => string.Compare(buff1.Name, buff2.Name));

            return buffClasses;
        }
        private static void LogBuffClassesToFile(string filePath)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.WriteLine("Buff Name,Damage Type,Description");

                    foreach (var buffClass in buffClasses)
                    {

                        string str1 = buffClass.DamageSource.ToString();
                        string str2 = buffClass.Effects.EffectGroups[0].ToString();


                        //writer.WriteLine($"{EscapeForCsv(buffClass.Name)},{buffClass.DamageType},{EscapeForCsv(buffClass.NameTag.ToString())}");
                        writer.WriteLine($"{EscapeForCsv(buffClass.Name)},,");
                    }
                }

                Console.WriteLine("Buff classes have been logged to the file.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while logging buff classes: {ex.Message}");
            }
        }

        private static string EscapeForCsv(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return string.Empty;
            }

            // If the value contains a comma or a double quote, enclose it in double quotes and escape any existing double quotes
            if (value.Contains(',') || value.Contains('"'))
            {
                return $"\"{value.Replace("\"", "\"\"")}\"";
            }

            return value;
        }


    }

}