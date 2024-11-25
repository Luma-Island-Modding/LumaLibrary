using LumaLibrary.API;
using UnityEngine.SceneManagement;

namespace LumaLibrary.Manager
{
    public class SceneManager : IManager
    {
        private static SceneManager _instance;

        public static SceneManager Instance => _instance ??= new SceneManager();

        private SceneManager() { }
        
        static SceneManager()
        {
            ((IManager)Instance).Init();
        }

        public Scene GetScene(string name)
        {
            return UnityEngine.SceneManagement.SceneManager.GetSceneByName(name);
        }

        void IManager.Init()
        {
            // ...
        }
    }
}
