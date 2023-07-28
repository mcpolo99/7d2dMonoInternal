using System;
using System.Runtime.InteropServices;
using UnityEngine;
using SETT = SevenDTDMono.Settings;
using Eutl = SevenDTDMono.ESPUtils;
using O = SevenDTDMono.Objects;
using System.Collections.Generic;
using Platform;
using System.Linq;

using System.IO;

using System.Reflection;
using UnityEngine.UIElements;
using HarmonyLib;
using SevenDTDMono.Interface;
using UnityEngine.UI;
using SevenDTDMono.Utils;
using System.Web;
using static PassiveEffect;

//using SevenDTDMono.Objects;


namespace SevenDTDMono
{
    public class Cheat : MonoBehaviour
    {

     


        #region Unity
        /*
        ----------------------------------- MonoBehaviour Methods:
        Awake()
        Start()
        Update()
        FixedUpdate()
        LateUpdate()
        OnGUI() (not recommended for modern UI)
        OnDisable()
        OnEnable()
        OnDestroy()
        ----------------------------------- Collision and Trigger Events:
        OnCollisionEnter()
        OnCollisionStay()
        OnCollisionExit()
        OnTriggerEnter()
        OnTriggerStay()
        OnTriggerExit()
        Input Handling:
        OnMouseOver()
        OnMouseEnter()
        OnMouseExit()
        OnMouseDown()
        OnMouseUp()
        OnMouseDrag()
        OnMouseUpAsButton()
        OnBecameVisible()
        OnBecameInvisible()
        ----------------------------------- Physics:
        OnJointBreak()
        OnParticleCollision()
        ----------------------------------- Audio:
        OnAudioFilterRead()
        ----------------------------------- Animation:
        OnAnimatorMove()
        OnAnimatorIK()
        ----------------------------------- Application Lifecycle:
        OnApplicationFocus()
        OnApplicationPause()
        OnApplicationQuit()
        ----------------------------------- Network:
        OnServerInitialized()
        OnConnectedToServer()
        OnDisconnectedFromServer()
        OnFailedToConnect()
        OnPlayerConnected()
        OnPlayerDisconnected()
         */
        #endregion
        //--------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------
        #region Notes
        /*

  
        entityalive

        EnumDamageTypes
        EnumDamageSource
        public static readonly DamageSource suffocating = new DamageSource(EnumDamageSource.Internal, EnumDamageTypes.Suffocation);
        this.DamageEntity(DamageSource.suffocating, 1, false, 1f);
        JetpackActive




        */
        //--------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------
        #endregion
        //--------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------
        #region variables
        public static Color _col = Color.blue;
        public static Stat.StatTypes StatType;

        public static Block block;
        public static BlockDamage blockDamage;
        public static ItemActionAttack attack;
        //public static PassiveEffect passiveEffect;
        public  static string inputPassiveEffects = "none";
        public  static string inputFloat = "1";
        private static Dictionary<string, bool> zombieToggleStates = new Dictionary<string, bool>();
        private static Dictionary<PassiveEffects, bool> passiveToggleStates = new Dictionary<PassiveEffects, bool>();

        private static List<string> ListPerksAlwaysAdd = new List<string>
        { "buffringoffire",
            "buffdontbreakmyleg",
            "buffheadshotsonly",
            "buffcrouching",
            "buffhealwatermax",
            "buffhealfood",
            "buffhealhealt"

        };
        private static List<string> ListPerks = new List<string> { "god", "megadamage", "nerfme", "messmeup" };
        private static List<string> ListPerksNotToAdd = new List<string> { "god", "megadamage", "nerfme", "messmeup", "buffbrokenlimbstatus", "buffneardeathtrauma" };
        private static List<string> ListPerksAlwaysremove = new List<string>
        {

            "buffdontmove",
            "buffelementwet",
            "electricity",
            "messmeup" ,
            "buffbrokenlimbstatus" ,
            "bufflegsprained",
            "buffinjuryabrasion" ,
            "bufflaceration",
            "buffinfectionmain",
            "nerfme",
            "megadamage",
            "god",
            "buffelementcold",






        };
        private static List<string> perkstarts = new List<string> { "twitch", "test_", "trigger", "infection", "injury", "getsworse" };




        #endregion
        //--------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------


        #region finished cheats
        //toggle
        public static void CmDm() //Creative and DEbug - Toggle
        {
            GameStats.Set(EnumGameStats.ShowSpawnWindow, SETT.CmDm); // sets the GameStat to the value of CmDm
            GameStats.Set(EnumGameStats.IsCreativeMenuEnabled, SETT.CmDm);
            GamePrefs.Set(EnumGamePrefs.DebugMenuEnabled, SETT.CmDm);
        }


        //Trigger
        public static void skillpoints()//add skillpoints - Trigger once
        {
            if (O.ELP)
            {
                Progression prog = O.ELP.Progression;
                prog.SkillPoints += 10;
                Log.Out($"Skillpoints added by 10is now {prog.SkillPoints}");
            }
        }
        public static void KillSelf()
        {

            O.ELP.DamageEntity(new DamageSource(EnumDamageSource.Internal, EnumDamageTypes.Suicide), 99999, false, 1f);
            SingletonMonoBehaviour<SdtdConsole>.Instance.Output("Gave 99999 damage to entity ");
        }
        public static void levelup()//up one level-Trigger once
        {
            if (O.ELP)
            {
                Progression prog = O.ELP.Progression;
                prog.AddLevelExp(prog.ExpToNextLevel);

            }
        }
        public static void Getplayer()//add skillpoints - Trigger once
        {
            string num = O.ELP.name.ToString();
            Log.Out("player ID: " + num);
        }

        


