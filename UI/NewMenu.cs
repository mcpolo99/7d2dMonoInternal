
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using O = SevenDTDMono.Objects;
using SETT = SevenDTDMono.Settings;
using SevenDTDMono.Utils;
using UnityEngine.UIElements;
using DynamicMusic;
using UniLinq;
using System.Linq;
//using UnityExplorer;
using InControl;
using System.CodeDom;
using SevenDTDMono;
using TMPro;
//using UniverseLib;
using static PassiveEffect;
using System.Reflection;
using System.Xml.Linq;
using System.Collections.Concurrent;

namespace SevenDTDMono
{
    public class NewMenu : MonoBehaviour
    {



        #region Private bools

        private bool drawMenu = true;
        private bool foldout1 = false;
        private bool foldout2 = false;
        private bool foldout3 = false;
        private bool foldout4 = false;
        private bool foldout5 = false;

        private bool FoldPlayer = false;
        private bool FoldZombie = false;
        private bool FoldBuff = false;
        private bool FoldCBuff = false;
        private bool FoldPassive = false;
        private bool lastBuffAdded = false;
        private bool lastzombieadded = false;
        private string inputFloat = "2";
        private string inputPassive = string.Empty;
        private string inputPassiveEffects = string.Empty;
        private string inputValuModType = string.Empty;
        private int currentIndex = 0;
        private int ValueModifierTypesIndex = 0;

        #endregion


        #region render/GUI stuff
        //private bool drawMenu = true;
        public int _group = 0;
        string[] CheatsString = { "Player", "Toggles and Modifiers", "Buffs and Stuff", "Some crap" };
        private int windowID;
        private Rect windowRect;
        private Vector2 scrollPlayer;
        private Vector2 scrollKill;
        private Vector2 scrollBuff;
        private Vector2 scrollCBuff;
        private Vector2 scrollZombie;
        private Vector2 scrollPassive;

        private Vector2 ScrollMenu3 = Vector2.zero;
        private Vector2 scrollBuffBTN = Vector2.zero;
        private Vector2 ScrollMenu2 = Vector2.zero;
        private Vector2 ScrollMenu1 = Vector2.zero;
        private Vector2 ScrollMenu0 = Vector2.zero;
        private Vector2 test;

        //public ToggleColors toggleColors;
        private GUIStyle customBoxStyleGreen;
        private GUIStyle defBoxStyle;
        GUIStyle centeredLabelStyle;
        #endregion

        #region Random
        private float floatValue = 0.0f;
        public float counter;
        public string Text;
        public Text counterText;
        private string buffSearch = "";
        private string passiveSearch = "";
        #endregion


        //public Dictionary<string, bool> ToggleStates = new Dictionary<string, bool>();


        ConcurrentDictionary<object, Boolean> ToggleBools = new ConcurrentDictionary<object, Boolean>();


        void OnDestroy() 
        {
            O.ELP.Buffs.RemoveBuffs();
        }

        // Start is called before the first frame update
        void Start()
        {
            windowID = new System.Random(Environment.TickCount).Next(1000, 65535);
            windowRect = new Rect(10f, 400f, 400f, 500f);
            GUI.color = Color.white;
        }

        // Update is called once per frame
        void Update()
        {

            if (!Input.anyKey || !Input.anyKeyDown)
            {
                return;
            }

            if (Input.GetKeyDown(KeyCode.F3))
            {
                drawMenu = !drawMenu;
            }
            if (Input.GetKeyDown(KeyCode.F2))
            {
                SETT.drawDebug = !SETT.drawDebug;
            }
            if (SETT.selfDestruct)
            {
                SETT.selfDestruct = false; //set bool to false so we can inject again
                Destroy(Loader.gameObject); // destroys our game object we injected
            }
            if (SETT.aimbot==true)
            {

            }



        }


