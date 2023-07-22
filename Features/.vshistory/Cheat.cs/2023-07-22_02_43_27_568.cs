using System;
using System.Runtime.InteropServices;
using UnityEngine;
using SETT = SevenDTDMono.Settings;
using Eutl = SevenDTDMono.ESPUtils;
using O = SevenDTDMono.Objects;
using System.Collections.Generic;
using Platform;
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

        //[DllImport("user32.dll")]
        //private static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);
        //private float damageMultiplier = 1f;
        //public bool ShowOnHUD = true;




        #endregion
        //--------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------





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
        //--------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------
        #region onUpdate
        private void Update()
        {

            if (SETT.noWeaponBob && O.localPlayer) // When noWeaponBob is active enable 
            {
                vp_FPWeapon weapon = O.localPlayer.vp_FPWeapon;

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
                if (!O.localPlayer)
                {
                    return;
                }

                Inventory inventory = O.localPlayer.inventory;

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
                if (O.localPlayer)
                {
                    int _v = 999999;
                    O.localPlayer.Health += 9999999;
                    O.localPlayer.AddHealth(_v);
                    O._entityplayer.classMaxHealth += _v;

                 
                }
            }//random




            if (SETT.CmDm || !SETT.CmDm) //Toggle for ingame Creative and Debug Working like a sharm
            {
                CmDm();
            }
            if (SETT._Buffs || !SETT._Buffs) //Toggle for ingame Creative and Debug Working like a sharm
            {
                Buffs1();
            }
            if (SETT.speed)
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
        //--------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------
        #region Methods
        #region Triggers
        public static void KillSelf()
        {
          
             O.localPlayer.DamageEntity(new DamageSource(EnumDamageSource.Internal, EnumDamageTypes.Suicide), 99999, false, 1f);
            SingletonMonoBehaviour<SdtdConsole>.Instance.Output("Gave 99999 damage to entity " );
        }

        public static void levelup()//up one level-Trigger once
        {
            if (O.localPlayer)
            {
                Progression prog = O.localPlayer.Progression;
                prog.AddLevelExp(prog.ExpToNextLevel);

            }


        }

        public static void updatebuffall()
        {

            int num = O.localPlayer.Buffs.ActiveBuffs.Count;
            for (int i = 0; i < num; i++)
            {
                BuffValue buffValue = O.localPlayer.Buffs.ActiveBuffs[i];
                if (buffValue.Invalid)
                {
                    O.localPlayer.Buffs.ActiveBuffs.RemoveAt(i);
                    i--;
                    num--;
                }
                else
                {
                    BuffManager.UpdateBuffTimers(buffValue, 99999f);
                }

            }

        }
        public static void skillpoints()//add skillpoints - Trigger once
        {
            if (O.localPlayer)
            {
                Progression prog = O.localPlayer.Progression;
                prog.SkillPoints += 10;
            }
        }
        public static void IgnoredbyAI()
        {
            O.localPlayer.SetIgnoredByAI(!O.localPlayer.IsIgnoredByAI());
        }

        public static void SOMECONSOLEPRINTOUT()  //Creative and debug mode -- Trigger
        {

            string _type = "SETT.cmDm";
            var _value = O.localPlayer.DebugNameInfo;
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
        public static void CmDm() //Creative and DEbug - Toggle
        {
            string _SETT = "SETT.cm";
            var _value = SETT.cm;
            //Debug.LogWarning($"Debug <color=_col>LogWarnig</color> for {_SETT}: " + _value);
            GameStats.Set(EnumGameStats.ShowSpawnWindow, SETT.CmDm); // sets the GameStat to the value of CmDm
            GameStats.Set(EnumGameStats.IsCreativeMenuEnabled, SETT.CmDm);
            GamePrefs.Set(EnumGamePrefs.DebugMenuEnabled, SETT.CmDm);

            //if (SETT.cm) //updates to check if cm IS yet toggled. SETT.cm is toggled in NewMenu.Debug
            //{
            //    //var _value = SETT.cm;
            //    GameStats.Set(EnumGameStats.ShowSpawnWindow, _value);
            //    GameStats.Set(EnumGameStats.IsCreativeMenuEnabled, _value);
            //    GamePrefs.Set(EnumGamePrefs.DebugMenuEnabled, _value);

            //    // GameStats.Set(EnumGameStats.ShowAllPlayersOnMap, SETT.cmDm);
            //    //GameStats.Set(EnumGameStats.CraftTimer, !SETT.cmDm);
            //}
        }
        public static EntityAlive Entity;
        public static void HealthNStamina()
        {

            if (SETT._healthNstamina == true && O._entityplayerLocal != null)
            {
                O._entityplayerLocal.Stats.Water.RegenerationAmount += O._entityplayerLocal.Stats.Water.RegenerationAmount * EffectManager.GetValue(PassiveEffects.WaterGain, null, 1f, O._entityplayerLocal, null, default(FastTags), true, true, true, true, 1, true, false);
                O._entityplayerLocal.Stats.Food.RegenerationAmount += O._entityplayerLocal.Stats.Food.RegenerationAmount * EffectManager.GetValue(PassiveEffects.FoodGain, null, 1f, O._entityplayerLocal, null, default(FastTags), true, true, true, true, 1, true, false);
                O._entityplayerLocal.Stats.Health.RegenerationAmount += O._entityplayerLocal.Stats.Health.RegenerationAmount * EffectManager.GetValue(PassiveEffects.HealthGain, null, 1f, O._entityplayerLocal, null, default(FastTags), true, true, true, true, 1, true, false);
                O._entityplayerLocal.Stats.Stamina.RegenerationAmount += O._entityplayerLocal.Stats.Stamina.RegenerationAmount * EffectManager.GetValue(PassiveEffects.StaminaGain, null, 1f, O._entityplayerLocal, null, default(FastTags), true, true, true, true, 1, true, false);
            }
          
        }
        public static void Buffs1() //Sett Buffs on player - Toggle
        {
            if (O.localPlayer)
            {


                //if (RegenerationAmount > 0f)
                //{
                //    if (StatType == Stat.StatTypes.Stamina)
                //    {O.localPlayer.Stats.ResetStats();
                //        O.localPlayer.Stats.Water.RegenerationAmount += 20f * EffectManager.GetValue(PassiveEffects.WaterLossPerStaminaPointGained, null, 1f, Stat.Entity, null, default(FastTags), true, true, true, true, 1, true, false);
                //        O.localPlayer.Stats.Food.RegenerationAmount += 20f * EffectManager.GetValue(PassiveEffects.FoodLossPerStaminaPointGained, null, 1f, this.Entity, null, default(FastTags), true, true, true, true, 1, true, false);
                //    }
                //    else if (StatType == Stat.StatTypes.Health)
                //    {
                //        O.localPlayer.Stats.Water.RegenerationAmount -= 20f * EffectManager.GetValue(PassiveEffects.WaterLossPerHealthPointGained, null, 1f, O.localPlayer.Entity, null, default(FastTags), true, true, true, true, 1, true, false);
                //        O.localPlayer.Stats.Food.RegenerationAmount -= 20f* EffectManager.GetValue(PassiveEffects.FoodLossPerHealthPointGained, null, 1f, this.Entity, null, default(FastTags), true, true, true, true, 1, true, false);
                //    }
                //}
                int _V = 9999;
                O.localPlayer.AddHealth(_V);
                string staminamax = O.localPlayer.GetMaxStamina().ToString();
                string stammult = O.localPlayer.GetStaminaMultiplier().ToString();
                string hippos = O.localPlayer.getHipPosition().ToString();
                string maxhp = O.localPlayer.GetMaxHealth().ToString();
                //Debug.Log($"stamimax <color=_col>Log</color> for : " + staminamax);
                //Debug.Log($"multi <color=_col>Log</color> for : " + stammult);
                //Debug.Log($"hip <color=_col>Log</color> for : " + hippos);
                //Debug.Log($"MAxhp <color=_col>Log</color> for : " + maxhp);

                O.localPlayer.Stats.Water.BaseMax = 200f;
                O.localPlayer.Stats.Health.GainPassive += 90;
                O.localPlayer.Stats.Food.GainPassive += 10;

                O.localPlayer.AddStamina(_V);
                O.localPlayer.Stats.Stamina.Value += 999f;

            }
            else
            {
               // O._entityplayer.Stamina = 0;

            }
            //O.localPlayer.Buffs.ActiveBuffs.Add(BuffManager.Buffs.));
            //O.local
        }
        public static void dropbkp() //no drop on death -- toggle
        {

        }
        public static void onehitkill() //Sett one hit kill - Toggle
        {

        }

        public static void onehitbreak()   //one hit break - Toggle
        {

        }

        //one hitt break block --Toggle
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

        //--------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------
        #endregion
        #endregion
    }
}
