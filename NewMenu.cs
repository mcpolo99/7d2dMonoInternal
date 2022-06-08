
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;
using O = SevenDTD_mono.Objects;


namespace SevenDTD_mono
{
    public class NewMenu : MonoBehaviour
    {

        public int _group = 0;
        string[] CheatsString = { "Menu1","Menu2","Menu3" };
        private bool drawMenu = true;
        private int windowID;
        private Rect windowRect;
        private Rect guiRect;
        private bool cmDm;
        private Vector2 scrollPosition;


        // Start is called before the first frame update
        void Start()
        {
            windowID = new System.Random(Environment.TickCount).Next(1000, 65535);
            windowRect = new Rect(200f, 200f, 300f, 300f);
            guiRect = new Rect(0, 0, 300, 300);

        }

        // Update is called once per frame
        void Update()
        {
            if (!Input.anyKey || !Input.anyKeyDown)
            {
                return;
            }

            if (Input.GetKeyDown(KeyCode.F11))
            {
                drawMenu = !drawMenu;
            }
        }
        private void OnGUI()
        {
            if (drawMenu)
            {
                windowRect = GUILayout.Window(windowID, windowRect, Window, "Menu");
            }
        }

     
        private void Window(int windowID)
        {
            _group = GUILayout.Toolbar(_group, CheatsString);

            switch (_group)
            {
                case 0:
                    Menu1();
                    break;
                case 1:
                    Menu2();
                    break;
                case 2:
                    Menu3();
                    break;

            }
            GUILayout.Space(10f);
        }

        private void Menu1()
        {
            GUILayout.BeginHorizontal();
            GUILayout.BeginVertical();
            if(GUILayout.Toggle( Cheat.onht ,"one hit kill"))
            {
            }
            if (GUILayout.Toggle(Cheat.drpbp, "hey"))
            {
            }
            if (GUILayout.Button("One hit kill"))
            {
            }
            if (GUILayout.Button("Level Up"))
            {
                Cheat.levelup();
            }
            if (GUILayout.Button("Add skillpoints"))
            {
                Cheat.skillpoints();
            }
            Cheat.drpbp = GUILayout.Toggle(Cheat.drpbp, "drpbk");
            Cheat.speed = GUILayout.Toggle(Cheat.speed, "speed");

            GUILayout.Button("One hit block");
            GUILayout.EndVertical();
            GUILayout.BeginVertical();
            if(GUILayout.Button("Creative mode"))
            {
                Cheat.ToggleCmDm();
            };
            GUILayout.Toggle(Cheat.cmDm,"toggke cheat mode.");
            Cheat.cmDm = GUILayout.Toggle(Cheat.cmDm,"toggke cheat mode.");
            GUILayout.Button("Quick melt");
            GUILayout.Button("Quick scrap");
            GUILayout.Button("Instant loot");
            {

            }
            GUILayout.EndVertical();
            GUILayout.EndHorizontal();
            GUI.DragWindow();
        }

        private void Menu2() //esp stuff
        {

            //ESP STUFF

            GUILayout.Label(MakeEnable("[F2] Speed ", Cheat.speed));
            GUILayout.BeginHorizontal();
            GUILayout.BeginVertical();
            GUILayout.Button("2");
            GUILayout.Button("2");
            GUILayout.Button("2");
            GUILayout.Button("2");
            ESP.crosshair = GUILayout.Toggle(ESP.crosshair, "Crosshair");
            ESP.fovCircle = GUILayout.Toggle(ESP.fovCircle, "Draw FOV");
            ESP.playerBox = GUILayout.Toggle(ESP.playerBox, "Player Box");
            ESP.playerName = GUILayout.Toggle(ESP.playerName, "Player Name");
            ESP.playerHealth = GUILayout.Toggle(ESP.playerHealth, "Player Health");
            GUILayout.EndVertical();
            GUILayout.BeginVertical();
            GUILayout.Button("2");
            GUILayout.Button("2");
            GUILayout.Button("2");
            GUILayout.Button("2");
            ESP.zombieBox = GUILayout.Toggle(ESP.zombieBox, "Zombie Box");
            ESP.zombieName = GUILayout.Toggle(ESP.zombieName, "Zombie Name");
            ESP.zombieHealth = GUILayout.Toggle(ESP.zombieHealth, "Zombie Health");
            ESP.playerCornerBox = GUILayout.Toggle(ESP.playerCornerBox, "Player Corner Box");
            ESP.zombieCornerBox = GUILayout.Toggle(ESP.zombieCornerBox, "Zombie Corner Box");
            GUILayout.EndVertical();
            GUILayout.EndHorizontal();
            Cheat.noWeaponBob = GUILayout.Toggle(Cheat.noWeaponBob, "No Weapon Bob");
            Cheat.aimbot = GUILayout.Toggle(Cheat.aimbot, "Aimbot (L-alt)");
            Cheat.magicBullet = GUILayout.Toggle(Cheat.magicBullet, "Magic Bullet(L-alt");
            Cheat.chams = GUILayout.Toggle(Cheat.chams, "Chams");

            //
            GUILayout.BeginVertical("Teleport");
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

        }
        private void Menu3()
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
