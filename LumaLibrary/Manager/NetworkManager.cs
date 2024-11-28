using LumaLibrary.API;
using LumaLibrary.Enum;
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
        public event Action OnNetworkInitialze;

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

        #region Trigger
        public void TriggerNetworkInitialize()
        {
            OnNetworkInitialze?.SafeInvoke();
        }
        public void TriggerOnStartHost()
        {
            OnStartHost?.SafeInvoke();
        }
        public void TriggerOnStartClient()
        {
            OnStartClient?.SafeInvoke();
        }
        #endregion

        public void ListenHostEvent(NetworkHostEvent @event, Action<string> callback)
        {
            if(Network.Instance == null)
            {
                Logger.LogError("Network manager is null, cannot listen any events");
                return;
            }
            switch (@event)
            {
                case NetworkHostEvent.OnPlayerJoinedGame:
                    Network.Manager.Host_OnPlayerJoinedGame += callback;
                    break;
                case NetworkHostEvent.OnPlayerLeftGame:
                    Network.Manager.Host_OnPlayerLeftGame += callback;
                    break;
                default:
                    break;
            }
        }

        public void ListenClientEvent(NetworkClientEvent @event, Action callback)
        {
            if (Network.Manager == null)
            {
                Logger.LogError("Network manager is null, cannot listen any events");
                return;
            }
            switch (@event)
            {
                case NetworkClientEvent.OnConnectedToServer:
                    Network.Manager.Client_OnConnectedToServer += callback;
                    break;
                case NetworkClientEvent.OnDisconnectedFromHost:
                    Network.Manager.Client_OnDisconnectedFromHost += callback;
                    break;
                case NetworkClientEvent.OnFailedToConnectToHost:
                    Network.Manager.Client_OnFailedToConnectToHost += callback;
                    break;
                default:
                    break;
            }
        }

    }
}
