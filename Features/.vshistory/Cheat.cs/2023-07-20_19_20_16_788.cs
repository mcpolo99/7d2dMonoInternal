﻿using System;
using System.Runtime.InteropServices;
using UnityEngine;
using SETT = SevenDTDMono.Settings;
using Eutl = SevenDTDMono.ESPUtils;
using O = SevenDTDMono.Objects;
using System.Collections.Generic;
using Platform;


namespace SevenDTDMono
{
    public class Cheat : MonoBehaviour {
        //[DllImport("user32.dll")]
        //private static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);


        public static Color _col = Color.blue;
        //public bool ShowOnHUD = true;

        public void OnHud()
        {

        }
        private void Start() 
        {
        }



        private void Update() {

            if (SETT.noWeaponBob && O.localPlayer) {
                vp_FPWeapon weapon = O.localPlayer.vp_FPWeapon;

                if (weapon) {
                    weapon.BobRate = Vector4.zero;
                    weapon.ShakeAmplitude = Vector3.zero;
                    weapon.RenderingFieldOfView = 120f;
                    weapon.StepForceScale = 0f;
                }
            }//no weapon bob

            if (Input.GetKeyDown(KeyCode.O)) //infinity ammo ???
            {
                if (!O.localPlayer) {
                    return;
                }

                Inventory inventory = O.localPlayer.inventory;

                if (inventory != null) 
                {
                    ItemActionAttack gun = inventory.GetHoldingGun();

                    if (gun != null) {
                        gun.InfiniteAmmo = !gun.InfiniteAmmo;
                    }
                }
            }//infinity ammo

            if (Input.GetKeyDown(KeyCode.F3))
            {
                if (O.localPlayer)
                {
                    int _v = 999999;
                    O.localPlayer.Health += 9999999;
                    O.localPlayer.AddHealth(_v);
                    O._entityplayer.classMaxHealth += _v;
                }
            }//random

            if (SETT.cm)
            {
                var _value = SETT.cm;
                GameStats.Set(EnumGameStats.ShowSpawnWindow, _value);
                GameStats.Set(EnumGameStats.IsCreativeMenuEnabled, _value);
                GamePrefs.Set(EnumGamePrefs.DebugMenuEnabled, _value);
               // GameStats.Set(EnumGameStats.ShowAllPlayersOnMap, SETT.cmDm);
                //GameStats.Set(EnumGameStats.CraftTimer, !SETT.cmDm);
            }


            if (SETT.cmDm || !SETT.cmDm)
            {
                TogCmDm();
            }//worjing like a sharm

            if (SETT.speed )
            {
                SETT.speed = !SETT.speed;

                Time.timeScale = SETT.speed ? 6f : 1f;
            }

            if (SETT._trystackitems == true)
            {
                
                if (!O.localPlayer)
                {
                    return;
                }

                Inventory inventory = O.localPlayer.inventory;
                if (inventory != null)
                {
                    

                    //if ()1
                    {
                 
                    }
                }


            }
            #region
            //if (SETT.cmDm)
            //{
            //    Debug.developerConsoleVisible = true;

            //    Console.WriteLine("THIS IS WRITE LINE" + SETT.cmDm);
            //    Debug.LogWarning($"Debug <color={_col}>LogWarnig</color> for cmDm: " + SETT.cmDm);
            //    Debug.LogError($"Debug <color={_col}>LogError</color> for cmDm: " + SETT.cmDm);
            //    Debug.Log($"Debug <color={_col}>Log</color> for cmDm: " +SETT.cmDm);
            //    print($"This is a <color={_col}_col>Print Message</color> for cmDm: " + SETT.cmDm);
            //    //Debug.developerConsoleVisible = true;
            //    GameSparks.Platforms.DefaultPlatform.print("This is Actually the <color=green>INF/Print </color> console out for cmDm: " + SETT.cmDm);

            //}
            //if (SETT.cm)
            //{
            //    var _type = "SETT.cm";
            //    Debug.developerConsoleVisible= true;
            //    Console.WriteLine("THIS IS WRITE LINE" + _type);
            //    Debug.LogWarning($"Debug <color={_col}>LogWarnig</color> for {_type}: " + _type);
            //    Debug.LogError($"Debug <color={_col}>LogError</color> for {_type}: " + _type);
            //    Debug.Log($"Debug <color={_col}>Log</color> for {_type}: " + _type);
            //    print($"This is a <color={_col}_col>Print Message</color> for {_type}: " + _type);
            //    //Debug.developerConsoleVisible = true;
            //    GameSparks.Platforms.DefaultPlatform.print($"This is Actually the <color=green>INF/Print </color> console out for {_type} +cm+: " + _type);

            //}

            #endregion
        }

        void OnGUI()
        {

        }

        public static void TogCmDm()
        {
            GameStats.Set(EnumGameStats.ShowSpawnWindow, SETT.cmDm);
            GameStats.Set(EnumGameStats.IsCreativeMenuEnabled, SETT.cmDm);
            GamePrefs.Set(EnumGamePrefs.DebugMenuEnabled, SETT.cmDm);
        } 

        public static void CreativeMode()  //Creative and debug mode -- toggle
        {



        }

        public static void levelup()
        {
            if (O.localPlayer)
            {
                Progression prog = O.localPlayer.Progression;
                prog.AddLevelExp(prog.ExpToNextLevel);

            }


        }//up one level --button
        public static void skillpoints()
        {
            if (O.localPlayer)
            {
                Progression prog = O.localPlayer.Progression;
                prog.SkillPoints += 10;
            }
        }//add skillpoints -- buttoon
        public static void tp()
        {
            //O.local
        }
        public static void dropbkp()
        {

        }//no drop on death -- toggle
        public static void onehitkill()
        {

        }//one hit kill --Toggle

        public static void onehitbreak()
        {

        }//one hitt break block --Toggle
        public static void DEbugoutCM()  //Creative and debug mode -- toggle
        {

            string _type = "SETT.cm";
            var _value = SETT.cm;
            Debug.developerConsoleVisible = true;
            Console.WriteLine("THIS IS WRITE LINE" + _type);
            Debug.LogWarning($"Debug <color=_col>LogWarnig</color> for {_type}: " + _value);
            Debug.LogError($"Debug <color=_col>LogError</color> for {_type}: " + _value);
            Debug.Log($"Debug <color=_col>Log</color> for {_type}: " + _type);
            print($"This is a <color=_col_col>Print Message</color> for {_type}: " + _value);
            //Debug.developerConsoleVisible = true;
            GameSparks.Platforms.DefaultPlatform.print($"This is Actually the <color=green>INF/Print </color> console out for {_type} +cm+: " + _value);
            Log.Out("BYYYYY");


        }
        public static void DEbugoutCMDM()  //Creative and debug mode -- toggle
        {

            string _type = "SETT.cmDm";
            var _value = SETT.cmDm;
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
    }
}