        private void OnGUI()
        {
            if (drawMenu)
            {
                windowRect = GUILayout.Window(windowID, windowRect, Window, "7Days To Die Cheat Menu"); //draws main menu
            }
            // Create a new GUIStyle based on the default GUI.skin.box
            // Set the desired background color for the box



            #region Styles BE OnGUI

            defBoxStyle = new GUIStyle(GUI.skin.box);
            //defBoxStyle.border = new RectOffset(-2,-2,-2,-2);
            defBoxStyle.padding = new RectOffset(0, 0, 0, 0);


            customBoxStyleGreen = new GUIStyle(GUI.skin.box);
            customBoxStyleGreen.normal.background = MakeTexture(2, 2, new Color(0f, 1f, 0f, 0.5f));




            //customBoxStyleGreen.border = new RectOffset(2, 2, 2, 2);


            centeredLabelStyle = new GUIStyle(GUI.skin.label);
            centeredLabelStyle.alignment = TextAnchor.MiddleCenter;

            #endregion
        }
        private Texture2D MakeTexture(int width, int height, Color color)
        {
            Color[] pixels = new Color[width * height];
            for (int i = 0; i < pixels.Length; i++)
            {
                pixels[i] = color;
            }

            Texture2D texture = new Texture2D(width, height);
            texture.SetPixels(pixels);
            texture.Apply();
            return texture;
        }
        private static string ValueModifierTypesToString(int index)
        {
            return ((PassiveEffect.ValueModifierTypes)index).ToString();
        }
        private void Window(int windowID)
        {
            //if (Settings.Istarted == true|| Settings.Istarted == false)
            //{
            //    windowRect.height = 50;
            //    GUILayout.Space(10f);
            //    GUILayout.BeginHorizontal();
            //    GUILayout.Label("Start a game to load the Menu",centeredLabelStyle);
            //    GUILayout.EndHorizontal();
            //    GUILayout.Space(10f);
            //    GUI.DragWindow();
            //}
            //else
            {
                windowRect.height = 500;
                _group = CGUILayout.Toolbar4(_group, CheatsString, GUI.skin.box); //creating the group for switch comand    
                switch (_group)
                {
                    case 0://switch to menu0
                        Menu0();
                        break;
                    case 1://switch to menu1
                        Menu1();
                        break;
                    case 2://switch to menu2
                        Menu2();
                        break;

                    case 3: //add more for more menu
                            //Log.Out("opening Menu3");
                        Menu3();
                        break;
                }
                GUILayout.Space(10f);

            }
        }
        //CGUILayout.BeginHorizontal(() => {});
        //CGUILayout.BeginVertical(() => {});


