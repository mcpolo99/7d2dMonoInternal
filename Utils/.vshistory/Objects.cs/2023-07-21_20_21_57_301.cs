﻿using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SevenDTDMono{
    public class Objects : MonoBehaviour {

        public static List<string> GetAvailableBuffNames1()
        {
            List<string> buffNames = new List<string>();

            if (BuffManager.Buffs != null)
            {
                foreach (var buffEntry in BuffManager.Buffs)
                {
                    buffNames.Add(buffEntry.Key);
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
                if (keyValuePair.Key.Equals(keyValuePair.Value.LocalizedName))
                {
                    buffNames.Add(keyValuePair.Key);
                }
                else
                {
                    buffNames.Add($"{keyValuePair.Key} ({keyValuePair.Value.LocalizedName})");
                }
            }

            return buffNames;
        }
        private void Start() {
            zombieList = new List<EntityZombie>();
            itemList = new List<EntityItem>();

            
            SortedDictionary<string, BuffClass> sortedDictionary = new SortedDictionary<string, BuffClass>(BuffManager.Buffs, StringComparer.OrdinalIgnoreCase);

            lastCachePlayer = Time.time + 5f;
            lastCacheZombies = Time.time + 3f;
            lastCacheItems = Time.time + 4f;
            lastCacheItems = Time.time + 1000f;


            _entityplayer = FindObjectOfType<EntityPlayer>();
            _enumstats = GetComponent<EnumGameStats>();
            _playerinv = GetComponent<XUiM_PlayerInventory>();
           
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
 

        public static EntityPlayerLocal localPlayer;
        public static List<EntityZombie> zombieList;
        //public static List<whatever that should stand here> buffList;        
        public static List<EntityItem> itemList;
        public static EntityPlayer _entityplayer;
        public static EnumGameStats _enumstats;
        public static XUiM_PlayerInventory _playerinv;
        public static List<BuffClass> buffList;
    }

}
