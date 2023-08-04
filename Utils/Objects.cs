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
        public static List<ProgressionValue> Proglist;
        
        public static List<EntityItem> itemList;

        public static EntityTrader Etrader;
        public static EntityPlayerLocal ELP; // my final EntityPlayerLocal, This is the player on this pc
        public static EntityPlayerLocal _entityplayerLocal; // not sure why i have this one
        public static EntityPlayer _entityplayer;
        
        
        public static MinEffectController _minEffectController;
        public static MinEffectController _minEC;
        public static BuffClass CheatBuff;
        public static PassiveEffects passiveEffects;


        public static Entity entity;
        public static EntityEnemy entity1;
        public static GameObject Gobj;
        public static BuffManager buffManager;
        public static GameManager _gameManager;
        public static XUiM_PlayerInventory _playerinv;

        private float lastCachePlayer;
        private float lastCacheZombies;
        private float lastCacheItems;
        private float Cachestart;

        public static List<BuffClass> buffClasses;
        public static Dictionary<string, BuffClass>.KeyCollection buffsDict;
        public static BuffClass _buffClass;
        public static List<string> _BuffNames;
        private bool checkCompleted = false;





        private float updateCount = 0;
        private float fixedUpdateCount = 0;
        private float updateUpdateCountPerSecond;
        private float updateFixedUpdateCountPerSecond;


        //progression Value


        private void Start() //everything in here is things that need to declared at once on startup and not again. IF injecting ingame more ingame dependet vars can be here
        {

            GameObject uiRootObj1 = UnityEngine.Object.FindObjectOfType<UIPanel>().gameObject;
            //on tik = 1 sek
            //update freq for cahching diffrent classes/objects
            lastCachePlayer = Time.time + 5f;
            lastCacheZombies = Time.time + 3f;
            lastCacheItems = Time.time + 4f;
            lastCacheItems = Time.time + 1000f;
            Cachestart = Time.time + 10f; //time now + 10 sec


            //init the lists just empty ones. will populate later
            zombieList = new List<EntityZombie>();
            enemylist = new List<EntityEnemy>();
            Proglist = new List<ProgressionValue>();
            itemList = new List<EntityItem>();
            buffClasses = new List<BuffClass>();


             _gameManager = FindObjectOfType<GameManager>(); //gamemanager is present at alltimes, get it
            _minEffectController = new MinEffectController(); // we create our own effect controller for our own buffs and stats appliance
            _minEC = new MinEffectController(); // we create our own effect controller for our own buffs and stats appliance
            _minEC.EffectGroups = _minEffectController.EffectGroups;
            _minEC.PassivesIndex = _minEffectController.PassivesIndex;



            //Buffmanager is empty at startscreen, need to init after game start

            //BuffClass ReBuff = BuffManager.GetBuff("test");
            //Log.Out($"buff {ReBuff.Name} has been loaded as testbuff");
            ////customBuff;

            //if (customBuff != null) 
            //{
            //    int count = BuffManager.Buffs.Count;
            //    Log.Out($"amount of buffs now {count}");
            //    Log.Out("custombuff Has been init");

            //    initbuff();
            //    Log.Out($"amount of buffs after init {count}");
            //}
            //else
            //{

            //    Log.Out("custombuff Has Not been init");

            //}



            Log.Out("End of start objects");
            Log.Out("End of start objects and _gameManger= " + _gameManager);


           
;
            Debug.LogWarning("THIS IS Start!!!!");
        }

        private void initbuff() //default 366 buffs
        {
            

            CheatBuff.Name = "CheatBuff";
            CheatBuff.DamageType = EnumDamageTypes.None; // Set the appropriate damage type if applicable
            CheatBuff.Description = $"This is a {CheatBuff.Name}";
            CheatBuff.DurationMax = 99999999f;
            CheatBuff.Icon = "ui_game_symbol_agility";
            CheatBuff.ShowOnHUD = true;
            CheatBuff.Hidden = false;
            CheatBuff.IconColor = new Color(0.22f, 0.4f, 1f, 100f);
            CheatBuff.DisplayType = EnumEntityUINotificationDisplayMode.IconOnly;
            CheatBuff.LocalizedName = "CheatBuff Delux";
            CheatBuff.Description = "This is the buff that manages all modiefer values we add to the player,\n for every passive effect we adding we adding it to thsi Buffclass to avoid crashes and nullreferences \n " +
                "Also to avoid not being able to edit future values easier. \n i have not yet figured out how i can make the slider modifers realtime modifers or how to avoid passiveffects stacking  ";
            CheatBuff.Effects = _minEffectController;
            BuffManager.Buffs.Add(CheatBuff.Name, CheatBuff);  // need to add to buffmanager before init Everything before adding to buffmanager is what will define the buff
            buffClasses.Add(CheatBuff);// add the buffs to our own list,  Want to make a list with the descriptive name , buff
            Debug.LogWarning($"Buff {CheatBuff.Name} has ben added to {buffClasses} ");
            Log.Out($"{CheatBuff.Name} Has been initieted");

           
           _minEffectController.EffectGroups = new List<MinEffectGroup>
           {
               new MinEffectGroup
               {
                   OwnerTiered = true,
                   PassiveEffects = new List<PassiveEffect> 
                   {
                         new PassiveEffect
                            {
                                MatchAnyTags = true,
                                Type = PassiveEffects.None,
                                Modifier = PassiveEffect.ValueModifierTypes.base_add,
                                Values = new float[] { 20}
                                //Set other properties of PassiveEffect if needed
                            }
                   },
                   PassivesIndex = new List<PassiveEffects>
                       {
                            PassiveEffects.None,
                       }
               }

           };
           _minEffectController.PassivesIndex = new HashSet<PassiveEffects> 
           {
                   PassiveEffects.None,
           };
           buffsDict = BuffManager.Buffs.Keys;
           Logtxt();

           /*
           // Set the properties of the custom buff



           /*


           MinEffectController effectController = new MinEffectController 
           { 
               EffectGroups = new List<MinEffectGroup>
               {
                   new MinEffectGroup
                   {
                       OwnerTiered = true,
                       PassiveEffects = new List<PassiveEffect>
                       {
                            new PassiveEffect
                            {
                                MatchAnyTags = true,
                                Type = PassiveEffects.WalkSpeed,
                                Modifier = PassiveEffect.ValueModifierTypes.base_add,
                                Values = new float[] { RunSlider }
                                //Set other properties of PassiveEffect if needed
                            },
                           new PassiveEffect
                           {
                               // Set the properties of the PassiveEffect instance accordingly
                                MatchAnyTags = true,
                                Modifier = PassiveEffect.ValueModifierTypes.base_add,
                                Type = PassiveEffects.RunSpeed,
                                Values = new float[] { WalkSlider },

                                //Set other properties if needed
                           },
                           new PassiveEffect
                           {
                               // Set the properties of the PassiveEffect instance accordingly
                                MatchAnyTags = true,
                                Modifier = PassiveEffect.ValueModifierTypes.base_add,
                                Type = PassiveEffects.BlockDamage,
                                Values = new float[] { BlockDMGSlider },
                                //Set other properties if needed
                           },
                           new PassiveEffect
                           {
                               // Set the properties of the PassiveEffect instance accordingly
                                MatchAnyTags = true,
                                Modifier = PassiveEffect.ValueModifierTypes.base_add,
                                Type = PassiveEffects.CraftingTime,
                                Values = new float[] { 0 },
                                //Set other properties if needed
                           },
                           new PassiveEffect
                           {
                               // Set the properties of the PassiveEffect instance accordingly
                                MatchAnyTags = true,
                                Modifier = PassiveEffect.ValueModifierTypes.base_add,
                                Type = PassiveEffects.FoodGain,
                                Values = new float[] { 9999 },
                                //Set other properties if needed
                           }
                       },

                       PassivesIndex = new List<PassiveEffects>
                       {
                            PassiveEffects.WalkSpeed,
                            PassiveEffects.BlockDamage,
                            PassiveEffects.CraftingTime,
                            PassiveEffects.FoodGain,
                       }

                   }
               },
               PassivesIndex = new HashSet<PassiveEffects>
               {
                   PassiveEffects.WalkSpeed,
                   PassiveEffects.RunSpeed,
                   PassiveEffects.BlockDamage,
                   PassiveEffects.CraftingTime,
                   PassiveEffects.FoodGain,
               }
           };

           */

        }

        void Update()
        {
            updateCount += 1; //
            if (Settings.IsGameStarted == true && Settings.IsVarsLoaded != true)
            {
                try //add CheatBuff To the palyer
                {
                    if (Settings.IsGameStarted == true && Settings.IsVarsLoaded != true)
                    {
                        try
                        {
                            #region Cheatbuff
                            Debug.LogWarning($"amount of buffs now1 {BuffManager.Buffs.Count}");
                            //init our stuff now
                            if (BuffManager.GetBuff("testbuff") != null && BuffManager.GetBuff("ReBuff") != null)
                            {
                                BuffClass ReBuff = BuffManager.GetBuff("testbuff");
                                ReBuff.Name = "TESTEDITBUFF";
                                ReBuff.Effects = _minEffectController;
                                BuffManager.Buffs.Add(ReBuff.Name, ReBuff);

                                Debug.LogWarning($"buff {ReBuff.Name} has been loaded as a copy of  testbuff");
                            }

                            if (CheatBuff == null)
                            {
                                CheatBuff = new BuffClass();
                                Debug.Log($"{CheatBuff} as been init as a BuffClass() ");
                            }


                            if (CheatBuff != null)
                            {
                                int count = BuffManager.Buffs.Count;
                                Debug.LogWarning($"amount of buffs now2 {count}");
                                Log.Out($"{CheatBuff.Name} Has been init");
                                /*
                                if (BuffManager.GetBuff(CheatBuff.Name) != null)
                                {
                                    BuffClass ReBuff = BuffManager.GetBuff("testbuff");
                                    ReBuff.Name = "TESTEDITBUFF";
                                    Log.Out($"buff {ReBuff.Name} has been loaded as testbuff");
                                }

                                */
                                initbuff();

                                int count2 = BuffManager.Buffs.Count;
                                Debug.LogWarning($"amount of buffs after init {count2}");
                            }
                            else
                            {
                                Log.Out("custombuff Has Not been init");
                            }

                            #endregion
                            #region Buffclasses
                            //buffClasses.Clear();
                            ////buffClasses.
                            //if (BuffManager.Buffs != null)
                            //{

                            //    BuffManager.Buffs.OfType<BuffClass>();
                            //    foreach (var buffEntry in BuffManager.Buffs)
                            //    {
                            //        //buffEntry.Value.Effects.EffectGroups.
                            //        buffClasses.Add(buffEntry.Value);

                            //        if (buffEntry.Value.Equals(BuffManager.Buffs.Last().Value))
                            //        {
                            //            // Do something specific for the last buff class (if needed)
                            //            // ...

                            //            // Stop the loop after adding the last buff class
                            //            //break;
                            //        }
                            //        LogBuffClassesToFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "load", "Test.txt"));

                            //    }
                            //}

                            Log.Out("Reloading buffs");
                            foreach (var buffClass in BuffManager.Buffs)
                            {
                                buffClasses.Add(buffClass.Value);
                            }
                            buffClasses.Sort((buff1, buff2) => string.Compare(buff1.Name, buff2.Name));
                            LogBuffClassesToFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "load", "Test.txt"));
                            #endregion
                            Log.Out("CBuff Start to inject...");

                            string resourceName = "SevenDTDMono.Features.Buffs.Cbuffs.XML";

                            //Log.Out(resourceName);

                            CBuffs.LoadCustomXml(resourceName);
                            Debug.LogWarning($"{resourceName} was hopefully loaded, nothing more to load");


                            Settings.IsVarsLoaded = true; // setts the loaded var to true so this part of the code wont execute more
                        }
                        catch (Exception ex)
                        {
                            Debug.LogError($"An error occured1 = {ex}");
                            Settings.IsVarsLoaded = true;
                        }
                    }
                    else if (Settings.IsGameStarted != true && Settings.IsVarsLoaded == true)
                    {

                        Settings.IsGameStarted = false;
                    }
                    Debug.LogWarning($"hopefully WAS everything loaded, nothing more to load");


                }
                catch (Exception ex)
                {
                    Debug.LogWarning($"Error loading!! Check the code");
                    Debug.LogError($"An error occured2 = {ex}");

                }

            }
            /*
            if (!Settings.Istarted)
            {
                //Log.Out($"{Time.time}");
                if (Time.time >= Cachestart)
                {
                    Log.Out($"Setting = {Settings.Istarted} chache= {Cachestart}  Time = {Time.time}");

                    //Log.Out("inside while");
                    if (_gameManager == null) //  if We dont have a gammanger lets init it
                    {
                        //Log.Out("_gamemanager was null");
                        _gameManager = FindObjectOfType<GameManager>();
                        //Log.Out($"Gamemanager {_gameManager} is now present");
                    }

                    else
                    {
                        Log.Out("After else now _gameManger= " + _gameManager);
                        // Only perform the check if it hasn't been done already
                        if (_gameManager.gameStateManager.IsGameStarted() != false)
                        {
                            Log.Out($"Debug World Isstarted? =  : " + Settings.Istarted);
                            Settings.Istarted = true; //sets our bool to true

                        }
                        else
                        {
                            // Conditions are not met, log the current status and wait for one minute before checking again
                            Log.Out($"Debug World Isstarted? =  : " + _gameManager.gameStateManager.IsGameStarted());
                            Log.Out($"Debug Settings.Istarted: {Settings.Istarted}");

                            // Wait for one minute before checking again
                            //yield return new WaitForSeconds(60f);
                        }
                    }

                    Log.Out($"Setting = {Settings.Istarted} Ticknow = {Time.time} oldchache= {Cachestart}");
                    Cachestart = Time.time + 10f;
                    Log.Out($"Setting = {Settings.Istarted} Ticknow = {Time.time} Newchache= {Cachestart}");
                    if (Settings.Istarted==true) 
                    { 
                        Cachestart= Time.time+120; // 2 minutes
                    }
                }
            }
            */


            //add a check to check if gamemanager is init or not to prevent errors

            if (ELP != null && Settings.reloadBuffs == true && buffClasses.Count <= 1)
            {

                Log.Out("Reloading buffs");
                foreach (var buffClass in BuffManager.Buffs)
                {
                    buffClasses.Add(buffClass.Value);
                } 
                //buffClasses = GetAvailableBuffClasses();
                Settings.reloadBuffs = false;
            }


            if (Time.time >= lastCachePlayer)
            {
                ELP = FindObjectOfType<EntityPlayerLocal>();
                Etrader = FindObjectOfType<EntityTrader>();

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
        // Increase the number of calls to FixedUpdate.
        void FixedUpdate()
        {
            fixedUpdateCount += 1;
            //we need for some classes the game to be startet so we get it from gamemanager
            if (_gameManager.gameStateManager.IsGameStarted() == true && Settings.IsGameStarted != true) // needs to be true && need sto be false
            {
                Log.Out($"Debug World Isstarted=  : " + Settings.IsGameStarted, LogType.Error);
                Settings.IsGameStarted = true;
            }

            //Log.Out("THIS IS  FixedUpdate!!!!", LogType.Error);
        }

        IEnumerator CheckOncePerMinute()//old updateloop
        {
            //when game is not started 
            while (!Settings.IsGameStarted) //if not true
            {
                yield return new WaitForSeconds(60f);
                if (Time.time >= Cachestart)
                {

                    //Log.Out("inside while");
                    if (_gameManager == null)
                    {
                        //Log.Out("_gamemanager was null");
                        _gameManager = FindObjectOfType<GameManager>();
                        //Log.Out($"Gamemanager {_gameManager} is now present");
                    }

                    else
                    {
                        Log.Out("After else now _gameManger= " + _gameManager);
                        // Only perform the check if it hasn't been done already
                        if (_gameManager.gameStateManager.IsGameStarted() != false)
                        {
                            Log.Out($"Debug World Isstarted? =  : " + Settings.IsGameStarted);
                            Settings.IsGameStarted = true;

                        }
                        else
                        {
                            // Conditions are not met, log the current status and wait for one minute before checking again
                            Log.Out($"Debug World Isstarted? =  : " + _gameManager.gameStateManager.IsGameStarted());
                            Log.Out($"Debug Settings.Istarted: {Settings.IsGameStarted}");

                            // Wait for one minute before checking again
                            
                        }
                    }

                    Cachestart = Time.time + 2000f;
                    Log.Out(Cachestart.ToString());
                }
          
            }
        }
        IEnumerator Loop()
        {
            while (true)
            {
                yield return new WaitForSeconds(1);
                updateUpdateCountPerSecond = updateCount;
                updateFixedUpdateCountPerSecond = fixedUpdateCount;

                updateCount = 0;
                fixedUpdateCount = 0;
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

        private void Logtxt()
        {
            
            foreach (var str in buffsDict )
            {

                LogBuffClassesToFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "load", "buffsDict.txt"));

            }

        }
        public static List<BuffClass> GetAvailableBuffClasses() // gets the buffclasses??
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

        void Awake()
        {

            // Uncommenting this will cause framerate to drop to 10 frames per second.
            // This will mean that FixedUpdate is called more often than Update.
            //Application.targetFrameRate = 10;

            //init our updateloop
            StartCoroutine(Loop());
            Debug.LogWarning("THIS IS Awake!!!!");
        }
        void OnGUI()
        {
            //display update times
            GUIStyle fontSize = new GUIStyle(GUI.skin.GetStyle("label"));
            fontSize.fontSize = 15;
            fontSize.normal.textColor = Color.green;
            GUI.Label(new Rect(10, 50, 200, 50), "Update(FPS): " + updateUpdateCountPerSecond.ToString(), fontSize);
            GUI.Label(new Rect(10, 70, 200, 50), "FixedUpdate: " + updateFixedUpdateCountPerSecond.ToString(), fontSize);
        }
        void OnDisable()
        {
            Debug.LogWarning("THIS IS ON Disable!!!!");
        }
        void OnEnable()
        {
            Debug.LogWarning("THIS IS ON Enable!!!!");
        }
        void OnDestroy()
        {
            Debug.LogWarning("THIS IS ON DESTROY!!!!");
        }
        void OnDisconnectedFromServer()
        {
            Debug.LogWarning("THIS IS  OnDisconnectedFromServer!!!!");
        }
    }

}