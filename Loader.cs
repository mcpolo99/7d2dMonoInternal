using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UnityEngine;


namespace SevenDTDMono
{
    public class Loader
    {
        internal static UnityEngine.GameObject gameObject;
        public static string baseName = "GameObject";
        public static string newObjectName = baseName;
        public static int index = 1;

       
        public static AssemblyHelper assemblyHelper; // Add a member variable

        public static void Load()
        {
            gameObject = new UnityEngine.GameObject();
#if RELEASE_UE || DEBUG
            assemblyHelper = new AssemblyHelper();
            assemblyHelper.TryLoad();
#endif
            gameObject.AddComponent<Objects>();
            gameObject.AddComponent<NewMenu>();
            gameObject.AddComponent<Cheat>();
            gameObject.AddComponent<Settings>();
            gameObject.AddComponent<ESP>();
            gameObject.AddComponent<Visuals>();
            gameObject.AddComponent<Aimbot>();
            gameObject.AddComponent<Render>();
            gameObject.AddComponent<SceneDebugger>();
            gameObject.AddComponent<CBuffs>();
            //gameObject.AddComponent<EasterEggManager>();          
#if RELEASE_UE || DEBUG
            InitializeUnityExplorer();
#endif
            UnityEngine.Object.DontDestroyOnLoad(gameObject);
        }
        public static void InitializeUnityExplorer()
        {
            if (assemblyHelper.AreAllAssembliesLoaded() == true && Settings.ASMloaded == false)
            {
                Settings.ASMloaded=true;

#if RELEASE_UE || DEBUG
                UnityExplorer.ExplorerStandalone.CreateInstance();
#endif
            }

        }

        public static void Unload()
        {
            UnityEngine.Object.Destroy(gameObject.GetComponent<SceneDebugger>());
            UnityEngine.Object.Destroy(gameObject);
        }
    }
}
