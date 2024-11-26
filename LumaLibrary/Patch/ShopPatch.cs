using HarmonyLib;
using LumaLibrary.Manager;

namespace LumaLibrary.Patch
{
    /// <summary>
    /// Patching ingame shop's
    /// </summary>
    [HarmonyPatch(typeof(Shop))]
    public static class ShopPatch
    {
        [HarmonyPostfix]
        [HarmonyPatch(nameof(Shop.OnPlace))]
        static void OnPlacePostfix(Shop __instance)
        {
            ShopManager.Instance.TriggerOnPlaceEvent(__instance);
        }

        [HarmonyPostfix]
        [HarmonyPatch(nameof(Shop.Interact))]
        static void OnInteractPostfix(Shop __instance)
        {
            ShopManager.Instance.TriggerOnInteractEvent(__instance);
        }
    }
}
