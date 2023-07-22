namespace 7DTDMono_NS
{
    public class Loader
    {
        static UnityEngine.GameObject gameObject;

        public static void Load()
        {
            gameObject = new UnityEngine.GameObject();


            gameObject.AddComponent<NewMenu>();
            gameObject.AddComponent<Cheat>();
            gameObject.AddComponent<Settings>();
            gameObject.AddComponent<Objects>();
            gameObject.AddComponent<ESP>();
            gameObject.AddComponent<Visuals>();
            gameObject.AddComponent<Aimbot>();
            gameObject.AddComponent<Render>();
            //gameObject.AddComponent<ESPUtils>();
            gameObject.AddComponent<SceneDebugger>();
            UnityEngine.Object.DontDestroyOnLoad(gameObject);
        }

        public static void Unload()
        {
            UnityEngine.Object.Destroy(gameObject);
        }
    }
}
