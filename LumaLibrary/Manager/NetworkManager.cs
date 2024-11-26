using LumaLibrary.API;

namespace LumaLibrary.Manager
{
    public class NetworkManager : IManager
    {
        private static NetworkManager _instance;

        public static NetworkManager Instance => _instance ??= new NetworkManager();

        private NetworkManager() { }

        static NetworkManager()
        {
            ((IManager)Instance).Init();
        }

        void IManager.Init()
        {
        }
    }
}
