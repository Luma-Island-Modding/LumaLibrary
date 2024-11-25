using HarmonyLib;

namespace LumaLibrary.Patch
{
    /// <summary>
    /// Patching ingame shop's
    /// </summary>
    [HarmonyPatch(typeof(Shop))]
    public class ShopPatch
    {
        [HarmonyPostfix]
        [HarmonyPatch(nameof(Shop.OnPlace))]
        static void OnPlacePostfix(Shop __instance)
        {
            // ...
        }
    }
}
