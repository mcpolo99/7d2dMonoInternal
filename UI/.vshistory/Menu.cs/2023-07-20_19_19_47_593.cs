using System;
using System.Runtime.InteropServices;
using UnityEngine;
using SETT = SevenDTDMono.Settings;
using Eutl = SevenDTDMono.ESPUtils;
using O = SevenDTDMono.Objects;

namespace SevenDTDMono{
    public class Menu : MonoBehaviour 
    {
        private void Start() {
            windowID = new System.Random(Environment.TickCount).Next(1000, 65535);
            windowRect = new Rect(5f, 5f, 300f, 150f);
        }

        private void Update() {
            if (!Input.anyKey || !Input.anyKeyDown) {
                return;
            }

            if (Input.GetKeyDown(KeyCode.Delete)) {
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

        private void ToggleCmDm() {
            GameStats.Set(EnumGameStats.ShowSpawnWindow, cmDm);
            GameStats.Set(EnumGameStats.IsCreativeMenuEnabled, cmDm);
            GamePrefs.Set(EnumGamePrefs.DebugMenuEnabled, cmDm);
        }

        private void Window(int windowID) {
            GUILayout.Label(MakeEnable("[F2] Speed ", SETT.speed));
            //GUILayout.Label("[O] Toggle Infinite Ammo");
            
            if (GUILayout.Button("Toggle Creative & Debug Mode")) {
                cmDm = !cmDm;

                ToggleCmDm();
            }

            if (GUILayout.Button("Level Up")) {
                if (O.localPlayer) {
                    Progression prog = O.localPlayer.Progression;
                    prog.AddLevelExp(prog.ExpToNextLevel);
                }
            }

            if (GUILayout.Button("Add 10 Skill Points")) {
                if (O.localPlayer) {
                    Progression prog = O.localPlayer.Progression;
                    prog.SkillPoints += 10;
                }
            }

           /* GUILayout.Toggle(Cheat.Levelup, "test");
            {
                Cheat.Levelup
            }/*/



            GUILayout.BeginVertical("Options", GUI.skin.box); {
                GUILayout.Space(20f);

                GUILayout.BeginHorizontal();
                {
                    SETT.magicBullet = GUILayout.Toggle(SETT.magicBullet, "Magic Bullet");
                    SETT.chams = GUILayout.Toggle(SETT.chams, "Chams");
                }
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                {
                    SETT.noWeaponBob = GUILayout.Toggle(SETT.noWeaponBob, "No Weapon Bob");
                    SETT.aimbot = GUILayout.Toggle(Settings.aimbot, "Aimbot");
                }
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal(); 
                {
                    SETT.crosshair = GUILayout.Toggle(SETT.crosshair, "Crosshair");
                    SETT.fovCircle = GUILayout.Toggle(SETT.fovCircle, "Draw FOV");
                } GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                {
                    SETT.playerBox = GUILayout.Toggle(SETT.playerBox, "Player Box");
                    SETT.playerName = GUILayout.Toggle(SETT.playerName, "Player Name");
                }
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                {
                    SETT.playerHealth = GUILayout.Toggle(SETT.playerHealth, "Player Health");
                    SETT.zombieBox = GUILayout.Toggle(SETT.zombieBox, "Zombie Box");
                }
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                {
                    SETT.zombieName = GUILayout.Toggle(SETT.zombieName, "Zombie Name");
                    SETT.zombieHealth = GUILayout.Toggle(SETT.zombieHealth, "Zombie Health");
                }
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                {
                    SETT.playerCornerBox = GUILayout.Toggle(SETT.playerCornerBox, "Player Corner Box");
                    SETT.zombieCornerBox = GUILayout.Toggle(SETT.zombieCornerBox, "Zombie Corner Box");
                }
                GUILayout.EndHorizontal();
            } GUILayout.EndVertical();

            GUILayout.BeginVertical("Teleport", GUI.skin.box); {
                GUILayout.Space(20f);

                scrollPosition = GUILayout.BeginScrollView(scrollPosition, GUILayout.MaxWidth(300f)); {
                    if (O.PlayerList.Count > 1) {
                        foreach (EntityPlayer player in O.PlayerList) {
                            if (!player || player == O.localPlayer || !player.IsAlive()) {
                                continue;
                            }

                            if (GUILayout.Button(player.EntityName)) {
                                O.localPlayer.TeleportToPosition(player.GetPosition());
                            }
                        }
                    } else {
                        GUILayout.Label("No players found.");
                    }
                } GUILayout.EndScrollView();
            } GUILayout.EndVertical();

            GUI.DragWindow();
        }

        private string MakeEnable(string label, bool toggle) {
            string status = toggle ? "<color=green>ON</color>" : "<color=red>OFF</color>";
            return $"{label} {status}";
        }

        private bool drawMenu = false;
        private bool cmDm;

        private int windowID;
        private Rect windowRect;
        private Vector2 scrollPosition;
    }
}
