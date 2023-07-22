
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

namespace SevenDTDMono
{
    public class NewMenu : MonoBehaviour
    {

        public int _group = 0;
        string[] CheatsString = { "Menu0", "Menu1", "Menu2","menu3" };
        private bool drawMenu = true;

        //private bool drawMenu = true;
        private int windowID;
        private Rect windowRect;
        private Rect guiRect;


        private Vector2 scrollPlayer;
        private Vector2 scrollKill;
        private Vector2 scrollBuff;
        private Vector2 scrollBuff2;
        private Vector2 scrollPosition1 = Vector2.zero;
        private Vector2 ScrollMenu3 = Vector2.zero;
        private Vector2 ScrollMenu2 = Vector2.zero;
        public bool cmt;
        public string Text;
        public Text counterText;
        public float counter;
        public ToggleColors toggleColors;
        private bool foldout1 = false;
        private bool foldout2 = false;
        private bool foldout3 = false;
        private bool foldout4 = false;
        private bool foldout5 = false;
        private bool lastBuffAdded = false;
        private float floatValue = 0.0f;
        private GUIStyle customBoxStyleGreen;
        GUIStyle centeredLabelStyle;





        // Start is called before the first frame update
        void Start()
        {
            windowID = new System.Random(Environment.TickCount).Next(1000, 65535);
            windowRect = new Rect(10f, 10f, 400f, 300f);
            guiRect = new Rect(0, 0, 300, 300);
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
            if (Input.GetKeyDown(KeyCode.Delete))
            {
                SETT.selfDestruct = false; //set bool to false so we can inject again
                Destroy(Loader.gameObject); // destroys our game object we injected
                UnityEngine.Object.Destroy(gameObject);
            }



        }


        private void OnGUI()
        {


            if (drawMenu)
            {
                windowRect = GUILayout.Window(windowID, windowRect, Window, "Menu"); //draws main menu
            }
            //SETT.CmDm = GUILayout.Toggle(SETT.CmDm, "Creative/Debug Mode", toggleStyle);

            // Create a new GUIStyle based on the default GUI.skin.box
            // Set the desired background color for the box
            customBoxStyleGreen = new GUIStyle(GUI.skin.box);
            customBoxStyleGreen.normal.background = MakeTexture(2, 2, new Color(0f, 1f, 0f, 0.5f));
            //customBoxStyleGreen.border = new RectOffset(2, 2, 2, 2);


            centeredLabelStyle = new GUIStyle(GUI.skin.label);
            centeredLabelStyle.alignment = TextAnchor.MiddleCenter;


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
                    Menu3();
                    break;
            }
            GUILayout.Space(10f);
            
        }

