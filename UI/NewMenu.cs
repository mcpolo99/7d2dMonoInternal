
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;
using O = SevenDTDMono.Objects;
using SETT = SevenDTDMono.Settings;
using SevenDTDMono.Utils;
using UnityEngine.UIElements;
using DynamicMusic;
using UniLinq;
using System.Linq;
using UnityExplorer;
using InControl;
using System.CodeDom;
using SevenDTDMono;

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
        private bool buffFold = false;
        private bool lastBuffAdded = false;

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

        private Vector2 ScrollMenu3 = Vector2.zero;
        private Vector2 ScrollMenu2 = Vector2.zero;
        private Vector2 ScrollMenu1 = Vector2.zero;
        private Vector2 ScrollMenu0= Vector2.zero;

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
        private Logger _log;
        #endregion






        // Start is called before the first frame update
        void Start()
        {
            windowID = new System.Random(Environment.TickCount).Next(1000, 65535);
            windowRect = new Rect(10f, 400f, 400f,500f);
            GUI.color = Color.white;
            _log = new Logger();
            _log.InitializeLogger();

           

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

        private void Window(int windowID)
        {
            if (Settings.Istarted == true)
            {
                windowRect.height = 50;
                GUILayout.Space(10f);
                GUILayout.BeginHorizontal();
                GUILayout.Label("Start a game to load the Menu",centeredLabelStyle);
                GUILayout.EndHorizontal();
                GUILayout.Space(10f);
                GUI.DragWindow();
            }
            else
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
     
            GUILayout.BeginHorizontal();
            {
                GUILayout.BeginVertical(GUI.skin.box);
                {
                    ScrollMenu0 = GUILayout.BeginScrollView(ScrollMenu0);
                    {
                        GUILayout.BeginHorizontal();
                        {
                            GUILayout.BeginVertical();
                            {
                                if (CGUILayout.Button("Level Up"))
                                {
                                    Cheat.levelup();
                                }
                                if (CGUILayout.Button("Add skillpoints"))
                                {
                                    Cheat.skillpoints();
                                }
                                if (CGUILayout.Button("Kill Self"))
                                {
                                    Cheat.KillSelf();
                                }
                                if (CGUILayout.Button("Ignored By AI", ref SETT._ignoreByAI))
                                {
                                    Cheat.IgnoredbyAI();
                                }
                                CGUILayout.Button("Nothing her eyet");



                            }
                            GUILayout.EndVertical();
                            GUILayout.BeginVertical();
                            {
                                SETT._Buffs = CGUILayout.Toggle(SETT._Buffs, "Buffs");

                                CGUILayout.Button("BTN", Cheat.levelup);
                                //CGUILayout.Button("Skillpoints", Cheat.skillpoints);
                                CGUILayout.Button("Health and Stamina", Cheat.HealthNStamina, ref SETT._healthNstamina);
                                CGUILayout.Button("Food And Water", ref SETT._foodNwater);

                                CGUILayout.Button("Test get player", Cheat.Getplayer);
                                CGUILayout.Button(ref SETT.TESTTOG, "Test Toggle", Color.green, Color.red);

                            }
                            GUILayout.EndVertical();
                        }GUILayout.EndHorizontal();
                    }GUILayout.EndScrollView();
                }GUILayout.EndVertical();

               
            }GUILayout.EndHorizontal();


            GUI.DragWindow();
          
        }
        private void Menu1() //esp stuff and som toggles
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
            GUI.DragWindow();
        }
        private void Menu2()
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
                                    CGUILayout.BeginHorizontal(() =>
                                    {
                                        CGUILayout.BeginVertical(() =>
                                        {
                                            if (CGUILayout.Button("Unused Button ATM"))
                                            {
                                                //O.buffClasses = O.GetAvailableBuffClasses();
                                                //BuffManager.Buffs.Clear(); Removed all buffs from runtime
                                            }
                                            if (CGUILayout.Button("Remove Bad Buffs"))
                                            {
                                                Cheat.RemoveBadBuff();

                                            }
                                            if (CGUILayout.Button("add customBuff"))
                                            {
                                                Cheat.custombuff();
                                            }
                                            if (CGUILayout.Button("add Good Buffs"))
                                            {
                                                Cheat.AddGoodBuff();
                                            }
                                            

                                        });
                                        CGUILayout.BeginVertical(() =>
                                        {
                                            if (CGUILayout.Button("Remove All Active Buffs"))
                                            {
                                                if (O.ELP != null)
                                                {
                                                    O.ELP.Buffs.RemoveBuffs(); //clears current buffs
                                                }

                                            }
                                            if (CGUILayout.Button("Debug"))
                                            {
                                                float watrFLT = O.ELP.Buffs.GetCustomVar("waterAmount");
                                                string watrstr = watrFLT.ToString();
                                                Log.Out(watrstr);


                                                //float _originalValue = 0f;
                                                //float num = 1f;

                                                //O.localPlayer.Buffs.ModifyValue(PassiveEffects., ref _originalValue, ref num, default(FastTags));

                                                //EntityStats.Entity.Buffs.GetCustomVar("$waterAmount", 0f));
                                            }
                                            if (CGUILayout.Button("RELOAD"))
                                            {
                                                if (SETT.reloadBuffs == false && O.buffClasses.Count == 0)
                                                {
                                                    SETT.reloadBuffs = true;
                                                }
                                            }

                                        });

                                    });
                                });
                                CGUILayout.BeginHorizontal(customBoxStyleGreen);
                                scrollBuff = GUILayout.BeginScrollView(scrollBuff, GUILayout.MaxWidth(250f), GUILayout.Width(250f), GUILayout.Height(200f));
                                {
                                    Cheat.GetList(lastBuffAdded, O.ELP, O.buffClasses);
                                }
                                GUILayout.EndScrollView();
                                CGUILayout.BeginHorizontal(customBoxStyleGreen);
                            });
                        });
                    });
                } 
                GUILayout.EndScrollView();
            });
            GUI.DragWindow();
            
        } //Buffs an  stuff
        private void Menu3()
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
                                    Cheat.ListbuttonZombie();
                                }
                                GUILayout.EndScrollView();
                            }
                            GUILayout.EndVertical();
                            GUILayout.BeginVertical("Teleport", GUI.skin.box);
                            {
                                GUILayout.Space(20f);

                                scrollPlayer = GUILayout.BeginScrollView(scrollPlayer, GUILayout.MaxWidth(300f));
                                {
                                    Cheat.ListButtonPlayer();
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