        #endregion


        public void OnHud()
        {

        }
        //--------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------
        private void Start()
        {
        }
        //--------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------ss
        //--------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------
        #region onUpdate
        private void Update()
        {

            if (SETT.noWeaponBob && O.ELP) // When noWeaponBob is active enable 
            {
                vp_FPWeapon weapon = O.ELP.vp_FPWeapon;

                if (weapon)
                {
                    weapon.BobRate = Vector4.zero;
                    weapon.ShakeAmplitude = Vector3.zero;
                    weapon.RenderingFieldOfView = 120f;
                    weapon.StepForceScale = 0f;
                }
            }//no weapon bob

            if (Input.GetKeyDown(KeyCode.O)) //infinity ammo ???
            {
                if (!O.ELP)
                {
                    return;
                }

                Inventory inventory = O.ELP.inventory;

                if (inventory != null)
                {
                    ItemActionAttack gun = inventory.GetHoldingGun();

                    if (gun != null)
                    {
                        gun.InfiniteAmmo = !gun.InfiniteAmmo;
                    }
                }
            }//infinity ammo

            if (Input.GetKeyDown(KeyCode.Keypad5)) //checks if the key is being pressed. if it does execute
            {
            }




            if (SETT.CmDm || !SETT.CmDm) //Toggle for ingame Creative and Debug Working like a sharm
            {
                CmDm();
            }
            if (SETT._oneHitBlock || !SETT._oneHitBlock ) //Toggle for ingame Creative and Debug Working like a sharm
            {
                onehitBlock();
            }
            if (SETT._oneHitKill == true) //Toggle for ingame Creative and Debug Working like a sharm
            {
                onehitKill();
            }
            if (SETT.speed)
            {
                SETT.speed = !SETT.speed;

                Time.timeScale = SETT.speed ? 6f : 1f;
            }

            if (SETT._trystackitems == true)
            {
                if (!O.ELP)
                {
                    return;
                }

                Inventory inventory = O.ELP.inventory;
                if (inventory != null)
                {
                    //if ()1
                    {

                    }
                }


            }

            if(SETT._healthNstamina==true)
            {
                HealthNStamina();
            };
            if(SETT._foodNwater == true)
            {

                FoodNWater();
            };
            if (SETT._NoBadBuff == true)
            {

                RemoveBadBuff();
            };
            if (SETT._addgoodbuff == true)
            {

                RemoveBadBuff();
                AddGoodBuff();
            };
            if (SETT._ignoreByAI == true)
            {
                IgnoredbyAI();
            };



        }


        #endregion
        //--------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------
        #region OnGUI
        void OnGUI()
        {




        }

        #endregion
        //--------------------------------------------------------------------------------------------------------dd
        //--------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------

        #region Triggers


        public static void IncreaseBuffTimer()
        {

            int num = O.ELP.Buffs.ActiveBuffs.Count;
            for (int i = 0; i < num; i++)
            {
                BuffValue buffValue = O.ELP.Buffs.ActiveBuffs[i];
                if (buffValue.Invalid)
                {
                    O.ELP.Buffs.ActiveBuffs.RemoveAt(i);
                    i--;
                    num--;
                }
                else
                {
                    BuffManager.UpdateBuffTimers(buffValue, 99999f);
                }

            }

        }

        public static void IgnoredbyAI()
        {
            //if(SETT._ignoreByAI )

            O.ELP.SetIgnoredByAI(!O.ELP.IsIgnoredByAI());

            Log.Out(O.ELP.name.ToString() + " is ignored by AI " + O.ELP.IsIgnoredByAI());
        }

        public static void SOMECONSOLEPRINTOUT()  //Creative and debug mode -- Trigger
        {
            string _value = null;

            string _type = "SETT.cmDm";

            if (O.ELP)
            {
                _value = O.ELP.DebugNameInfo;

            }

            Debug.developerConsoleVisible = true;
            Console.WriteLine("THIS IS WRITE LINE" + _type);
            Debug.LogWarning($"Debug <color=_col>LogWarnig</color> for {_type}: " + _value);
            Debug.LogError($"Debug <color=_col>LogError</color> for {_type}: " + _value);
            Debug.Log($"Debug <color=_col>Log</color> for {_type}: " + _type);
            print($"This is a <color=_col_col>Print Message</color> for {_type}: " + _value);
            //Debug.developerConsoleVisible = true;
            GameSparks.Platforms.DefaultPlatform.print($"This is Actually the <color=green>INF/Print </color> console out for {_type} +cm+: " + _value);
            Log.Out("BYYYYYYYYYYY");

        }

