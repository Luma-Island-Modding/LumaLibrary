using HarmonyLib;
using LumaLibrary.Manager;

namespace LumaLibrary.Patch
{
    [HarmonyPatch(typeof(SteamLobbyController))]
    public static class SteamManagerPatch
    {
        [HarmonyPostfix]
        [HarmonyPatch(nameof(SteamManager.Awake))]
        public static void PostfixAwake()
        {
            if (SteamManager.Initialized)
            {
                LumaSteamManager.Instance.TriggerSteamInitialized();
            }
        }
    }
}
