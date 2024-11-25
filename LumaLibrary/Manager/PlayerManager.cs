using LumaLibrary.API;
using UnityEngine;

namespace LumaLibrary.Manager
{
    public class PlayerManager : IManager
    {
        private static PlayerManager _instance;

        public static PlayerManager Instance => _instance ??= new PlayerManager();

        private PlayerManager() { }

        static PlayerManager()
        {
            ((IManager)Instance).Init();
        }

        public LocalPlayerController GetLocalPlayer()
        {
            return GameObject.Find("Player").GetComponent<LocalPlayerController>();
        }

        void IManager.Init()
        {
            // ...
        }
    }
}
