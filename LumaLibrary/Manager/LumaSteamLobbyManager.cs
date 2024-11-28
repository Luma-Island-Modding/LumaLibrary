using LumaLibrary.API;
using LumaLibrary.Patch;
using LumaLibrary.Extension;
using Steamworks;
using System;
using UnityEngine;

namespace LumaLibrary.Manager
{
    public class LumaSteamLobbyManager : IManager
    {
        private static LumaSteamLobbyManager _instance;

        public static LumaSteamLobbyManager Instance => _instance ??= new LumaSteamLobbyManager();

        private LumaSteamLobbyManager() { }

        public event Action<LobbyCreated_t> OnLobbyBeforeCreated;
        public event Action<LobbyCreated_t> OnLobbyCreated;
        public event Action<LobbyEnter_t> OnLobbyBeforeEntered;
        public event Action<LobbyEnter_t> OnLobbyEntered;
        public event Action<LobbyInvite_t> OnLobbyInviteReceived;

        public event Action<GameJoinFailReason> OnFailedToJoinGame;

        #region Trigger
        public void TriggerLobbyBeforeCreated(LobbyCreated_t lobbyData)
        {
            OnLobbyBeforeCreated?.SafeInvoke(lobbyData);
        }

        public void TriggerLobbyCreated(LobbyCreated_t lobbyData)
        {
            OnLobbyCreated?.SafeInvoke(lobbyData);
        }

        private void TriggerFailedToJoinGame(GameJoinFailReason reason, string message)
        {
            OnFailedToJoinGame?.SafeInvoke(reason);
            Logger.LogWarning(message);
        }

        private string GetGameVersion(CSteamID lobbyId)
        {
            return SteamMatchmaking.GetLobbyData(lobbyId, "game_version");
        }

        public void TriggerOnLobbyBeforeEntered(SteamLobbyController instance, LobbyEnter_t lobbyEnterData)
        {
            if (lobbyEnterData.m_EChatRoomEnterResponse != 1U)
            {
                TriggerFailedToJoinGame(GameJoinFailReason.None, "Failed to trigger on lobby entered event - m_EChatRoomEnterResponse != 1U");
                return;
            }

            string gameVersion = GetGameVersion(instance.lobbyID);
            if (gameVersion != Application.version)
            {
                TriggerFailedToJoinGame(GameJoinFailReason.VersionMismatch, $"[Version mismatch] Failed to trigger on lobby entered event - App: {Application.version} | Lobby: {gameVersion}");
                return;
            }

            OnLobbyBeforeEntered?.SafeInvoke(lobbyEnterData);
        }

        public void TriggerOnLobbyEntered(LobbyEnter_t lobbyEnterData)
        {
            OnLobbyEntered?.SafeInvoke(lobbyEnterData);
        }

        public void TriggerOnLobbyInviteReceived(LobbyInvite_t inviteRequest)
        {
            OnLobbyInviteReceived?.SafeInvoke(inviteRequest);
        }
        #endregion

        static LumaSteamLobbyManager()
        {
            ((IManager)Instance).Init();
        }

        void IManager.Init()
        {
            Plugin.LogInit(nameof(LumaSteamLobbyManager));
            Plugin.Harmony.PatchAll(typeof(SteamLobbyPatch));
        }
    }
}
