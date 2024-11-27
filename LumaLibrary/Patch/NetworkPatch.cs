using HarmonyLib;
using LumaLibrary.Manager;

namespace LumaLibrary.Patch
{
    [HarmonyPatch(typeof(Network))]
    public static class NetworkPatch
    {
        [HarmonyPostfix]
        [HarmonyPatch(nameof(Network.InitializeNetwork))]
        static void Postfix(Network __instance)
        {
            if(Network.IsClient) {
                NetworkManager.Instance.TriggerOnStartClient();
            } else {
                NetworkManager.Instance.TriggerOnStartHost();
            }
        }
    }
}
