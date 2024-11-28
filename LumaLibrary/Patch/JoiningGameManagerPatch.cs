using HarmonyLib;
using LumaLibrary.Manager;

namespace LumaLibrary.Patch
{
    [HarmonyPatch(typeof(JoiningGameManager))]
    public static class JoiningGameManagerPatch
    {
        [HarmonyPostfix]
        [HarmonyPatch(nameof(JoiningGameManager.OnPlayerJoinedGame))]
        public static void OnPlayerJoinedGamePostfix(JoiningGameManager __instance, string machineID)
        {
            LumaJoinGameManager.Instance.TriggerOnPlayerJoinedGame(machineID);
        }

        [HarmonyPostfix]
        [HarmonyPatch(nameof(JoiningGameManager.OnPlayerLeftGame))]
        public static void OnPlayerLeftGamePostfix(JoiningGameManager __instance, string machineID)
        {
            LumaJoinGameManager.Instance.TriggerOnPlayerLeftGame(machineID);
        }
    }
}
