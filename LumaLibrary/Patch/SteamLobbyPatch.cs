using HarmonyLib;
using LumaLibrary.Manager;
using Steamworks;

namespace LumaLibrary.Patch
{
    [HarmonyPatch(typeof(SteamLobbyController))]
    public static class SteamLobbyPatch
    {
        [HarmonyPrefix]
        [HarmonyPatch(nameof(SteamLobbyController.OnLobbyCreated))]
        public static void PrefixOnLobbyCreated(LobbyCreated_t create)
        {
            LumaSteamLobbyManager.Instance.TriggerLobbyBeforeCreated(create);
        }

        [HarmonyPostfix]
        [HarmonyPatch(nameof(SteamLobbyController.OnLobbyCreated))]
        public static void PostfixOnLobbyCreated(LobbyCreated_t create)
        {
            LumaSteamLobbyManager.Instance.TriggerLobbyCreated(create);
        }

        [HarmonyPrefix]
        [HarmonyPatch(nameof(SteamLobbyController.OnLobbyEntered))]
        public static void PrefixOnLobbyEntered(SteamLobbyController __instance, LobbyEnter_t enter)
        {
            LumaSteamLobbyManager.Instance.TriggerOnLobbyBeforeEntered(__instance, enter);
        }

        [HarmonyPostfix]
        [HarmonyPatch(nameof(SteamLobbyController.OnLobbyEntered))]
        public static void PostfixOnLobbyEntered(LobbyEnter_t enter)
        {
            LumaSteamLobbyManager.Instance.TriggerOnLobbyEntered(enter);
        }

        [HarmonyPrefix]
        [HarmonyPatch(nameof(SteamLobbyController.Steam_OnLobbyInviteReceived))]
        public static void PrefixSteam_OnLobbyInviteReceived(LobbyInvite_t request)
        {
            LumaSteamLobbyManager.Instance.TriggerOnLobbyInviteReceived(request);
        }
    }
}
