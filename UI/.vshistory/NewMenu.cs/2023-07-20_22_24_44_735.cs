
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;
using O = SevenDTDMono.Objects;
using SETT = SevenDTDMono.Settings;
using SevenDTDMono.Utils;


namespace SevenDTDMono
{
    public class NewMenu : MonoBehaviour
    {

        public int _group = 0;
        string[] CheatsString = { "Menu0", "Menu1", "Menu2" };
        private bool drawMenu = true;

        //private bool drawMenu = true;
        private int windowID;
        private Rect windowRect;
        private Rect guiRect;
        private Vector2 scrollPosition;
        public bool cmt;
        public string Text;
        public Text counterText;
        public float counter;
        //public ToggleColors toggleColors;







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
            }



        }


        private void OnGUI()
        {


            if (drawMenu)
            {
                windowRect = GUILayout.Window(windowID, windowRect, Window, "Menu"); //draws main menu
            }
            //SETT.CmDm = GUILayout.Toggle(SETT.CmDm, "Creative/Debug Mode", toggleStyle);
        }
       

        private void Window(int windowID)
        {
            _group = GUILayout.Toolbar(_group, CheatsString); //creating the group for switch comand    

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

                //case 3: //add more for more menu
                //    Menu3();
                //    break;


            }
            GUILayout.Space(10f);
            GUILayout.HorizontalScrollbar(SETT._dmg,200f,0f,200f);
        }

        private void Menu0()
        {
            //
            GUILayout.BeginHorizontal();
            GUILayout.BeginVertical();
            //

            if (GUILayout.Button("Level Up"))
            {
                Cheat.levelup();
            }//button execute
            if (GUILayout.Button("Add skillpoints") )
            { 
                Cheat.skillpoints();
            }//button execute
            if (GUILayout.Button("CONSOLEPRINT"))
            {
                //Cheat.SOMECONSOLEPRINTOUT();
            }//Btn exe
            GUILayout.Button("Instant loot");
            GUILayout.Button("Quick melt");
            GUILayout.Button("Quick scrap");
            GUILayout.Button("One hit block");//button toggle bool
            //------------------------------------------------------------------------------
            GUILayout.EndVertical();
            GUILayout.BeginVertical();
            //------------------------------------------------------------------------------


            SETT.drpbp = GUILayout.Toggle(SETT.drpbp, "drpbkssdffsdfsdrfsfsd");//toggle on/off bool
            SETT.speed = GUILayout.Toggle(SETT.speed, "speed");//toggle on/off bool
            SETT.speed = GUILayout.Toggle(SETT.speed, "Game speed");//toggle on/off bool
            SETT.CmDm = GUILayout.Toggle(SETT.CmDm, "Creative/Debug Mode");//toggle on/off bool
            SETT.TESTTOG = GUILayout.Toggle(SETT.TESTTOG,"TESTTOG");

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
            GUILayout.BeginHorizontal();
            GUILayout.BeginVertical();
            //GUILayout.Button("2222");
            //GUILayout.Button("2");
            //GUILayout.Button("2");
            //GUILayout.Button("2");
            SETT.crosshair = GUILayout.Toggle(SETT.crosshair, "Crosshair");
            SETT.fovCircle = GUILayout.Toggle(SETT.fovCircle, "Draw FOV");
            SETT.playerBox = GUILayout.Toggle(SETT.playerBox, "Player Box");
            SETT.playerName = GUILayout.Toggle(SETT.playerName, "Player Name");
            SETT.playerHealth = GUILayout.Toggle(SETT.playerHealth, "Player Health");
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
            GUILayout.BeginHorizontal();
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



        private string MakeEnable(string label, bool toggle)
        {
            string status = toggle ? "<color=green>ON</color>" : "<color=red>OFF</color>";
            return $"{label} {status}";
        }
    }


}
