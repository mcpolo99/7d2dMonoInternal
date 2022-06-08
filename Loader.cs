namespace SevenDTD_mono
{
    public class Loader
    {
        static UnityEngine.GameObject gameObject;

        public static void Load()
        {
            gameObject = new UnityEngine.GameObject();
            gameObject.AddComponent<Cheat>();
            gameObject.AddComponent<Objects>();
            //gameObject.AddComponent<ESP>();
            gameObject.AddComponent<NewMenu>();
            //gameObject.AddComponent<SceneDebugger>();
            UnityEngine.Object.DontDestroyOnLoad(gameObject);
        }

        public static void Unload()
        {
            UnityEngine.Object.Destroy(gameObject);
        }
    }
}