        //--------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------
        #endregion
        //--------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------
        #region Toggles
        //public static EntityAlive Entity;
        public static void onehitBlock()   //one hit break - Toggle
        {
            if (O.ELP)
            {
                if (SETT._oneHitBlock == true)
                {
                    float flt = 99999999;
                    BuffValue buff;
                    O.ELP.Buffs.AddBuff("megadamage", -1, true, false, false, 20000000000f);
                    buff = O.ELP.Buffs.GetBuff("megadamage");
                    // need to create a index check so correct index is sekected.
                    buff.BuffClass.Effects.EffectGroups[0].PassiveEffects[1].Values[2] = flt;

                    buff.BuffClass.Hidden = true;
                    buff.BuffClass.RemoveOnDeath = true;
                    buff.BuffClass.IconColor = new Color(0.22f, 0.4f, 1f, 100f);

                }
                else if (SETT._oneHitBlock == false)
                {
                    O.ELP.Buffs.RemoveBuff("megadamage");
                }
                //pegasus for run speed sett float slider on passiveeffect.values

                #region How i managed to find correct getBuff




                //buff = O.ELP.Buffs.GetBuff("megadamage"); // first finding the buff that was added, Each buff has diffrent strings
                //MinEffectController effectController = buff.BuffClass.Effects; // inside the buff we have many things but i want the effects, which is controled by effectcontroller 
                //MinEffectGroup Passive = effectController.EffectGroups[0]; // Then i want the passives, and those are under effect groups, Which is a list of one to many effect groups 
                //PassiveEffect passiveEffect = Passive.PassiveEffects[1];  // i know by studing the game that the block damage is in passive effect index 1 when using "megadamage"
                //passiveEffect.Values[0]=999999f; // and here i am inside passive effect blockdamage, and i want to sett the value of the damage to index 0 (first index)

                ////////buff.BuffClass.Effects.EffectGroups[0].PassiveEffects[1].Values[2] = 9999999f; // here is collect everything in one line, becuse using "." makes us go more down the chain of methods and classes etc

                //////effectController.EffectGroups[0].PassiveEffects[1].Values[2] = 50f; 
                #endregion
            }


        }
        //public static BuffValue buff;

        public static void onehitKill()   //one hit kill - Toggle
        {
            AddPassive(PassiveEffects.EntityDamage, 99999f, ValueModifierTypes.base_set);

            if (SETT._oneHitBlock == true)
            {
                BuffValue buff;
                float flt = 99999999;
                // hew we also use "megadamage" as a reference since it is easier to just utilize a already existing buff with the neccessary passive effects
                O.ELP.Buffs.AddBuff("megadamage", -1, true, false, false, 20000000000f);
                buff = O.ELP.Buffs.GetBuff("megadamage");
                buff.BuffClass.Effects.EffectGroups[0].PassiveEffects[1].Values[2] = flt;

                buff.BuffClass.Hidden = true;
                buff.BuffClass.RemoveOnDeath = true;
                buff.BuffClass.IconColor = new Color(0.22f, 0.4f, 1f, 100f);

            }
            else if (SETT._oneHitBlock == false)
            {
                O.ELP.Buffs.RemoveBuff("megadamage");
            }
            #region How i managed to find correct getBuff




            //buff = O.ELP.Buffs.GetBuff("megadamage"); // first finding the buff that was added, Each buff has diffrent strings
            //MinEffectController effectController = buff.BuffClass.Effects; // inside the buff we have many things but i want the effects, which is controled by effectcontroller 
            //MinEffectGroup Passive = effectController.EffectGroups[0]; // Then i want the passives, and those are under effect groups, Which is a list of one to many effect groups 
            //PassiveEffect passiveEffect = Passive.PassiveEffects[1];  // i know by studing the game that the block damage is in passive effect index 1 when using "megadamage"
            //passiveEffect.Values[0]=999999f; // and here i am inside passive effect blockdamage, and i want to sett the value of the damage to index 2 (third)

            ////////buff.BuffClass.Effects.EffectGroups[0].PassiveEffects[1].Values[2] = 9999999f; // here is collect everything in one line, becuse using "." makes us go more down the chain of methods and classes etc

            //////effectController.EffectGroups[0].PassiveEffects[1].Values[2] = 50f; 
            #endregion



        }


        public static void HealthNStamina() //works but loosing healt to damages, wont degrease by time only direkt damage 
        {

            if (SETT._healthNstamina == true && O.ELP)
            {
                //Log.Out("");
                O.ELP.Stats.Health.Value = O.ELP.Stats.Health.Max;
                O.ELP.Stats.Stamina.Value = O.ELP.Stats.Stamina.Max;
                O.ELP.Stats.Health.LossPassive = PassiveEffects.HealthGain;
                O.ELP.Stats.Stamina.LossPassive = PassiveEffects.StaminaGain;

            }
            else if (SETT._healthNstamina)
            {
                O.ELP.Stats.Health.LossPassive = PassiveEffects.HealthLoss;
                O.ELP.Stats.Stamina.LossPassive = PassiveEffects.StaminaLoss;
            }
        } 
        public static void FoodNWater() //works okey
        {
            if (SETT._foodNwater == true && O.ELP)
            {
                O.ELP.Stats.Food.Value = O.ELP.Stats.Food.Max;
                O.ELP.Stats.Water.Value = O.ELP.Stats.Water.Max;
                O.ELP.Stats.Food.LossPassive = PassiveEffects.HealthGain;
                O.ELP.Stats.Water.LossPassive = PassiveEffects.StaminaGain;

            }
        }



        #endregion


        #region Methods