        private void Menu0() //player
        {

            //CGUILayout.BeginVertical(() => { });
            //CGUILayout.BeginHorizontal(() => { });

            CGUILayout.BeginHorizontal(() =>
            {
                CGUILayout.BeginVertical(GUI.skin.box, () =>
                {
                    ScrollMenu0 = GUILayout.BeginScrollView(ScrollMenu0);
                    {
                        CGUILayout.BeginHorizontal(() =>
                        {
                            CGUILayout.BeginVertical(() =>
                            {
                                CGUILayout.Button("Add skillpoints", Cheat.skillpoints);
                                CGUILayout.Button("Kill Self", Cheat.KillSelf);
                                //CGUILayout.Button("Ignored By AI with ref", ref SETT._ignoreByAI);

                                CGUILayout.Button("Ignored By AI",ref SETT._ignoreByAI);
                              
                                //CGUILayout.Button("Ignored By AI", Cheat.IgnoredbyAI);
                                CGUILayout.Button("Level Up", Cheat.levelup);

                                CGUILayout.Button("Creative/Debug Mode", ref SETT.CmDm);
                                if (CGUILayout.Button("NameScramble(local)"))
                                {
                                    if (O.ELP) { O.ELP.EntityName = Extras.ScrambleString(O.ELP.EntityName); }

                                }

                            });
                            CGUILayout.BeginVertical(() =>
                            {
                                //SETT._Buffs = CGUILayout.Toggle(SETT._Buffs, "Buffs");

                                CGUILayout.Button("BTN", Cheat.levelup);
                                //CGUILayout.Button("Skillpoints", Cheat.skillpoints);
                                //CGUILayout.Button("Health and Stamina", Cheat.HealthNStamina, ref SETT._healthNstamina);//USE BUFF INSTEAD
                                //CGUILayout.Button("Food And Water", Cheat.FoodNWater,ref SETT._foodNwater);//USE BUFF INSTEAD
                                if (CGUILayout.Button($"Teleport To Marker "))
                                {
                                    O.ELP.TeleportToPosition(new Vector3(O.ELP.markerPosition.ToVector3().x, O.ELP.markerPosition.ToVector3().y+2, O.ELP.markerPosition.ToVector3().z));
                                }
                                CGUILayout.Button("Instant Quest", ref SETT._QuestComplete);
                                CGUILayout.Button("Loop LAST Quest Rewards", ref SETT._LOQuestRewards);
                                CGUILayout.Button("Trader Open 24/7", ref SETT._EtraderOpen);


                                //CGUILayout.Button("Test get player", Cheat.Getplayer);
                                //CGUILayout.Button(ref SETT.TESTTOG, "Test Toggle", Color.green, Color.red);

                            });
                        });
                    }
                    GUILayout.EndScrollView();

                });
            });
            GUI.DragWindow();

        }
        private void Menu1() //Toggles and modifiers
        {
            CGUILayout.BeginHorizontal(GUI.skin.box, () => {
                CGUILayout.BeginVertical(() => {
                    SETT.crosshair = GUILayout.Toggle(SETT.crosshair, "Crosshair");
                    SETT.fovCircle = GUILayout.Toggle(SETT.fovCircle, "Draw FOV");
                    SETT.playerBox = GUILayout.Toggle(SETT.playerBox, "Player Box");
                    SETT.playerName = GUILayout.Toggle(SETT.playerName, "Player Name");
                    SETT.playerCornerBox = GUILayout.Toggle(SETT.playerCornerBox, "Player Corner Box");
                    SETT.chams = GUILayout.Toggle(SETT.chams, "Chams");
                    SETT.playerHealth = GUILayout.Toggle(SETT.playerHealth, "Player Health");
                });
                CGUILayout.BeginVertical(() => {
                    SETT.zombieBox = GUILayout.Toggle(SETT.zombieBox, "Zombie Box");
                    SETT.zombieName = GUILayout.Toggle(SETT.zombieName, "Zombie Name");
                    SETT.zombieHealth = GUILayout.Toggle(SETT.zombieHealth, "Zombie Health");
                    SETT.zombieCornerBox = GUILayout.Toggle(SETT.zombieCornerBox, "Zombie Corner Box");
                    SETT.noWeaponBob = GUILayout.Toggle(SETT.noWeaponBob, "No Weapon Bob");
                });
            });
            CGUILayout.BeginVertical(GUI.skin.box, () =>
            {
                GUIStyle Labelstyle = new GUIStyle(GUI.skin.label);
                Labelstyle.alignment = TextAnchor.LowerCenter;
                Labelstyle.fontSize = 13;
                Labelstyle.padding = new RectOffset(0, 0, -4, 0);


                CGUILayout.BeginHorizontal(() => { GUILayout.Label("Modifiers"); });
                CGUILayout.BeginVertical(() =>
                {
                    //GUILayout.Space(10);
                    CGUILayout.HorizontalScrollbarWithLabel("Attacks/minute", ref SETT._FL_APM,500f);
                    CGUILayout.HorizontalScrollbarWithLabel("Jump Strength", ref SETT._FL_jmp, 5f);
                    CGUILayout.HorizontalScrollbarWithLabel("Harvest Dubbler", ref SETT._FL_harvest, 20f);
                    CGUILayout.HorizontalScrollbarWithLabel("Sprint Speed", ref SETT._FL_run, 25f);
                    CGUILayout.HorizontalScrollbarWithLabel("Kill DMG xM", ref SETT._FL_killdmg, 1000f);
                    CGUILayout.HorizontalScrollbarWithLabel("Block DMG", ref SETT._FL_blokdmg, 1000f);
                    //CGUILayout.BeginHorizontal(() =>
                    //{
                    //    GUILayout.Label("Attacks/minute", Labelstyle, GUILayout.MaxWidth(60));
                    //    SETT._FL_APM = GUILayout.HorizontalScrollbar(SETT._FL_APM, 0f, 0f, 20f);

                    //    //SETT._dmg = GUILayout.HorizontalSlider(SETT._dmg, 0f, 200f);
                    //    //SETT._dmg = GUILayout.HorizontalScrollbar(SETT._dmg, 0.1f, 0f, 200f, GUILayout.ExpandWidth(true));
                    //    GUILayout.Label(SETT._FL_APM.ToString("F1"), Labelstyle, GUILayout.MaxWidth(40));
                    //});
                });
                CGUILayout.BeginVertical(GUI.skin.box ,() =>
                {
                    scrollBuffBTN = GUILayout.BeginScrollView(scrollBuffBTN, GUILayout.MaxHeight(170));//GUILayout.MaxWidth(250f), GUILayout.Width(250f),GUILayout.Height(50f)
                    {
                        CGUILayout.BeginHorizontal(() =>
                        {
                            CGUILayout.BeginVertical(() =>
                            {


                                CGUILayout.Button(ref SETT._BL_Blockdmg, "Block DMG");//button toggle bool
                                CGUILayout.Button(ref SETT._BL_Kill, "Kill DMG");//button toggle bool
                                CGUILayout.Button(ref SETT._BL_Harvest, "Harvest Dubbler");//button toggle bool

                            });
                            CGUILayout.BeginVertical(() =>
                            {
                                CGUILayout.Button(ref SETT._BL_Run, "Sprint Speed");//button toggle bool
                                CGUILayout.Button(ref SETT._BL_Jmp, "Jump Strength");//button toggle bool
                                CGUILayout.Button(ref SETT._BL_APM, "Attacks / minute");//button toggle bool



                            });

                        });
                    }
                    GUILayout.EndScrollView();
                });



            });
            GUI.DragWindow();
        }
        private void Menu2() //Buffs And stuff
        {
            CGUILayout.BeginHorizontal(defBoxStyle, () =>
            {
                ScrollMenu2 = GUILayout.BeginScrollView(ScrollMenu2);
                {
                    CGUILayout.BeginHorizontal(() =>
                    {
                        CGUILayout.BeginVertical("buffs", defBoxStyle, () =>
                        {
                            GUILayout.Space(20f);
                            CGUILayout.BeginVertical(() =>
                            {
                                CGUILayout.BeginVertical(() =>
                                {
                                    scrollBuffBTN = GUILayout.BeginScrollView(scrollBuffBTN, GUILayout.MaxHeight(170));//GUILayout.MaxWidth(250f), GUILayout.Width(250f),GUILayout.Height(50f)
                                    {
                                        CGUILayout.BeginHorizontal(() =>
                                        {
                                            CGUILayout.BeginVertical(() =>
                                            {
                                                //CGUILayout.Button("Set NOBad buff", ref SETT._NoBadBuff);
                                                //CGUILayout.Button("Set good buff", ref SETT._addgoodbuff);
                                                CGUILayout.Button("Remove All Active Buffs", Cheat.RemoveAllBuff);//Cheat.RemoveBadBuff()
                                                CGUILayout.Button("Add CheatBuff to P", Cheat.AddCheatBuff);//Cheat.custombuff();
                                                CGUILayout.Button("Clear CheatBuff", Cheat.ClearCheatBuff);//Cheat.custombuff();
                                                CGUILayout.Button("Add Effect Group", Cheat.AddEffectGroup);//Cheat.custombuff();
                                   
                                                //CGUILayout.Button(ref ToggleStates, "NoBadBuff");
                                                //if (CGUILayout.Button("RELOAD Buffs"))
                                                //{
                                                //    if (SETT.reloadBuffs == false && O.buffClasses.Count <= 10)
                                                //    {
                                                //        SETT.reloadBuffs = true;
                                                //    }
                                                //}
                                                
                                                //CGUILayout.Button("cheat", Cheat);  //O.buffClasses = O.GetAvailableBuffClasses();
                                                //BuffManager.Buffs.Clear(); Removed all buffs from runtime
                                                //CGUILayout.Button("Remove Bad Buffs", Cheat.RemoveBadBuff);//Cheat.RemoveBadBuff();
                                             
                                                //CGUILayout.Button("Add Good Buffs", Cheat.AddGoodBuff);//Cheat.AddGoodBuff();

                                                //CGUILayout.Button(ref SETT._BL_Blockdmg, "One hit block");//button toggle bool
                                                //CGUILayout.Button(ref SETT._BL_Kill, "One hit kill");//button toggle bool
                                                //CGUILayout.Button(ref SETT._BL_Harvest, "Dubbel Harvest");//button toggle bool
                                                //GUILayout.Label("rigth", centeredLabelStyle);
                                            });
                                            CGUILayout.BeginVertical(() =>
                                            {
                                                if (CGUILayout.Button("Print Buffs To Logfile"))
                                                {
                                                    Extras.LogAvailableBuffNames(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "load", "BuffsList.txt"));
                                                }
                                                CGUILayout.Button("");
                                                //CGUILayout.Button("NoBadBuff", ref ToggleStates);
                                                //if (CGUILayout.Button("Print Buffs To Logfile"))
                                                //{
                                                //    Extras.LogAvailableBuffNames(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "load", "BuffsList.txt"));
                                                //    /*
                                                //    //CBuffs.ParseAddBuff();
                                                //    //XDocument xmlDoc = CBuffs.LoadEmbeddedXML("TESTBUFF.XML");


                                                //    //XElement xmlElmt = CBuffs.LoadEmbeddedXML("TESTBUFF.XML");

                                                //    //BuffsFromXml.CreateBuffs(xmlDoc);
                                                //    // Now you can work with the XML data (e.g., access nodes, read attributes, etc.).
                                                //    // For example, let's print the contents of the XML to the Unity console.
                                                //    //Debug.Log(xmlDoc.ToString());



                                                //    //Cheat.AddPassive(PassiveEffects.InfiniteAmmo, 1, PassiveEffect.ValueModifierTypes.base_set);
                                                //    //Cheat.AddPassive(PassiveEffects.HyperthermalResist, 1, PassiveEffect.ValueModifierTypes.base_set);
                                                //    */
                                                //}
                                                //if (CGUILayout.Button("add Passive crafttimer"))
                                                //{
                                                //    Cheat.AddPassive(PassiveEffects.CraftingTier, 3, PassiveEffect.ValueModifierTypes.base_set);
                                                //    Cheat.AddPassive(PassiveEffects.CraftingTime, 999, PassiveEffect.ValueModifierTypes.base_set);

                                                //    CGUILayout.Button1("Add Effect Group", new Action[] { Cheat.AddCheatBuff, () => Cheat.AddPassive(PassiveEffects.CraftingTime, 999, PassiveEffect.ValueModifierTypes.base_set) });
                                                //}
                                                //if (CGUILayout.Button("add Passive Jump"))
                                                //{
                                                //    Cheat.AddPassive(PassiveEffects.JumpStrength, 5, PassiveEffect.ValueModifierTypes.base_set);
                                                //    //Cheat.AddPassive(PassiveEffects.CraftingTime, 999, PassiveEffect.ValueModifierTypes.base_set);


                                                //}

                                                //CGUILayout.Button("add Jump buff for test", Cheat.AddEffectGRoup__);

                                            });

                                        });
                                    }
                                    GUILayout.EndScrollView();
                                });
                                CGUILayout.BeginHorizontal(customBoxStyleGreen);

                                FoldCBuff = CGUILayout.FoldableMenuHorizontal(FoldCBuff, "Custom Buffs", () => {
                                    scrollCBuff = GUILayout.BeginScrollView(scrollCBuff);//GUILayout.MaxWidth(250f), GUILayout.Width(250f),GUILayout.Height(50f)
                                    {
                                        Cheat.GetListCBuffs(O.ELP, CBuffs.CustomBuffs);
                                    }
                                    GUILayout.EndScrollView();
                                }, 300f);

                                CGUILayout.BeginHorizontal(customBoxStyleGreen);



                                CGUILayout.BeginVertical(GUI.skin.box, () =>
                                {


                                    CGUILayout.BeginVertical(() =>
                                    {
                                       
                                        FoldPassive = CGUILayout.FoldableMenuHorizontal(FoldPassive, "Passive Effects", () => {


                                            CGUILayout.BeginHorizontal(() => {
                                                Cheat.inputPassiveEffects = GUILayout.TextField(Cheat.inputPassiveEffects, 50);
                                                inputPassive = ValueModifierTypesToString(ValueModifierTypesIndex); // Set text field with the button's current value
                                                inputFloat = GUILayout.TextField(inputFloat, 10, GUILayout.MaxWidth(25));
                                                if (CGUILayout.Button("", ref ValueModifierTypesIndex, GUILayout.MaxWidth(100)))
                                                {
                                                    ValueModifierTypes selectedType = (ValueModifierTypes)ValueModifierTypesIndex;
                                                    //Debug.Log("Selected Enum: " + selectedType);

                                                }
                                                if (CGUILayout.Button("ADD", GUILayout.MaxWidth(40)))
                                                {
                                                    try
                                                    {
                                                        float floatValue = float.Parse(inputFloat);
                                                        if (System.Enum.TryParse(Cheat.inputPassiveEffects, out PassiveEffects passiveEffect))
                                                        {
                                                            Cheat.AddPassive(passiveEffect, floatValue, (PassiveEffect.ValueModifierTypes)ValueModifierTypesIndex);
                                                            Log.Out(inputPassiveEffects);
                                                            Log.Out($"{passiveEffect} added");
                                                        }
                                                        else
                                                        {
                                                            Log.Out(inputPassiveEffects);
                                                            Log.Out($"{passiveEffect} not added");
                                                            // Handle the case when the inputPassiveEffects cannot be parsed to the enum.
                                                            // Display an error message, provide a default value, or take appropriate action.
                                                        }
                                                    }
                                                    catch
                                                    { }



                                                    //ValueModifierTypes selectedType = (ValueModifierTypes)System.Enum.ToObject(typeof(ValueModifierTypes), currentIndex);
                                                    //inputPassive = selectedType.ToString();
                                                }
                                            });
                                            CGUILayout.BeginHorizontal(() => {
                                                GUILayout.Label("Passive Search");
                                                passiveSearch = GUILayout.TextField(passiveSearch, GUILayout.MaxWidth(225f), GUILayout.Height(20f));
                                            });
                                            scrollPassive = GUILayout.BeginScrollView(scrollPassive);//GUILayout.MaxWidth(250f), GUILayout.Width(250f),GUILayout.Height(50f)
                                            {
                                                Cheat.GetListPassiveEffects(passiveSearch);
                                            }
                                            GUILayout.EndScrollView();
                                        }, 300f);
                                    });
                                });








                                CGUILayout.BeginHorizontal(customBoxStyleGreen);
                                FoldBuff = CGUILayout.FoldableMenuHorizontal(FoldBuff, "Scroll All Buffs", () => {

  
                                    CGUILayout.BeginHorizontal(() => {
                                        GUILayout.Label("Search for buff");
                                        buffSearch = GUILayout.TextField(buffSearch, GUILayout.MaxWidth(225f), GUILayout.Height(20f));
                                    });
                                        
                                    scrollBuff = GUILayout.BeginScrollView(scrollBuff);//GUILayout.MaxWidth(250f), GUILayout.Width(250f),GUILayout.Height(50f)
                                    {
                                        Cheat.GetList(lastBuffAdded, O.ELP, O.buffClasses,buffSearch);
                                    }
                                    GUILayout.EndScrollView();
                                }, 300f);
                                CGUILayout.BeginHorizontal(customBoxStyleGreen);
                            });
                        });
                    });
                }
                GUILayout.EndScrollView();
            });
            GUI.DragWindow();

        } //Buffs an  stuff
        private void Menu3()//some crap
        {
            CGUILayout.BeginVertical(GUI.skin.box, () =>
            {
                ScrollMenu3 = GUILayout.BeginScrollView(ScrollMenu3);
                {

                    CGUILayout.BeginHorizontal(customBoxStyleGreen);
                    //scrollZombie = GUILayout.BeginScrollView(scrollZombie, GUILayout.MinHeight(100f), GUILayout.MaxHeight(400f));//GUILayout.MaxWidth(250f), GUILayout.Width(250f),, GUILayout.Height(200f)
                    //{
                    //    LISTDROPPDOWNMENU();
                    //    //Cheat.GetList(lastBuffAdded, O.ELP, O.buffClasses);
                    //}

                    foldout1 = CGUILayout.FoldableMenuHorizontal(foldout1, "Scroll Zombies", () =>
                    {  // Content to show when the foldout is open for Foldable Menu 1
                       // Add your UI elements here...
                        CGUILayout.BeginVertical(GUI.skin.box, () =>
                        {

                            CGUILayout.BeginHorizontal(customBoxStyleGreen);
                            scrollZombie = GUILayout.BeginScrollView(scrollZombie, GUILayout.MinHeight(100f), GUILayout.MaxHeight(400f));//GUILayout.MaxWidth(250f), GUILayout.Width(250f),, GUILayout.Height(200f)
                            {
                                //Cheat.GetList(lastzombieadded, O.ELP, O.zombieList);
                                //LISTDROPPDOWNMENU();
                                Cheat.ListZombie1();
                            }
                            GUILayout.EndScrollView();

                        });
                    }, 300f);


                    CGUILayout.BeginHorizontal(customBoxStyleGreen);
                    foldout2 = CGUILayout.FoldableMenuHorizontal(foldout2, "Scroll Players", () =>
                    {
                        CGUILayout.BeginHorizontal(customBoxStyleGreen);
                        scrollPlayer = GUILayout.BeginScrollView(scrollPlayer, GUILayout.MinHeight(100f), GUILayout.MaxHeight(400f));//GUILayout.MaxWidth(250f), GUILayout.Width(250f),, GUILayout.Height(200f)
                        {
                            //Cheat.ListButtonPlayer();
                            Cheat.ListPlayer1();
                            //LISTDROPPDOWNMENU();
                            //Cheat.GetList(lastBuffAdded, O.ELP, O.buffClasses);
                        }
                        GUILayout.EndScrollView();
                    }, 300f);
                    CGUILayout.BeginHorizontal(customBoxStyleGreen);
                    foldout5 = CGUILayout.FoldableMenuHorizontal(foldout5, "Foldable Menu 5", () =>
                    {
                        CGUILayout.BeginVertical(GUI.skin.box, () =>
                        {


                            CGUILayout.BeginHorizontal(customBoxStyleGreen, () =>
                            {
                                CGUILayout.BeginVertical(GUI.skin.box, () =>
                                {


                                    GUILayout.Label("EXPERIMENTAL ", centeredLabelStyle);
                                    SETT.aimbot = GUILayout.Toggle(SETT.aimbot, "Aimbot (L-alt)");
                                    SETT.magicBullet = GUILayout.Toggle(SETT.magicBullet, "Magic Bullet(L-alt");

                                });
                                CGUILayout.BeginVertical(customBoxStyleGreen, () =>
                                {
                                    GUILayout.Label("L4 Content for Menu ", centeredLabelStyle); //here are all the items placed
                                                                                                 //>-
                                });

                            });
                        });
                    }, 300f);
                }
                GUILayout.EndScrollView();
            });
            GUI.DragWindow();
        }

