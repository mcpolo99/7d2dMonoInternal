
//////////using UnityEngine;

//////////namespace SevenDTDMono
//////////{
//////////    public class Loader : MonoBehaviour
//////////    {
//////////        internal static new UnityEngine.GameObject gameObject;

//////////        void OnApplicationFocus()
//////////        {
//////////            Log.Out("on apl focus");
//////////            if(Settings.loaded == false)
//////////            {
//////////                Settings.loaded = true;
//////////                //Load();
//////////            }
//////////        }
//////////        void Start () 
//////////        {
//////////            Log.Out("on start");

//////////        }
//////////        void Update ()
//////////        {
//////////            Log.Out("update");

//////////        }
//////////        void OnGUI()
//////////        {
//////////            Log.Out("on gui");
//////////        }

//////////        void OnHud()
//////////        {
//////////            Log.Out("onhud");
//////////        }
//////////        public static void Load()
//////////        {

//////////            gameObject = new UnityEngine.GameObject();
//////////            //gameObject.AddComponent<SceneDebugger>();
//////////            InitializeUnityExplorer();
//////////        }


//////////        public static void InitializeUnityExplorer()
//////////        {
//////////            if (ASMCHECK.CheckLoadedAssemblies() == true)
//////////            {
//////////                UnityExplorer.ExplorerStandalone.CreateInstance();
//////////            }

//////////        //    if (assemblyHelper.AreAllAssembliesLoaded() == true)
//////////        //    {
//////////        //        UnityExplorer.ExplorerStandalone.CreateInstance();
//////////        //    }
//////////        //    else if (AreAllAssembliesLoaded() == true)
//////////        //    {
//////////        //        UnityExplorer.ExplorerStandalone.CreateInstance();
//////////        //    }
//////////        }


//////////    }
//////////}











//using HarmonyLib;
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

            //while (GameObject.Find(newObjectName) != null)
            //{
            //    // Increment the index and create a new name
            //    newObjectName = baseName + index.ToString();
            //    index++;

            //}
            //// Instantiate a new GameObject with the unique name
            //GameObject newObject = new GameObject(newObjectName);


            //// Add necessary components to the new GameObject
            //assemblyHelper = new AssemblyHelper();
            //assemblyHelper.TryLoad();
            ////LoadAdditionalDLLs();
            //newObject.AddComponent<NewMenu>();
            //newObject.AddComponent<Cheat>();
            //newObject.AddComponent<Settings>();
            //newObject.AddComponent<Objects>();
            //newObject.AddComponent<ESP>();
            //newObject.AddComponent<Visuals>();
            //newObject.AddComponent<Aimbot>();
            //newObject.AddComponent<Render>();
            ////gameObject.AddComponent<Menu>();
            //newObject.AddComponent<SceneDebugger>();

            //InitializeUnityExplorer();

            //UnityEngine.Object.DontDestroyOnLoad(newObject);


            //var harminy = new Harmony();
            gameObject = new UnityEngine.GameObject();

            assemblyHelper = new AssemblyHelper();
            assemblyHelper.TryLoad();
        
            gameObject.AddComponent<NewMenu>();
            gameObject.AddComponent<Cheat>();
            gameObject.AddComponent<Settings>();
            gameObject.AddComponent<Objects>();
            gameObject.AddComponent<ESP>();
            gameObject.AddComponent<Visuals>();
            gameObject.AddComponent<Aimbot>();
            gameObject.AddComponent<Render>();
            //gameObject.AddComponent<Menu>();
            gameObject.AddComponent<SceneDebugger>();

            InitializeUnityExplorer();

            UnityEngine.Object.DontDestroyOnLoad(gameObject);
            //////UnityEngine.Object.Destroy(gameObject.GetComponent<SceneDebugger>());


        }
        public static void InitializeUnityExplorer()
        {
            if (assemblyHelper.AreAllAssembliesLoaded() == true && Settings.ASMloaded == false)
            {
                Settings.ASMloaded=true;
                UnityExplorer.ExplorerStandalone.CreateInstance();
            }

            //else if (AreAllAssembliesLoaded() == true)
            //{
            //    UnityExplorer.ExplorerStandalone.CreateInstance();
            //}
        }

        public static void Unload()
        {
            UnityEngine.Object.Destroy(gameObject.GetComponent<SceneDebugger>());
            //UnloadAdditionalDLLs();
            UnityEngine.Object.Destroy(gameObject);
        }


        //private static void LoadAdditionalDLLs()
        //{
        //    //string targetDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Load\\");


        //    foreach (string assemblyName in assembliesToLoad)
        //    {
        //        LoadAssembly(assemblyName);
        //    }

        //    //"7DaysToDie_Data\\Managed\\"
        //    // Load additional DLLs here using Assembly.LoadFrom()
        //    // For example:
        //    // Assembly additionalAssembly = Assembly.LoadFrom("path/to/additional.dll");
        //    // Add logic here to use types and methods from the loaded assembly as needed.
        //}
        //private static void LoadAssembly(string assemblyName)
        //{
        //    if (!IsAssemblyLoaded(assemblyName))
        //    {


        //        string assemblyPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "load", $"{assemblyName}.dll");
        //        if (File.Exists(assemblyPath))
        //        {
        //            Assembly assembly = Assembly.LoadFrom(assemblyPath);
        //            loadedAssemblies[assemblyName] = assembly;
        //            Log.Out($"{assemblyName} has been loaded.");

        //        }
        //        else
        //        {
        //            Log.Out($"{assemblyName} is not present at location: {assemblyPath}");
        //        }

        //        //Assembly assembly = Assembly.LoadFrom(assemblyPath);
        //        //loadedAssemblies[assemblyName] = assembly;

        //        //Log.Out($"{assemblyName} has been loaded.");
        //    }
        //}
        //private static bool IsAssemblyLoaded(string assemblyName)
        //{
        //    return loadedAssemblies.ContainsKey(assemblyName);
        //}
        //private static void UnloadAdditionalDLLs()
        //{
        //    // Unload additional DLLs if needed
        //    // Implement any cleanup logic for the loaded assemblies.
        //}
        //public static bool AreAllAssembliesLoaded()
        //{
        //    foreach (string assemblyName in assembliesToLoad)
        //    {
        //        if (!IsAssemblyLoaded(assemblyName))
        //        {
        //            return false;
        //        }
        //    }

        //    return true;
        //}


    }
}