        public static void ListZombie1() /////////////////////////////// WORKING OOOOOOODOGOGO
        {
            if (O.enemylist.Count > 1)
            {
                foreach (EntityEnemy zombie in O.enemylist)
                {
                    if (!zombie || zombie == O.ELP || !zombie.IsAlive())
                    {
                        continue;
                    }


                    string zombieName = zombie.entityId.ToString();
                    string zm = zombie.name;

                    // Get or set the zombie's toggle state in the dictionary.
                    if (!zombieToggleStates.ContainsKey(zombieName))
                    {
                        zombieToggleStates[zombieName] = false; // Set the initial state to false for new zombies.
                    }
                  
                    bool toggleState = zombieToggleStates[zombieName];
                    CGUILayout.DropDownForMethods(zombieName, () =>
                    {
                        if (GUILayout.Button("Teleport"))
                        {
                            // Perform teleport action for the zombie.
                            O.ELP.TeleportToPosition(zombie.GetPosition());
                        }
                        if (GUILayout.Button("Kill"))
                        {
                        
                            // Perform kill action for the zombie.
                            zombie.DamageEntity(new DamageSource(EnumDamageSource.Internal, EnumDamageTypes.Suicide), 99999, false, 1f);
                            
                        }
                        

                    }, ref toggleState);



                    //GUILayout.BeginHorizontal();
                    //CGUILayout.CustomDropDown(zm+zombieName, () =>
                    //{
                    //    if (GUILayout.Button("Teleport"))
                    //    {
                    //        // Perform teleport action for the zombie.
                    //        O.ELP.TeleportToPosition(zombie.GetPosition());
                    //    }
                    //    if (GUILayout.Button("Kill"))
                    //    {
                    //        // Perform kill action for the zombie.
                    //        zombie.DamageEntity(new DamageSource(EnumDamageSource.Internal, EnumDamageTypes.Suicide), 99999, false, 1f);
                    //    }
                    //}, ref toggleState);
                    //GUILayout.EndHorizontal();

                    // Update the toggle state in the dictionary.
                    zombieToggleStates[zombieName] = toggleState;
                }
            }
            else
            {
                GUILayout.Label("No zombies found.");
            }
        }
        public static void ListPlayer1() /////////////////////////////// WORKING OOOOOOODOGOGO
        {
            if (O.enemylist.Count > 1)
            {
                foreach (EntityPlayer player in O.PlayerList)
                {
                    if (!player || player == O.ELP || !player.IsAlive())
                    {
                        continue;
                    }


                    string zombieName = player.name.ToString();
                    string zm = player.name;

                    // Get or set the zombie's toggle state in the dictionary.
                    if (!zombieToggleStates.ContainsKey(zombieName))
                    {
                        zombieToggleStates[zombieName] = false; // Set the initial state to false for new zombies.
                    }

                    bool toggleState = zombieToggleStates[zombieName];
                    CGUILayout.DropDownForMethods(zombieName, () =>
                    {
                        //CGUILayout.Button("whatever", Color.yellow, Color.blue);
                        if (GUILayout.Button("Teleport"))
                        {
                            // Perform teleport action for the zombie.
                            O.ELP.TeleportToPosition(player.GetPosition());
                        }
                        if (GUILayout.Button("Kill"))
                        {
                            // Perform kill action for the zombie.
                            player.DamageEntity(new DamageSource(EnumDamageSource.Internal, EnumDamageTypes.Suicide), 99999, false, 1f);
                        }//zombie.DamageEntity(new DamageSource(EnumDamageSource.Internal, EnumDamageTypes.Suicide), 99999, false, 1f);

                    }, ref toggleState);

                    // Update the toggle state in the dictionary.
                    zombieToggleStates[zombieName] = toggleState;
                }
            }
            else
            {
                GUILayout.Label("No Players found.");
            }
        }

      
        public static void GetList(bool _bool, EntityPlayerLocal entityLocalPlayer, List<BuffClass> ListOFClass)
        {
            if (ListOFClass != null)


            if (entityLocalPlayer != null|| ListOFClass != null)
            {
                if (ListOFClass.Count > 0)
                {
                    foreach (BuffClass buffClass in ListOFClass)
                    {
                        // se GUILayout.Button to create a button for each buff name
                        if (GUILayout.Button(buffClass.Name))
                        {
                           entityLocalPlayer.Buffs.AddBuff(buffClass.Name, -1, true, false, false, 500f);
                                Debug.LogWarning($"{buffClass.Name} Added to player {O.ELP.gameObject.name}");
                            //Logic when the button is clicked
                        }
                        if (_bool)
                        {
                            break;
                        }
                    }

                }
                else
                {
                    GUILayout.Label("No buffs found.");

                }

            }
            else
            {
                    if(ListOFClass == null)
                    {
                        ListOFClass = O.GetAvailableBuffClasses();
                    }

                
                GUILayout.Label("Not ingame");
            }

        }
        public static void GetList(bool _bool, EntityPlayerLocal entityLocalPlayer, List<EntityZombie> ListOFClass)
        {
            if (ListOFClass != null)


                if (entityLocalPlayer != null || ListOFClass != null)
                {
                    if (ListOFClass.Count > 1)
                    { 
                        foreach (EntityZombie Class in ListOFClass)
                        {
                            if (!Class || Class == O.ELP || !Class.IsAlive())
                            {
                                continue;
                            }

                            string zombieName = Class.entityId.ToString();
                            string zm = Class.name;

                            // Get or set the zombie's toggle state in the dictionary.
                            if (!zombieToggleStates.ContainsKey(zombieName))
                            {
                                zombieToggleStates[zombieName] = false; // Set the initial state to false for new zombies.
                            }

                            bool toggleState = zombieToggleStates[zombieName];
                            CGUILayout.DropDownForMethods(zombieName, () =>
                            {
                                if (GUILayout.Button("Teleport"))
                                {
                                    // Perform teleport action for the zombie.
                                    O.ELP.TeleportToPosition(Class.GetPosition());
                                }
                                if (GUILayout.Button("Kill"))
                                {

                                    // Perform kill action for the zombie.
                                    Class.DamageEntity(new DamageSource(EnumDamageSource.Internal, EnumDamageTypes.Suicide), 99999, false, 1f);

                                }


                            }, ref toggleState);

                            //// se GUILayout.Button to create a button for each buff name
                            //if (GUILayout.Button(Class.EntityName))
                            //{

                            //    Class.DamageEntity(new DamageSource(EnumDamageSource.Internal, EnumDamageTypes.Suicide), 99999, false, 1f);
                            //    SingletonMonoBehaviour<SdtdConsole>.Instance.Output("Gave 99999 damage to entity ");
                            //    //Logic when the button is clicked
                            //}


                            if (_bool)
                            {
                                break;
                            }
                        }

                    }
                    else
                    {
                        GUILayout.Label("No buffs found.");

                    }

                }
                else
                {
                    if (ListOFClass == null)
                    {
                        //ListOFClass 
                    }


                    GUILayout.Label("Not ingame");
                }

        }
        public static void GetList(bool _bool, EntityPlayerLocal entityLocalPlayer, List<EntityPlayer> ListOFClass)
        {
            if (ListOFClass != null)


                if (entityLocalPlayer != null || ListOFClass != null)
                {
                    if (ListOFClass.Count > 1)
                    {
                        foreach (EntityPlayer Class in ListOFClass)
                        {
                            if (!Class || Class == O.ELP || !Class.IsAlive())
                            {
                                continue;
                            }
                            // se GUILayout.Button to create a button for each buff name
                            if (GUILayout.Button(Class.EntityName))
                            {

                                Class.DamageEntity(new DamageSource(EnumDamageSource.Internal, EnumDamageTypes.Suicide), 99999, false, 1f);
                                SingletonMonoBehaviour<SdtdConsole>.Instance.Output("Gave 99999 damage to entity ");
                                //Logic when the button is clicked
                            }


                            if (_bool)
                            {
                                break;
                            }
                        }

                    }
                    else
                    {
                        GUILayout.Label("No buffs found.");

                    }

                }
                else
                {
                    if (ListOFClass == null)
                    {
                        //ListOFClass 
                    }


                    GUILayout.Label("Not ingame");
                }

        }


