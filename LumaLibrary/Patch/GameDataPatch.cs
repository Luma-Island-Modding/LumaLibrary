using HarmonyLib;
using LumaLibrary.Manager;

namespace LumaLibrary.Patch
{
    [HarmonyPatch(typeof(GameData))]
    public static class GameDataPatch
    {
        [HarmonyPostfix]
        [HarmonyPatch(nameof(GameData.IsInitialized), MethodType.Setter)]
        public static void Initialize(bool value)
        {
            if(value)
            {
                GameDataManager.Instance.TriggerOnGameInitialized(value);
            }
        }
    }
}
