
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


        private Vector2 scrollPosition;
        private Vector2 scrollPosition1 = Vector2.zero;
        private Vector2 ScrollMenu3 = Vector2.zero;
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
        private float floatValue = 0.0f;
        private GUIStyle customBoxStyleGreen;
        GUIStyle centeredLabelStyle;





        // Start is called before the first frame update
        void Start()
        {
            windowID = new System.Random(Environment.TickCount).Next(1000, 65535);
            windowRect = new Rect(10f, 10f, 300f, 300f);
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
            customBoxStyleGreen.normal.background = MakeTexture(2, 2, new Color(1f, 0f, 0f, 0.5f));
            customBoxStyleGreen.border = new RectOffset(2, 2, 2, 2);


            GUIStyle centeredLabelStyle = new GUIStyle(GUI.skin.label);
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
            _group = CGUILayout.Toolbar(_group, CheatsString, GUI.skin.box); //creating the group for switch comand    
            
       
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

        private void Menu0()
        {
            //
            GUILayout.BeginHorizontal();

            GUILayout.BeginVertical(GUI.skin.box, GUILayout.MaxWidth(300f));
            scrollPosition1 = GUILayout.BeginScrollView(scrollPosition1);
            GUILayout.Label("DMG Multiply " + SETT._dmg.ToString("F2"));
            SETT._dmg = GUILayout.HorizontalScrollbar(SETT._dmg, 0.1f, 0f, 300f);
            //GUILayout.HorizontalScrollbar(SETT._dmg, 200f, 0f, 200f);
            if (CGUILayout.Button("Level Up"))
            {
                Cheat.levelup();
            }
            if (CGUILayout.Button("Add skillpoints") )
            { 
                Cheat.skillpoints();
            }
            if (CGUILayout.Button("CONSOLEPRINT"))
            {
                Cheat.SOMECONSOLEPRINTOUT();
            }
            if (CGUILayout.Button("Kill")) 
            {
                Cheat.Kill();
            }

            CGUILayout.Button(ref SETT.TESTTOG,"Instant loot",Color.green,Color.red);
            CGUILayout.Button("Quick melt");

            CGUILayout.Button(ref SETT._QuickScrap, "Quick scrap",Color.green,Color.red);
            CGUILayout.Button(ref SETT._oneHit,"One hit block",Color.green,Color.red,Color.yellow);//button toggle bool
            SETT.drpbp = CGUILayout.Toggle(SETT.drpbp, "drpbkssdffsdfsdrfsfsd");//toggle on/off bool
            SETT.speed = CGUILayout.Toggle(SETT.speed, "speed");//toggle on/off bool
            SETT.speed = CGUILayout.Toggle(SETT.speed, "Game speed");//toggle on/off bool
            SETT.CmDm = CGUILayout.Toggle(SETT.CmDm, "Creative/Debug Mode");//toggle on/off bool
            SETT.TESTTOG = CGUILayout.Toggle(SETT.TESTTOG, "TESTTOG");
            SETT.crosshair = GUILayout.Toggle(SETT.crosshair, "Crosshair");
            SETT.fovCircle = GUILayout.Toggle(SETT.fovCircle, "Draw FOV");
            SETT.playerBox = GUILayout.Toggle(SETT.playerBox, "Player Box");
            SETT.playerName = GUILayout.Toggle(SETT.playerName, "Player Name");
            SETT.playerHealth = GUILayout.Toggle(SETT.playerHealth, "Player Health");
            SETT._Buffs = CGUILayout.Toggle(SETT._Buffs, "Buffs");


            GUILayout.EndScrollView();
            //------------------------------------------------------------------------------
            GUILayout.EndVertical();
            GUILayout.BeginVertical(GUI.skin.box);
            GUILayout.BeginHorizontal();
            ///////////------------------------------------------------------------------------------
          
            GUILayout.EndHorizontal();

            //GUILayout.Label( SETT.BOOLText.text = SETT.cm.ToString() ,$"{SETT.BOOLText.text}");

            //
            GUILayout.EndVertical();
            GUILayout.EndHorizontal();
            GUI.DragWindow();
            //
        }

        private void Menu1() //esp stuff
        {

            //ESP STUFF
            GUILayout.BeginHorizontal(GUI.skin.box);
            GUILayout.BeginVertical();
            //GUILayout.Button("2222");
            //GUILayout.Button("2");
            //GUILayout.Button("2");
            //GUILayout.Button("2");
      

            GUILayout.EndVertical();
            GUILayout.BeginVertical();
            //GUILayout.Button("2");
            //GUILayout.Button("2");
            //GUILayout.Button("2");
            //GUILayout.Button("2");
            SETT.zombieBox = GUILayout.Toggle(SETT.zombieBox, "Zombie Box");
            SETT.zombieName = GUILayout.Toggle(SETT.zombieName, "Zombie Name");
            SETT.zombieHealth = GUILayout.Toggle(SETT.zombieHealth, "Zombie Health");
            SETT.playerCornerBox = GUILayout.Toggle(SETT.playerCornerBox, "Player Corner Box");
            SETT.zombieCornerBox = GUILayout.Toggle(SETT.zombieCornerBox, "Zombie Corner Box");
            GUILayout.EndVertical();
            GUILayout.EndHorizontal();
            SETT.noWeaponBob = GUILayout.Toggle(SETT.noWeaponBob, "No Weapon Bob");
            SETT.aimbot = GUILayout.Toggle(SETT.aimbot, "Aimbot (L-alt)");
            SETT.magicBullet = GUILayout.Toggle(SETT.magicBullet, "Magic Bullet(L-alt");
            SETT.chams = GUILayout.Toggle(SETT.chams, "Chams");



            GUILayout.BeginVertical("Kill", GUI.skin.box);
            {
                GUILayout.Space(20f);

                scrollPosition = GUILayout.BeginScrollView(scrollPosition, GUILayout.MaxWidth(300f));
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
                                O.localPlayer.TeleportToPosition(zombie.GetPosition());
                            }
                        }
                    }
                    //if (O.PlayerList.Count > 1)
                    //{
                    //    foreach (EntityPlayer player in O.PlayerList)
                    //    {
                    //        if (!player || player == O.localPlayer || !player.IsAlive())
                    //        {
                    //            continue;
                    //        }

                    //        if (GUILayout.Button(player.EntityName))
                    //        {
                    //            O.localPlayer.TeleportToPosition(player.GetPosition());
                    //        }
                    //    }
                    //}
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

                scrollPosition = GUILayout.BeginScrollView(scrollPosition, GUILayout.MaxWidth(300f));
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
            #region
            //
            //GUILayout.BeginVertical("Teleport");
            //{
            //    GUILayout.Space(20f);

            //    scrollPosition = GUILayout.BeginScrollView(scrollPosition, GUILayout.MaxWidth(300f));
            //    {
            //        if (O.PlayerList.Count > 1)
            //        {
            //            foreach (EntityPlayer player in O.PlayerList)
            //            {
            //                if (!player || player == O.localPlayer || !player.IsAlive())
            //                {
            //                    continue;
            //                }

            //                if (GUILayout.Button(player.EntityName))
            //                {
            //                    O.localPlayer.TeleportToPosition(player.GetPosition());
            //                }
            //            }
            //        }
            //        else
            //        {
            //            GUILayout.Label("No players found.");
            //        }
            //    }
            //    GUILayout.EndScrollView();
            //}
            //GUILayout.EndVertical();
            #endregion

        }
        private void Menu2()
        {
            GUILayout.BeginHorizontal(GUI.skin.box);
            GUILayout.BeginVertical();
            if (GUILayout.Button("xp-modifier"))
            {
            }
            if (GUILayout.Button("Label"))
            {
            }
            if (GUILayout.Button("PasswordField"))
            {
            }
            if (GUILayout.Button("TextField"))
            {
            }
            if (GUILayout.Button("Box"))
            {

            }
            if (GUILayout.Button("RepeatButton"))
            {

            }
            GUILayout.EndVertical();
            GUILayout.BeginVertical();

            if (GUILayout.Button("TextArea"))
            {

            }
            if (GUILayout.Button("HorizontalSlider"))
            {

            }
            if (GUILayout.Button("VerticalSlider"))
            {
            }
            if (GUILayout.Button("DrawTexture"))
            {

            }
            if (GUILayout.Button("Window"))
            {
            }
            if (GUILayout.Button("Toggle"))
            {
                    SETT.selfDestruct = true;
            }
            GUILayout.EndVertical();
            GUILayout.EndHorizontal();
        } //stats
        private void Menu3()
        {




            GUILayout.BeginVertical(GUI.skin.box, GUILayout.MaxWidth(300f));
            ScrollMenu3 = GUILayout.BeginScrollView(ScrollMenu3);
            foldout1 = CGUILayout.FoldableMenuHorizontal(foldout1, "Foldable Menu 1", () =>

            {
                // Content to show when the foldout is open for Foldable Menu 1
                // Add your UI elements here...
                GUILayout.BeginHorizontal();
                GUILayout.BeginVertical();
                GUILayout.Label("Content for Menu 1", centeredLabelStyle);
                SETT.crosshair = GUILayout.Toggle(SETT.crosshair, "Crosshair");
                SETT.fovCircle = GUILayout.Toggle(SETT.fovCircle, "Draw FOV");
                SETT.playerBox = GUILayout.Toggle(SETT.playerBox, "Player Box");
                GUILayout.EndVertical();
                GUILayout.BeginVertical();
                SETT.playerName = GUILayout.Toggle(SETT.playerName, "Player Name");
                SETT.playerHealth = GUILayout.Toggle(SETT.playerHealth, "Player Health");
                SETT._Buffs = CGUILayout.Toggle(SETT._Buffs, "Buffs");
                GUILayout.EndVertical();
                GUILayout.EndHorizontal();
            }, 300f);
            foldout2 = CGUILayout.FoldableMenuHorizontal(foldout2, "Foldable Menu 2", () =>
            {
                // Content to show when the foldout is open for Foldable Menu 1
                // Add your UI elements here...


                GUILayout.BeginVertical(GUI.skin.box); // Start a vertical layout group for the label and horizontal layout
                GUILayout.Label("L1 Content for Menu 2", centeredLabelStyle); //Label for the menu
                GUILayout.BeginHorizontal(customBoxStyleGreen);
                //<
                GUILayout.Label("L2 Content for Menu 2", centeredLabelStyle); //here are all the items placed
                GUILayout.BeginVertical();
                //-<
                SETT.crosshair = GUILayout.Toggle(SETT.crosshair, "Crosshair");
                SETT.fovCircle = GUILayout.Toggle(SETT.fovCircle, "Draw FOV");
                SETT.playerBox = GUILayout.Toggle(SETT.playerBox, "Player Box");
                //>-
                GUILayout.EndVertical();
                GUILayout.BeginVertical();
                //-<
                SETT.playerName = GUILayout.Toggle(SETT.playerName, "Player Name");
                SETT.playerHealth = GUILayout.Toggle(SETT.playerHealth, "Player Health");
                SETT._Buffs = CGUILayout.Toggle(SETT._Buffs, "Buffs");
                //>-
                GUILayout.EndVertical();
                //>
                GUILayout.EndHorizontal();
                GUILayout.EndVertical();
                


                //GUILayout.BeginHorizontal();
                //GUILayout.Label("Content for Menu 2");
                //GUILayout.EndHorizontal();





                //GUILayout.BeginHorizontal();
                //GUILayout.BeginVertical();
                /////

                //GUILayout.EndVertical();
                //GUILayout.BeginVertical();
                /////
                //GUILayout.EndVertical();
                //GUILayout.EndHorizontal();
            }, 300f);
            foldout3 = CGUILayout.FoldableMenuHorizontal(foldout3, "Foldable Menu 3", () =>
            {


                GUILayout.BeginVertical(GUI.skin.box); // Start a vertical layout group for the label and horizontal layout
                GUILayout.Label("L1 Content for Menu 3", centeredLabelStyle); //Label for the menu
                GUILayout.BeginHorizontal(customBoxStyleGreen);
                //<
                GUILayout.Label("L2 Content for Menu 3", centeredLabelStyle); //here are all the items placed
                GUILayout.BeginVertical();
                //-<

                //>-
                GUILayout.EndVertical();
                GUILayout.BeginVertical();
                //-<

                //>-
                GUILayout.EndVertical();
                //>
                GUILayout.EndHorizontal();
                GUILayout.EndVertical();
            }, 300f);
            foldout4 = CGUILayout.FoldableMenuHorizontal(foldout4, "Foldable Menu 4", () =>
            {


                GUILayout.BeginVertical(GUI.skin.box); // Start a vertical layout group for the label and horizontal layout
                GUILayout.Label("L1 Content for Menu 4", centeredLabelStyle); //Label for the menu
                GUILayout.BeginHorizontal(customBoxStyleGreen);
                //<
                GUILayout.Label("L2 Content for Menu 4", centeredLabelStyle); //here are all the items placed
                GUILayout.BeginVertical();
                //-<

                //>-
                GUILayout.EndVertical();
                GUILayout.BeginVertical();
                //-<

                //>-
                GUILayout.EndVertical();
                //>
                GUILayout.EndHorizontal();
                GUILayout.EndVertical();
            }, 300f);
            foldout5 = CGUILayout.FoldableMenuHorizontal(foldout5, "Foldable Menu 5", () =>
            {


                GUILayout.BeginVertical(GUI.skin.box); // Start a vertical layout group for the label and horizontal layout
                GUILayout.Label("L1 Content for Menu 5", centeredLabelStyle); //Label for the menu
                GUILayout.BeginHorizontal(customBoxStyleGreen);
                //<
                GUILayout.Label("L2 Content for Menu ", centeredLabelStyle); //here are all the items placed
                GUILayout.BeginVertical(GUI.skin.box);
                //-<

                //>-
                GUILayout.EndVertical();
                GUILayout.BeginVertical(GUI.skin.box);
                //-<

                //>-
                GUILayout.EndVertical();
                //>
                GUILayout.EndHorizontal();
                GUILayout.EndVertical();
            }, 300f);



            GUILayout.EndScrollView();
            GUILayout.EndVertical();

            GUILayout.BeginHorizontal();
            GUILayout.BeginVertical();
            //GUILayout.HorizontalSlider(10f,0f,50f);
           
            GUILayout.EndVertical();
            GUILayout.EndHorizontal();
        } //stats
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