        #region

        /*
        private void Menu6()
        {
            CGUILayout.BeginVertical(GUI.skin.box ,() => 
            {

                ScrollMenu3 = GUILayout.BeginScrollView(ScrollMenu3);
                {
                    foldout1 = CGUILayout.FoldableMenuHorizontal(foldout1, "Foldable Menu 1", () =>
                    {  // Content to show when the foldout is open for Foldable Menu 1
                       // Add your UI elements here...
                       CGUILayout.BeginVertical(GUI.skin.box ,() => 
                       {
                           // Start a vertical layout group for the label and horizontal layoutqqq
                               GUILayout.Label("L1 Content for Menu 2", centeredLabelStyle); //Label for the menu
                           CGUILayout.BeginHorizontal(() =>
                           {
                               CGUILayout.BeginVertical(() => 
                               {
                                   GUILayout.Label("DMG Multiply " + SETT._dmg.ToString("F2"));

                               }, GUILayout.MaxWidth(50));

                               CGUILayout.BeginVertical(() => 
                               {
                                   SETT._dmg = GUILayout.HorizontalScrollbar(SETT._dmg, 0.1f, 0f, 300f);
                               });
                           });
                           CGUILayout.BeginHorizontal(customBoxStyleGreen ,() => 
                           {
                               CGUILayout.BeginVertical(centeredLabelStyle ,() =>
                               {
                                   GUILayout.Label("side left", centeredLabelStyle);
                               });
                               CGUILayout.BeginVertical(() => { });


                           });
                       });
                    }, 300f);




                    foldout2 = CGUILayout.FoldableMenuHorizontal(foldout2, "Foldable Menu 2", () =>
                    {  // Content to show when the foldout is open for Foldable Menu 1
                       // Add your UI elements here...
                        GUILayout.BeginVertical(GUI.skin.box);
                        { // Start a vertical layout group for the label and horizontal layout
                            GUILayout.Label("L1 Content for Menu 2", centeredLabelStyle); //Label for the menu
                            GUILayout.BeginHorizontal(customBoxStyleGreen);
                            {

                                GUILayout.BeginVertical();
                                {

                                    CGUILayout.Button(ref SETT._oneHitBlock, "One hit block", Color.green, Color.red, Color.yellow);//button toggle bool
                                    CGUILayout.Button(ref SETT._oneHitKill, "One hit kill", Color.green, Color.red, Color.yellow);//button toggle bool
                                }
                                GUILayout.EndVertical();
                                GUILayout.BeginVertical();
                                {
                                    GUILayout.Label("rigth", centeredLabelStyle);

                                }
                                GUILayout.EndVertical();
                            }
                            GUILayout.EndHorizontal();
                        }
                        GUILayout.EndVertical();
                    }, 300f);
                    foldout3 = CGUILayout.FoldableMenuHorizontal(foldout3, "Foldable Menu 3 Lists", () =>
                    {  // Content to show when the foldout is open for Foldable Menu 1
                       // Add your UI elements here...
                        GUILayout.BeginVertical(GUI.skin.box);
                        { // Start a vertical layout group for the label and horizontal layout
                          //
                            GUILayout.Label("L1 Content for Menu 2", centeredLabelStyle); //Label for the menu


                            GUILayout.BeginVertical("Kill zombie", GUI.skin.box);
                            {
                                GUILayout.Space(20f);

                                scrollKill = GUILayout.BeginScrollView(scrollKill, GUILayout.MaxWidth(300f));
                                {
                                    //Cheat.ListbuttonZombie2();
                                }
                                GUILayout.EndScrollView();
                            }
                            GUILayout.EndVertical();
                            GUILayout.BeginVertical("Teleport", GUI.skin.box);
                            {
                                GUILayout.Space(20f);

                                scrollPlayer = GUILayout.BeginScrollView(scrollPlayer, GUILayout.MaxWidth(300f));
                                {
                                    //Cheat.ListbuttonZombie1();
                                    //Cheat.ListButtonPlayer();
                                }
                                GUILayout.EndScrollView();
                            }
                            GUILayout.EndVertical();

                            //GUILayout.Label("L2 Content for Menu 2", centeredLabelStyle); //here are all the items placed

                        }
                        GUILayout.EndVertical();
                    }, 300f);
                    foldout4 = CGUILayout.FoldableMenuHorizontal(foldout4, "Foldable Menu 4 Some Stat Buffs", () =>
                    {  // Content to show when the foldout is open for Foldable Menu 1
                       // Add your UI elements here...
                        CGUILayout.BeginVertical(GUI.skin.box ,() => 
                        {
                            GUILayout.Label("L1 Content for Menu 2", centeredLabelStyle);
                            CGUILayout.BeginHorizontal(() => 
                            {
                                CGUILayout.BeginVertical(customBoxStyleGreen ,() => { });
                                CGUILayout.BeginVertical(customBoxStyleGreen ,() => { });

                            });

                        });
                    }, 300f);
                    foldout5 = CGUILayout.FoldableMenuHorizontal(foldout5, "Foldable Menu 5", () =>
                    {
                        CGUILayout.BeginVertical(GUI.skin.box, () => 
                        {


                            CGUILayout.BeginHorizontal(customBoxStyleGreen ,() =>
                            {
                                CGUILayout.BeginVertical(GUI.skin.box, () => 
                                {


                                    GUILayout.Label("EXPERIMENTAL ", centeredLabelStyle);
                                    SETT.aimbot = GUILayout.Toggle(SETT.aimbot, "Aimbot (L-alt)");
                                    SETT.magicBullet = GUILayout.Toggle(SETT.magicBullet, "Magic Bullet(L-alt");

                                });
                                CGUILayout.BeginVertical(customBoxStyleGreen, () => 
                                {
                                    GUILayout.Label("L4 Content for Menu ", centeredLabelStyle); //here are all the items placed
                                                                                                 //>-
                                });

                            });
                        });
                    }, 300f);
                }
                GUILayout.EndScrollView();
            });
            GUI.DragWindow();
        }
        */
        #endregion


    }
}









