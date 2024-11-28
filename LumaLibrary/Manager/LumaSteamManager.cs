using LumaLibrary.API;
using LumaLibrary.Patch;
using LumaLibrary.Extension;
using System;

namespace LumaLibrary.Manager
{
    public class LumaSteamManager : IManager
    {
        private static LumaSteamManager _instance;

        public static LumaSteamManager Instance => _instance ??= new LumaSteamManager();

        private LumaSteamManager() { }

        public event Action OnSteamInitialized;

        static LumaSteamManager()
        {
            ((IManager)Instance).Init();
        }

        #region Trigger
        public void TriggerSteamInitialized()
        {
            OnSteamInitialized?.SafeInvoke();
        }
        #endregion

        void IManager.Init()
        {
            Plugin.LogInit(nameof(LumaSteamManager));
            Plugin.Harmony.PatchAll(typeof(SteamManagerPatch));
        }
    }
}