        public static void GetListPassiveEffects()
        {

            // Get all enum values and sort them alphabetically
            PassiveEffects[] enumValues = System.Enum.GetValues(typeof(PassiveEffects)).Cast<PassiveEffects>().OrderBy(effect => effect.ToString()).ToArray();

            // Calculate the half amount of buttons
            int halfAmount = Mathf.CeilToInt(enumValues.Length / 2f);
            PassiveEffects[] leftColumnEffects = enumValues.Take(halfAmount).ToArray();
            PassiveEffects[] rightColumnEffects = enumValues.Skip(halfAmount).ToArray();

            //bool toggleState = passiveToggleStates[effect];
            CGUILayout.BeginHorizontal(() =>
            {
                CGUILayout.BeginVertical(() =>
                {
                    // Display the buttons in the left column
                    foreach (PassiveEffects effect in leftColumnEffects)
                    {
                        //CGUILayout.Button(effect.ToString(), GUILayout.MaxWidth(150));
                        DisplayToggleButton(effect);
                    }
                });
                CGUILayout.BeginVertical(() =>
                {
                    // Display the buttons in the right column
                    foreach (PassiveEffects effect in rightColumnEffects)
                    {
                        //CGUILayout.Button(effect.ToString(), GUILayout.MaxWidth(150));
                        DisplayToggleButton(effect);
                    }
                });
            });
        }


        private static void DisplayToggleButton(PassiveEffects effect)
        {
            // Get or set the toggle state in the dictionary.
            if (!passiveToggleStates.ContainsKey(effect))
            {
                passiveToggleStates[effect] = false; // Set the initial state to false for new effects.
            }
            bool toggleState = passiveToggleStates[effect];

            // Display the toggle button and update the toggle state in the dictionary.
            bool buttonPressed = CGUILayout.Button(effect.ToString(), GUILayout.MaxWidth(150));
            passiveToggleStates[effect] = buttonPressed;

            // If the button is pressed, set the input text field to the same string as the button text
            if (buttonPressed)
            {
                inputPassiveEffects = effect.ToString();
            }
        }

     
        public static void RemoveBadBuff()
        {
            List<BuffValue> activeBuffs = O.ELP.Buffs.ActiveBuffs;
            foreach (BuffValue buff in activeBuffs)
            {
                //if (buff.BuffClass.DamageType == desiredDamageTypes)
                //if (desiredDamageTypes.Contains(buff.BuffClass.DamageType))
                if (buff.BuffClass.DamageType != EnumDamageTypes.None &&  !ListPerksAlwaysremove.Contains(buff.BuffClass.Name) && buff.BuffName.Contains("customBuff"))
                {
                    O.ELP.Buffs.RemoveBuff(buff.BuffName);
                }
            }

        }
        public static void RemoveAllBuff()
        {
            List<BuffValue> activeBuffs = O.ELP.Buffs.ActiveBuffs;
            foreach (BuffValue buff in activeBuffs)
            {
                //if (buff.BuffClass.DamageType == desiredDamageTypes)
                //if (desiredDamageTypes.Contains(buff.BuffClass.DamageType))
                //if (buff.BuffClass.DamageType != EnumDamageTypes.None && !ListPerksAlwaysremove.Contains(buff.BuffClass.Name) && buff.BuffName.Contains("customBuff"))
                //{
                    O.ELP.Buffs.RemoveBuff(buff.BuffName);
                //}
            }
            //O._minEffectController.EffectGroups.Clear();
            O._minEffectController.EffectGroups[0].PassiveEffects.Clear();
            O._minEffectController.PassivesIndex.Clear();
        }