//GUILayout.BeginVertical();
//{
//    SETT.CmDm = CGUILayout.Toggle(SETT.CmDm, "Creative/Debug Mode");//toggle on/off bool
//    SETT.TESTTOG = CGUILayout.Toggle(SETT.TESTTOG, "TESTTOG");

//    SETT.drpbp = CGUILayout.Toggle(SETT.drpbp, "drpbkssdffsdfsdrfsfsd");//toggle on/off bool
//    SETT.speed = CGUILayout.Toggle(SETT.speed, "speed");//toggle on/off bool
//    SETT.speed = CGUILayout.Toggle(SETT.speed, "Game speed");//toggle on/off bool
//                                                             //if (GUILayout.Button("xp-modifier"))
//                                                             //{
//                                                             //}
//                                                             //if (GUILayout.Button("Label"))
//                                                             //{
//                                                             //}
//                                                             //if (GUILayout.Button("PasswordField"))
//                                                             //{
//                                                             //}
//                                                             //if (GUILayout.Button("TextField"))
//                                                             //{
//                                                             //}
//                                                             //if (GUILayout.Button("Box"))
//                                                             //{

//    //}
//    //if (GUILayout.Button("RepeatButton"))
//    //{

//    //}
//}
//GUILayout.EndVertical();

//GUILayout.BeginVertical();
//{
//    if (CGUILayout.Button("CONSOLEPRINT"))
//    {
//        Cheat.SOMECONSOLEPRINTOUT();
//    }

