using BepInEx;
using HarmonyLib;
using LumaLibrary.Utils;
using UnityEngine;

namespace LumaLibrary
{
    [BepInPlugin(ModGUID, ModName, Version)]
    public class Plugin : BaseUnityPlugin
    {
        public const string ModGUID = "etc.shikaru.lumalib";
        public const string ModName = "LumaLibrary";
        public const string Version = "0.0.2";

        internal static GameObject RootObject { get; private set; }

        internal static Harmony Harmony = new(ModGUID);

        internal static Plugin LumaInstance;

        private void Awake()
        {
            LumaInstance = this;
            RootObject = GetRootObject();
        }

        private static GameObject GetRootObject()
        {
            if (RootObject)
            {
                return RootObject;
            }

            RootObject = new GameObject("_LumaLibrary");
            DontDestroyOnLoad(RootObject);

            return RootObject;
        }

        public static void LogInit(string module)
        {
            LumaLibrary.Logger.LogInfo($"Initializing {module}");

            if (!LumaInstance)
            {
                string message = $"{module} was accessed before LumaLibrary Awake, this can cause unexpected behaviour. " +
                                 "Please make sure to add `[BepInDependency(LumaLibrary.Plugin.ModGUID)]` next to your BaseUnityPlugin";
                LumaLibrary.Logger.LogWarning(BepInExUtils.GetSourceModMetadata(), message);
            }
        }
    }
}