        public static void RemoveGoodBuff()
        {
            List<BuffValue> activeBuffs = O.ELP.Buffs.ActiveBuffs;
            foreach (BuffValue buff in activeBuffs)
            {
                if (buff.BuffClass.DamageType == EnumDamageTypes.None)
                {
                    O.ELP.Buffs.RemoveBuff(buff.BuffName);
                }
            }
        }
        public static void AddGoodBuff()
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "load", "AddGood.txt");

            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    //foreach (BuffClass buffClass in O.buffClasses.Where(bc => bc.DamageType == EnumDamageTypes.None && !ListPerksAlwaysremove.Contains(bc.Name) && !perkstarts.Any(prefix => bc.Name.StartsWith(prefix)|| bc.Name.Contains(prefix))))
                    foreach (BuffClass buffClass in O.buffClasses.Where(bc => ListPerksAlwaysAdd.Contains(bc.Name)))
                    {
                        O.ELP.Buffs.AddBuff(buffClass.Name, -1, true, false, true, 20f);
                        buffClass.DurationMax = 999f; // how lonmg the perk will last
                        //buffClass.InitialDurationMax;
                        writer.WriteLine($"{buffClass.Name}");
                        Log.Out($"Buff {buffClass.Name} has been added to player");
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        public static void AddEffectGRoup__() // worksXD
        {
            MinEffectGroup effectGroup = O._minEffectController.EffectGroups[0];
            
           
            PassiveEffect newPassiveEffect = new PassiveEffect
            {
                MatchAnyTags = true,
                Modifier = PassiveEffect.ValueModifierTypes.base_add,
                Type = PassiveEffects.JumpStrength,
                Values = new float[] { 50 }, // Adjust the values accordingly
                                              // Set other properties if needed
            };
            O._minEffectController.PassivesIndex.Add(PassiveEffects.JumpStrength);

            effectGroup.PassiveEffects.Remove(newPassiveEffect);
            effectGroup.PassiveEffects.Add(newPassiveEffect);
        }
        public static void AddPassive(PassiveEffects passiveEffects, float value ,ValueModifierTypes valueModifierTypes) 
        {



            /*valueModifierTypes
            Base_set - Sets to valu w eshoose
            Base_add - adds ontop of defalut base
            base_subtract - subtract from base valu
            perc_set _ Multiplier by default eg 100base * 5 float = 500
            perc_add --||--
            perc_subtract - Removes by multiplier
            count - No clue




            */



            if (O.ELP.Buffs.HasBuff("CheatBuff") == false)
            {
                O.ELP.Buffs.AddBuff("CheatBuff");
            }

            List<PassiveEffect> pE1 = new List<PassiveEffect>();
            MinEffectGroup effectGroup = O._minEffectController.EffectGroups[0];
    
            PassiveEffect newPassiveEffect = new PassiveEffect
            {
                MatchAnyTags = true,
                Modifier = valueModifierTypes, 
                Type = passiveEffects,
                Values = new float[] { value }, // Adjust the values accordingly
                                             // Set other properties if needed
            };//this is just the passive effects
 



            var passiveEffectsList = O._minEffectController.EffectGroups[0].PassiveEffects;
            for (int i = passiveEffectsList.Count - 1; i >= 0; i--)
            {
                var effect = passiveEffectsList[i];
                if (
                    //effect.MatchAnyTags == newPassiveEffect.MatchAnyTags &&
                    //effect.Modifier == newPassiveEffect.Modifier &&
                    effect.Type == newPassiveEffect.Type
                    /*&&*/
                    //effect.Values.SequenceEqual(newPassiveEffect.Values)
                    )
                {
                    passiveEffectsList.RemoveAt(i);
                }
            }

            O._minEffectController.PassivesIndex.Add(passiveEffects); // adds to MinEffectController.PassivesIndex MUST DO OTHERWISE NULL REFERENCE ERROR
            //effectGroup.PassiveEffects.Add(newPassiveEffect);           // MinEffectController.MinEffectGroup.PassivesIndex __ This location just adds buffs on top if added multiple times
            O._minEffectController.EffectGroups[0].PassiveEffects.Add(newPassiveEffect);           // MinEffectController.MinEffectGroup.PassivesIndex __ This location just adds buffs on top if added multiple times
           // O._minEffectController.PassivesIndex = new HashSet<PassiveEffects>
           //{
           //        passiveEffects,
           //};


        }

        public static void AddCheatBuff()
        {
            /*
            float WalkSlider = SETT._run;  //set 1 to 5
            float RunSlider = SETT._run;  //set 1 to 5
            float BlockDMGSlider = SETT._dmg;   //set 1 to 50

            //BuffValue buff;


            
            BuffClass test = BuffManager.GetBuff("testbuff");
            test.DamageType = EnumDamageTypes.None; // Set the appropriate damage type if applicable
            test.Description = "This is a custom buff.";
            test.DurationMax = 99999999f;
            //test.Icon = "ui_game_symbol_agility";
            test.ShowOnHUD = true;
            //test.Hidden = false;
            test.IconColor = new Color(0.22f, 0.4f, 1f, 100f);
            test.DisplayType = EnumEntityUINotificationDisplayMode.IconPlusDetail;
            

            
            O._minEffectController.EffectGroups = new List<MinEffectGroup>
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

            };
            O._minEffectController.PassivesIndex = new HashSet<PassiveEffects> 
            {
                
                    PassiveEffects.WalkSpeed,
                    PassiveEffects.RunSpeed,
                    PassiveEffects.BlockDamage,
                    PassiveEffects.CraftingTime,
                    PassiveEffects.None
            };
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

            
            //customBuff.Name = "customBuff";
            //customBuff.DamageType = EnumDamageTypes.None; // Set the appropriate damage type if applicable
            //customBuff.Description = "This is a custom buff.";
            //customBuff.DurationMax = 99999999f;
            //customBuff.Icon = "ui_game_symbol_agility";
            //customBuff.ShowOnHUD = true;
            //customBuff.Hidden = false;
            //customBuff.IconColor = new Color(0.22f, 0.4f, 1f, 100f);
            //customBuff.DisplayType = EnumEntityUINotificationDisplayMode.IconOnly;
            //customBuff.LocalizedName = "This is name in inventory";
            //customBuff.Effects = O._minEffectController;
          
            //O.ELP.Buffs.AddBuff("testbuff");
            */
            if (BuffManager.GetBuff(O.CheatBuff.Name) == null)
            {
                
                Log.Out($"Buff {O.CheatBuff} has ben added");

                O.ELP.Buffs.AddBuff(O.CheatBuff.Name);
                Log.Out($"Buff {O.CheatBuff.Name} has ben added to{O.ELP.Buffs.ActiveBuffs.GetInternalArray()} ");
            }
            else
            {
                Debug.LogWarning($"Buff {O.CheatBuff.Name} was already added to the system");
                if (O.ELP.Buffs.GetBuff(O.CheatBuff.Name) == null)
                {
                    
                    O.ELP.Buffs.AddBuff(O.CheatBuff.Name);
                    Log.Out($"Buff {O.CheatBuff.Name} was Added to to Player again");
                }
            }           
        }
        
        public static void ClearCheatBuff()
        {
            Debug.LogWarning("Clearing CheatBuff");
            O._minEffectController.EffectGroups[0].PassiveEffects.Clear();
            O._minEffectController.PassivesIndex.Clear();
        }
        public static void AddEffectGroup()
        {
            Debug.LogWarning("adding effectGroup");
            O._minEffectController.EffectGroups = new List<MinEffectGroup>
            {

                new MinEffectGroup
               {
                   OwnerTiered = true,
                   PassiveEffects = new List<PassiveEffect>
                   {
                   },
                   PassivesIndex = new List<PassiveEffects>
                       {  
                       }
               }
            };
            //O._minEffectController.PassivesIndex = new HashSet<PassiveEffects>();
        }



        #endregion
    }
}



