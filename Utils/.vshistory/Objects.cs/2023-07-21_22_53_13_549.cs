using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static ImageEffectManager;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

namespace SevenDTDMono{
    public class Objects : MonoBehaviour {


        private void Start() {
           
            zombieList = new List<EntityZombie>();
            itemList = new List<EntityItem>();
            buffClasses = new List<BuffClass>();

            lastCachePlayer = Time.time + 5f;
            lastCacheZombies = Time.time + 3f;
            lastCacheItems = Time.time + 4f;
            lastCacheItems = Time.time + 1000f;
            //BuffClass buff = BuffManager.GetBuff(_name);
            gameManager = (GameManager)UnityEngine.Object.FindObjectOfType(typeof(GameManager));



            _entityplayer = FindObjectOfType<EntityPlayer>();
            _enumstats = GetComponent<EnumGameStats>();
            _playerinv = GetComponent<XUiM_PlayerInventory>();


            _buffClass = GetComponent<BuffClass>();
            _BuffNames = GetAvailableBuffNames();

        }

        private void Update() {
            /* 
             * Only a little bit of spaghetti : ^)
             * This is much more efficient than Coroutines are, which is why I'm using this spaghetti over them.
             * I could and should have made a helper util which lets you plug in an entity list and it will fetch it every x seconds,
             * but this will do just fine.
             */
        


            if (Time.time >= lastCachePlayer) {
                localPlayer = FindObjectOfType<EntityPlayerLocal>();

                lastCachePlayer = Time.time + 5f;
            } else if (Time.time >= lastCacheZombies) {
                zombieList = FindObjectsOfType<EntityZombie>().ToList();

                lastCacheZombies = Time.time + 3f;
            } else if (Time.time >= lastCacheItems) {
                itemList = FindObjectsOfType<EntityItem>().ToList();

                lastCacheItems = Time.time + 4f;
            }
        }

        private float lastCachePlayer;
        private float lastCacheZombies;
        private float lastCacheItems;

        public static List<EntityPlayer> PlayerList {
            get {
                if (GameManager.Instance != null)
                    if (GameManager.Instance.World != null)
                        return GameManager.Instance.World.GetPlayers();
                return new List<EntityPlayer>();
            }
        }
       
        public static List<string> GetAvailableBuffNames1()
        {
            SortedDictionary<string, BuffClass> sortedDictionary = new SortedDictionary<string, BuffClass>(BuffManager.Buffs, StringComparer.OrdinalIgnoreCase);
            List<string> buffNames = new List<string>();

            foreach (KeyValuePair<string, BuffClass> keyValuePair in sortedDictionary)
            {
                if (keyValuePair.Key.Equals(keyValuePair.Value.LocalizedName))
                {
                    buffNames.Add(keyValuePair.Key);
                }
                else
                {
                    buffNames.Add(keyValuePair.Key);
                }

            }

            return buffNames;
        }
        public static List<string> GetAvailableBuffNames()
        {
            SortedDictionary<string, BuffClass> sortedDictionary = new SortedDictionary<string, BuffClass>(BuffManager.Buffs, StringComparer.OrdinalIgnoreCase);
            List<string> buffNames = new List<string>();

            foreach (KeyValuePair<string, BuffClass> keyValuePair in sortedDictionary)
            {
                BuffClass buff = keyValuePair.Value;

                // Check if the buff's EffectGroups contain PassiveEffects.None
                if (buff.Effects != null && buff.Effects.PassivesIndex.Contains(PassiveEffects.None))
                {
                    // Add the buff name to the list if it has PassiveEffects.None
                    buffNames.Add(keyValuePair.Key);
                }
            }

            return buffNames;
        }
        public static List<BuffClass> GetBuffsByEffect(PassiveEffects effect)
        {
            List<BuffClass> buffsByEffect = new List<BuffClass>();

            if (BuffManager.Buffs != null)
            {
                foreach (var buffEntry in BuffManager.Buffs)
                {
                    BuffClass buff = buffEntry.Value;
                    if (buff.Effects != null && buff.Effects.PassivesIndex.Contains(PassiveEffects.None))
                    {
                        buffsByEffect.Add(buff);
                    }
                }
            }

            return buffsByEffect;
        }

        public static List<BuffClass> GetAvailableBuffClasses()  // gets the buffclasses??
        {
            // Clear the list to ensure it's up-to-date.
            buffClasses.Clear();
            //buffClasses.
            if (BuffManager.Buffs != null)
            {
               
                BuffManager.Buffs.OfType<BuffClass>();
                foreach (var buffEntry in BuffManager.Buffs)
                {
                    //buffEntry.Value.Effects.EffectGroups.
                    buffClasses.Add(buffEntry.Value);
                }
            }

            return buffClasses;
        }

        public static EntityPlayerLocal localPlayer;
        public static List<EntityZombie> zombieList;
        //public static List<whatever that should stand here> buffList;        
        public static List<EntityItem> itemList;
        public static EntityPlayer _entityplayer;

        public static GameManager gameManager;


        

        public static EnumGameStats _enumstats;
        public static XUiM_PlayerInventory _playerinv;


        private static List<BuffClass> buffClasses;




        public static BuffClass _buffClass;
        public static List<string> _BuffNames;

    }

}