//    if (GUILayout.Button("Close gameobject"))
//    {
//        SETT.selfDestruct = true;
//    }
//    CGUILayout.Button(ref SETT._QuickScrap, "Quick scrap", Color.green, Color.red);


//    //if (GUILayout.Button("TextArea"))
//    //{

//    //}
//    //if (GUILayout.Button("HorizontalSlider"))
//    //{

//    //}
//    //if (GUILayout.Button("VerticalSlider"))
//    //{
//    //}
//    //if (GUILayout.Button("DrawTexture"))
//    //{

//    //}
//    //if (GUILayout.Button("Window"))
//    //{
//    //}
//}
//GUILayout.EndVertical();


























//GUILayout.BeginHorizontal();
//{
//    GUILayout.BeginVertical();
//    {

//    }GUILayout.EndVertical();
//}GUILayout.EndHorizontal();




//if (GUILayout.Button("xp-modifier"))
//{
//}
//if (GUILayout.Button("Label"))
//{
//}
//if (GUILayout.Button("PasswordField"))
//{
//}
//if (GUILayout.Button("TextField"))
//{
//}
//if (GUILayout.Button("Box"))
//{

//}
//if (GUILayout.Button("RepeatButton"))
//{

//}
//GUILayout.EndVertical();
//GUILayout.BeginVertical();

//if (GUILayout.Button("TextArea"))
//{

//}
//if (GUILayout.Button("HorizontalSlider"))
//{

//}
//if (GUILayout.Button("VerticalSlider"))
//{
//}
//if (GUILayout.Button("DrawTexture"))
//{

//}
//if (GUILayout.Button("Window"))
//{
//}
//if (GUILayout.Button("Toggle"))
//{
//    SETT.selfDestruct = true;
//}



