using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SevenDTD_mono {
    public class Objects : MonoBehaviour {
        private void Start() {
            zombieList = new List<EntityZombie>();
            itemList = new List<EntityItem>();

            lastCachePlayer = Time.time + 5f;
            lastCacheZombies = Time.time + 3f;
            lastCacheItems = Time.time + 4f;

            _entityplayer = FindObjectOfType<EntityPlayer>();
            _enumstats = GetComponent<EnumGameStats>();
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
        public static List<EntityItem> itemList;
        public static EntityPlayer _entityplayer;
        public static EnumGameStats _enumstats;    
    }

}
