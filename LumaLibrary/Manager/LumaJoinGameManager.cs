using LumaLibrary.API;
using LumaLibrary.Extension;
using LumaLibrary.Patch;
using System;

namespace LumaLibrary.Manager
{
    /// <summary>
    /// The main difference from LumaSteamLobbyManager is that LobbyManager is responsible 
    /// for player connections at a lower level, without different save processing
    /// </summary>
    public class LumaJoinGameManager : IManager
    {
        private static LumaJoinGameManager _instance;

        public static LumaJoinGameManager Instance => _instance ??= new LumaJoinGameManager();

        public event Action<string> OnPlayerJoinedGame;
        public event Action<string> OnPlayerLeftGame;

        #region Trigger
        public void TriggerOnPlayerJoinedGame(string machineId)
        {
            OnPlayerJoinedGame?.SafeInvoke(machineId);
        }

        public void TriggerOnPlayerLeftGame(string machineId)
        {
            OnPlayerLeftGame?.SafeInvoke(machineId);
        }
        #endregion

        private LumaJoinGameManager() { }

        static LumaJoinGameManager()
        {
            ((IManager)Instance).Init();
        }

        void IManager.Init()
        {
            Plugin.LogInit(nameof(LumaJoinGameManager));
            Plugin.Harmony.PatchAll(typeof(JoiningGameManagerPatch));
        }

    }
}