/*
 * 
 * 
            //BuffClass customBuff2 = BuffManager.GetBuff("customBuff"); // need to  init the buff inside buff class before adding to player

            //customBuff2.Name = "customBuff2";
            //customBuff2.Effects = effectController;

            
            //O.buffClasses.Add(customBuff2);

            
            //O.ELP.Buffs.AddBuff("customBuff2");


            /*
            if(O.ELP.Buffs.GetBuff("customBuff") != null)
            {
                Log.Out("custombuff2 was found and init, chaning values");


            }
            else
            {
                Log.Out("no custombuff2 found here ");
            }


            if (O.ELP.Buffs.GetBuff("customBuff") != null)
            {
                Log.Out("custombuff was found and init, chaning values");
                //Log.Out(buff.BuffName.ToString());
                buff = O.ELP.Buffs.GetBuff("customBuff");
                buff.BuffClass.DurationMax = 99999999f;
                buff.BuffClass.Icon = "ui_game_symbol_agility";
                buff.BuffClass.IconColor = new Color(0.22f, 0.4f, 1f, 100f);
                buff.BuffClass.DisplayType = EnumEntityUINotificationDisplayMode.IconOnly;
                buff.BuffClass.ShowOnHUD = true;
                buff.BuffClass.Hidden = false;
                Log.Out(buff.BuffName.ToString());

            }
            else
            {
                Log.Out("no custombuff found here ");
            }


            
*
*   //private static void DrawZombieDropdown(EntityZombie zombie)
//{
//    CGUILayout.CustomDropDown(zombie.EntityName, () =>
//    {
//        if (GUILayout.Button("Teleport"))
//        {
//            // Perform teleport action for the zombie.
//            O.ELP.TeleportToPosition(zombie.GetPosition());
//        }
//        if (GUILayout.Button("Kill"))
//        {
//            // Perform kill action for the zombie.
//            O.ELP.DamageEntity(new DamageSource(EnumDamageSource.Internal, EnumDamageTypes.Suicide), 99999, false, 1f);
//        }
//    }, ref zombieToggleStates[zombie.EntityName]);
//}


 * 
 *      public static void ZombiesList()
{

    if (O.zombieList.Count > 1)
    {
        foreach (EntityZombie zombie in O.zombieList)
        {
            if (!zombie || zombie == O.ELP || !zombie.IsAlive())
            {
                continue;
            }

            if (GUILayout.Button(zombie.EntityName))
            {
                //O.ELP.TeleportToPosition(zombie.GetPosition());
                zombie.DamageEntity(new DamageSource(EnumDamageSource.Internal, EnumDamageTypes.Suicide), 99999, false, 1f);
                SingletonMonoBehaviour<SdtdConsole>.Instance.Output("Gave 99999 damage to entity ");
            }
        }
    }
    else
    {
        GUILayout.Label("No entities found.");
    }

}

 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 *  //buff = O.ELP.Buffs.GetBuff("customBuff");

    //buff.BuffClass.DurationMax = 99999999f;
    //buff.BuffClass.Icon = "ui_game_symbol_agility";
    //buff.BuffClass.ShowOnHUD = true;
    //buff.BuffClass.Hidden = false;
    //buff.BuffClass.IconColor = new Color(0.22f, 0.4f, 1f, 100f);
    //buff.BuffClass.DisplayType = EnumEntityUINotificationDisplayMode.IconOnly;








    //MinEffectGroup minEffectGroup = new MinEffectGroup { 
    //OwnerTiered = false,

    //}
    //minEffectGroup.PassiveEffects.Add(newPassiveEffect);


    //List<MinEffectGroup> effectGroupsList = new List<MinEffectGroup>();
    //effectGroupsList.Add(minEffectGroup);


    //effectController.EffectGroups = effectGroupsList;


    //customBuff.Effects = effectController;



    //effectController.EffectGroups


    //whats above here is what the buff will look like when added to player
















    //buff.BuffClass.Effects.PassivesIndex.Add(PassiveEffects.BlockDamage); //good adding  adds it to effect controller is not added to effectgroup
    //add check if ther is only one effect group
    //buff.BuffClass.Effects.EffectGroups[0].PassivesIndex.Add(PassiveEffects.BlockDamage); // adds to effectsgroup but empty
    // for next step we need to loop throuh all passiveIndex to get the ones added manually then modify or

    //buff.BuffClass.Effects.EffectGroups[0].PassivesIndex.Contains(PassiveEffects.BlockDamage);



    //var indexvar = buff.BuffClass.Effects.EffectGroups[0].PassivesIndex.Find(effect => effect == PassiveEffects.BlockDamage); // returns passive effect

    //int index = buff.BuffClass.Effects.EffectGroups[0].PassivesIndex.FindIndex(effect => effect == PassiveEffects.BlockDamage); // returns index 
    //if (index != -1)
    //{
    //    buff.BuffClass.Effects.EffectGroups[0].PassivesIndex[index]. // does not return what i want
    //    // Do something with the index thats been selected?... 
    //}




    //PassiveEffect newPassiveEffect = new PassiveEffect
    //{
    //    // Set the properties of the PassiveEffect instance accordingly
    //    MatchAnyTags = true,
    //    Modifier = PassiveEffect.ValueModifierTypes.base_add,
    //    Type = PassiveEffects.BlockDamage,
    //    Values = new float[] { 500 },
    //    // Set other properties if needed
    //};
    //buff.BuffClass.Effects.EffectGroups[0].PassiveEffects.Add(newPassiveEffect);



 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * //one hitt break block --Toggle
//public static void DEbugoutCM()  //Creative and debug mode -- toggle
//{

//    string _type = "SETT.cm";
//    var _value = SETT.cm;
//    Debug.developerConsoleVisible = true;
//    Console.WriteLine("THIS IS WRITE LINE" + _type);
//    Debug.LogWarning($"Debug <color=_col>LogWarnig</color> for {_type}: " + _value);
//    Debug.LogError($"Debug <color=_col>LogError</color> for {_type}: " + _value);
//    Debug.Log($"Debug <color=_col>Log</color> for {_type}: " + _type);
//    print($"This is a <color=_col_col>Print Message</color> for {_type}: " + _value);
//    //Debug.developerConsoleVisible = true;
//    GameSparks.Platforms.DefaultPlatform.print($"This is Actually the <color=green>INF/Print </color> console out for {_type} +cm+: " + _value);
//    Log.Out("BYYYYY");


//}






 * public static void ListButtonPlayer()
{
    if (O.PlayerList.Count > 1)
    {
        foreach (EntityPlayer player in O.PlayerList)
        {
            if (!player || player == O.ELP || !player.IsAlive())
            {
                continue;
            }
            bool bl = false;
            if (CGUILayout.FoldableMenuHorizontal(bl,player.EntityName, () =>
            {
                if (GUILayout.Button("Teleport"))
                {
                    O.ELP.TeleportToPosition(player.GetPosition());
                }
                if (GUILayout.Button("kill"))
                {
                    O.ELP.DamageEntity(new DamageSource(EnumDamageSource.Internal, EnumDamageTypes.Suicide), 99999, false, 1f);
                }

            },50f)) 
            { 


            };

        }
    }
    else
    {

        GUILayout.Label("No players found.");
    }
}

 * 
 * 
 * 
 */