        private void Menu0() //player
        {
     
            GUILayout.BeginHorizontal();
            {
                GUILayout.BeginVertical(GUI.skin.box);
                {
                    scrollPosition1 = GUILayout.BeginScrollView(scrollPosition1);
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
                            if (CGUILayout.Button("Kill"))
                            {
                                Cheat.KillSelf();
                            }
                            if (CGUILayout.Button("Ignored By AI"))
                            {
                                Cheat.KillSelf();
                            }
                            CGUILayout.Button("Quick melt");



                        }GUILayout.EndVertical();
                        GUILayout.BeginVertical();
                        {
                            SETT._Buffs = CGUILayout.Toggle(SETT._Buffs, "Buffs");
                           
                            CGUILayout.Button(ref SETT.TESTTOG, "Test Toggle", Color.green, Color.red);

                        }GUILayout.EndVertical();
                    }GUILayout.EndScrollView();
                }GUILayout.EndVertical();

               
            }GUILayout.EndHorizontal();


            GUI.DragWindow();
          
        }
        private void Menu1() //esp stuff
        {

            //ESP STUFF
            GUILayout.BeginHorizontal(GUI.skin.box);
            {
                GUILayout.BeginVertical();
                {
                    SETT.crosshair = GUILayout.Toggle(SETT.crosshair, "Crosshair");
                    SETT.fovCircle = GUILayout.Toggle(SETT.fovCircle, "Draw FOV");
                    SETT.playerBox = GUILayout.Toggle(SETT.playerBox, "Player Box");
                    SETT.playerName = GUILayout.Toggle(SETT.playerName, "Player Name");
                    SETT.playerCornerBox = GUILayout.Toggle(SETT.playerCornerBox, "Player Corner Box");
                    SETT.chams = GUILayout.Toggle(SETT.chams, "Chams");
                    SETT.playerHealth = GUILayout.Toggle(SETT.playerHealth, "Player Health");


                } GUILayout.EndVertical();
                GUILayout.BeginVertical();
                {
                    SETT.zombieBox = GUILayout.Toggle(SETT.zombieBox, "Zombie Box");
                    SETT.zombieName = GUILayout.Toggle(SETT.zombieName, "Zombie Name");
                    SETT.zombieHealth = GUILayout.Toggle(SETT.zombieHealth, "Zombie Health");
                    SETT.zombieCornerBox = GUILayout.Toggle(SETT.zombieCornerBox, "Zombie Corner Box");
                    SETT.noWeaponBob = GUILayout.Toggle(SETT.noWeaponBob, "No Weapon Bob");
                }
                GUILayout.EndVertical();
            }GUILayout.EndHorizontal();




            GUI.DragWindow();
        }
        private void Menu2()
        {
            GUILayout.BeginHorizontal(GUI.skin.box);
            {
                ScrollMenu2 = GUILayout.BeginScrollView(scrollPosition1);
                {
                    GUILayout.BeginVertical();
                    {
                        SETT.CmDm = CGUILayout.Toggle(SETT.CmDm, "Creative/Debug Mode");//toggle on/off bool
                        SETT.TESTTOG = CGUILayout.Toggle(SETT.TESTTOG, "TESTTOG");
                       
                        SETT.drpbp = CGUILayout.Toggle(SETT.drpbp, "drpbkssdffsdfsdrfsfsd");//toggle on/off bool
                        SETT.speed = CGUILayout.Toggle(SETT.speed, "speed");//toggle on/off bool
                        SETT.speed = CGUILayout.Toggle(SETT.speed, "Game speed");//toggle on/off bool
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
                    }
                    GUILayout.EndVertical();

                    GUILayout.BeginVertical();
                    {
                        if (CGUILayout.Button("CONSOLEPRINT"))
                        {
                            Cheat.SOMECONSOLEPRINTOUT();
                        }

                        if (GUILayout.Button("Close gameobject"))
                        {
                            SETT.selfDestruct = true;
                        }
                        CGUILayout.Button(ref SETT._QuickScrap, "Quick scrap", Color.green, Color.red);


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
                    }
                    GUILayout.EndVertical();

                } GUILayout.EndScrollView();

  
                
            }GUILayout.EndHorizontal();
            GUI.DragWindow();
            
        } //DEbug stuff
        private void Menu3()
        {
            GUILayout.BeginVertical(GUI.skin.box);
            {
                ScrollMenu3 = GUILayout.BeginScrollView(ScrollMenu3);
                {
                    foldout1 = CGUILayout.FoldableMenuHorizontal(foldout1, "Foldable Menu 1", () =>
                    {  // Content to show when the foldout is open for Foldable Menu 1
                       // Add your UI elements here...


                        GUILayout.BeginVertical(GUI.skin.box);
                        { // Start a vertical layout group for the label and horizontal layout
                            GUILayout.Label("L1 Content for Menu 2", centeredLabelStyle); //Label for the menu
                            GUILayout.BeginHorizontal();
                            {
                                GUILayout.BeginVertical(GUILayout.MaxWidth(50));
                                {
                                    GUILayout.Label("DMG Multiply " + SETT._dmg.ToString("F2"));
                                }
                                GUILayout.EndVertical();
                                GUILayout.BeginVertical();
                                {
                                    SETT._dmg = GUILayout.HorizontalScrollbar(SETT._dmg, 0.1f, 0f, 300f);
                                }
                                GUILayout.EndVertical();

                                
                                
                            }
                            GUILayout.EndHorizontal();
                            GUILayout.BeginHorizontal(customBoxStyleGreen);
                            {
                                
                                GUILayout.BeginVertical();
                                {
                                    GUILayout.Label("side left", centeredLabelStyle);
                                }
                                GUILayout.EndVertical();
                                GUILayout.BeginVertical();
                                {

                                }
                                GUILayout.EndVertical();
                            }
                            GUILayout.EndHorizontal();
                        }
                        GUILayout.EndVertical();
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

                                    CGUILayout.Button(ref SETT._oneHit, "One hit block", Color.green, Color.red, Color.yellow);//button toggle bool
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
                                    if (O.zombieList.Count > 1)
                                    {
                                        foreach (EntityZombie zombie in O.zombieList)
                                        {
                                            if (!zombie || zombie == O.localPlayer || !zombie.IsAlive())
                                            {
                                                continue;
                                            }

                                            if (GUILayout.Button(zombie.EntityName))
                                            {
                                                //O.localPlayer.TeleportToPosition(zombie.GetPosition());
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
                                GUILayout.EndScrollView();
                            }
                            GUILayout.EndVertical();
                            GUILayout.BeginVertical("Teleport", GUI.skin.box);
                            {
                                GUILayout.Space(20f);

                                scrollPlayer = GUILayout.BeginScrollView(scrollPlayer, GUILayout.MaxWidth(300f));
                                {

                                    if (O.PlayerList.Count > 1)
                                    {
                                        foreach (EntityPlayer player in O.PlayerList)
                                        {
                                            if (!player || player == O.localPlayer || !player.IsAlive())
                                            {
                                                continue;
                                            }

                                            if (GUILayout.Button(player.EntityName))
                                            {
                                                O.localPlayer.TeleportToPosition(player.GetPosition());
                                            }
                                        }
                                    }
                                    else
                                    {
                                        GUILayout.Label("No players found.");
                                    }
                                }
                                GUILayout.EndScrollView();
                            }
                            GUILayout.EndVertical();

                            //GUILayout.Label("L2 Content for Menu 2", centeredLabelStyle); //here are all the items placed
                            GUILayout.BeginVertical("buffs", GUI.skin.box);
                            {
                                GUILayout.Space(20f);

                                GUILayout.BeginVertical();
                                {
                                    if (CGUILayout.Button("RELOAD BUFFS"))
                                    {
                                        O.buffClasses = O.GetAvailableBuffClasses();
                                        //BuffManager.Buffs.Clear(); Removed all buffs from runtime
                                    }
                                    if (CGUILayout.Button("Buffs.ActiveBuffs.Clear() Empty"))
                                    {
                                        //O.localPlayer.Buffs.ActiveBuffs.Clear();
                                    }
                                    if (CGUILayout.Button("Remove All Active Buffs"))
                                    {
                                        O.localPlayer.Buffs.RemoveBuffs(); //clears current buffs
                                    }
                                    if (CGUILayout.Button("Debug"))
                                    {
                                        float watrFLT = O.localPlayer.Buffs.GetCustomVar("$waterAmount");
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
                                       

                                        //    float _originalValue = 0f;
                                        //    float num = 1f;
                                        //    //O.localPlayer.Buffs.ActiveBuffs.Clear();
                                        //    //O.localPlayer.Buffs.AddBuff();
                                        //    O.localPlayer.Buffs.ModifyValue(PassiveEffects.None, ref _originalValue, ref num, default(FastTags));

                                        //    //EntityStats.Entity.Buffs.GetCustomVar("$waterAmount", 0f));
                                        //    //O.localPlayer.Buffs.RemoveBuffs();
                                        //    //O.localPlayer.Buffs.GetCustomVar("$waterAmount");
                                        //}
                                    


                                }
                                GUILayout.EndVertical();
                                GUILayout.BeginHorizontal(customBoxStyleGreen);
                                {
                                    //GUILayout.BeginVertical();
                                    //{
                                    //}GUILayout.EndVertical();
                                }
                                GUILayout.EndHorizontal();

                                scrollBuff2 = GUILayout.BeginScrollView(scrollBuff2, GUILayout.MaxWidth(250f), GUILayout.Width(250f), GUILayout.Height(200f));
                                {
                                    if (O.localPlayer != null)
                                    {
                                        if (O.buffClasses.Count > 0)
                                        {
                                           // int currentIndex = 0;
                                            //Log.Out(O.buffClasses.Count.ToString());
                                            foreach (BuffClass buffClass in O.buffClasses)
                                            {
                                                // Log.Out(currentIndex.ToString());
                                                //Log.Out(buffClass.Name);
                                                // se GUILayout.Button to create a button for each buff name
                                                if (GUILayout.Button(buffClass.Name))
                                                {

                                                    //EntityBuffs.BuffStatus buffStatus =
                                                    O.localPlayer.Buffs.AddBuff(buffClass.Name, -1, true, false, false, 20000000000f);
                                                    //Logic when the button is clicked
                                                }
                                                //currentIndex++;
                                                //if (currentIndex == O.buffClasses.Count - 1)
                                                //{
                                                //    Log.Out(currentIndex.ToString());
                                                //    lastBuffAdded = true;
                                                //}

                                                if (lastBuffAdded)
                                                {
                                                    break;
                                                }
                                                
                                                //int numC = O.buffClasses.Count;

                                                //if (buffClass.Name.Equals(O.buffClasses[O.buffClasses.Count - 1].Name))
                                                //{
                                                //    string str = O.buffClasses[O.buffClasses.Count - 1].Name;
                                                //    Log.Out(str);
                                                    
                                                //    //lastBuffAdded = true;
                                                //}


                                 
                                                
                                            }

                                        }
                                        else
                                        {
                                            GUILayout.Label("No buffs found.");
                                           
                                        }
                                        
                                    }
                                    else
                                    {
                                        GUILayout.Label("Not ingame");
                                    }
                                }
                                GUILayout.EndScrollView();

                              

                                GUILayout.BeginHorizontal(customBoxStyleGreen);
                                {




                                    //GUILayout.BeginVertical();
                                    //{

                                    //}GUILayout.EndVertical();
                                }
                                GUILayout.EndHorizontal();
                            }
                            GUILayout.EndVertical();
                        }
                        GUILayout.EndVertical();
                    }, 300f);
                    foldout4 = CGUILayout.FoldableMenuHorizontal(foldout4, "Foldable Menu 4 Some Stat Buffs", () =>
                    {  // Content to show when the foldout is open for Foldable Menu 1
                       // Add your UI elements here...


                        GUILayout.BeginVertical(GUI.skin.box);
                        { // Start a vertical layout group for the label and horizontal layout
                            GUILayout.Label("L1 Content for Menu 2", centeredLabelStyle); //Label for the menu
                            GUILayout.BeginHorizontal(customBoxStyleGreen);
                            {
                                //GUILayout.Label("L2 Content for Menu 2", centeredLabelStyle); //here are all the items placed
                                GUILayout.BeginVertical(customBoxStyleGreen);
                                {
                                    GUILayout.Button("Add skillpoints");
                                    O.localPlayer.Stats.Stamina.Value += 999f;

                                }
                                GUILayout.EndVertical();
                                GUILayout.BeginVertical(customBoxStyleGreen);
                                {

                                }
                                GUILayout.EndVertical();
                            }
                            GUILayout.EndHorizontal();
                        }
                        GUILayout.EndVertical();
                    }, 300f);
                    foldout5 = CGUILayout.FoldableMenuHorizontal(foldout5, "Foldable Menu 5", () =>
                    {


                        GUILayout.BeginVertical(GUI.skin.box);
                        {
                            // Start a vertical layout group for the label and horizontal layout        
                            GUILayout.Label("L1 Content for Menu 5", centeredLabelStyle); //Label for the menu
                            GUILayout.BeginHorizontal(customBoxStyleGreen);
                            {
                                GUILayout.BeginVertical(GUI.skin.box);
                                {


                                    GUILayout.Label("EXPERIMENTAL ", centeredLabelStyle);
                                    SETT.aimbot = GUILayout.Toggle(SETT.aimbot, "Aimbot (L-alt)");
                                    SETT.magicBullet = GUILayout.Toggle(SETT.magicBullet, "Magic Bullet(L-alt");


                                }
                                GUILayout.EndVertical();
                                GUILayout.BeginVertical(GUI.skin.box);
                                {


                                    GUILayout.Label("L4 Content for Menu ", centeredLabelStyle); //here are all the items placed
                                                                                                 //>-

                                }
                                GUILayout.EndVertical();

                            }
                            GUILayout.EndHorizontal();

                        }
                        GUILayout.EndVertical();

                    }, 300f);
                }
                GUILayout.EndScrollView();
            }GUILayout.EndVertical();
            
            GUILayout.BeginHorizontal();
            {
                GUILayout.BeginVertical();
                {

                }GUILayout.EndVertical();
            }GUILayout.EndHorizontal();
            GUI.DragWindow();
        }
    }
}


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