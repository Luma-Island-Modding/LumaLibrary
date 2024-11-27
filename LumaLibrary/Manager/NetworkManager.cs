using LumaLibrary.API;
using LumaLibrary.Extension;
using LumaLibrary.Patch;
using System;

namespace LumaLibrary.Manager
{
    public class NetworkManager : IManager
    {
        private static NetworkManager _instance;

        public static NetworkManager Instance => _instance ??= new NetworkManager();

        public event Action OnStartHost;
        public event Action OnStartClient;
        public event Action OnLobbyCreated;
        // Todo: On Player Joined, etc.

        public void TriggerOnStartHost()
        {
            OnStartHost?.SafeInvoke();
        }
        public void TriggerOnStartClient()
        {
            OnStartClient?.SafeInvoke();
        }

        private NetworkManager() { }

        static NetworkManager()
        {
            ((IManager)Instance).Init();
        }

        void IManager.Init()
        {
            Plugin.LogInit(nameof(NetworkManager));
            Plugin.Harmony.PatchAll(typeof(NetworkPatch));
        }
    }
}
