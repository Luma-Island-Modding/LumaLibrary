using BepInEx;
using HarmonyLib;
using LumaLibrary.Utils;
using UnityEngine;

namespace LumaLibrary;

[BepInPlugin(ModGUID, ModName, Version)]
public class Plugin : BaseUnityPlugin
{
    public const string ModGUID = "etc.shikaru.lumalib";
    public const string ModName = "LumaLibrary";
    public const string Version = "0.0.1";

    private static GameObject rootObject;

    internal static GameObject RootObject => GetRootObject();

    internal static Harmony Harmony = new Harmony(ModGUID);

    internal static Plugin LumaInstance;

    private void Awake()
    {
        LumaInstance = this;
        GetRootObject();
    }

    private static GameObject GetRootObject()
    {
        if (rootObject)
        {
            return rootObject;
        }

        rootObject = new GameObject("_LumaLibrary");
        DontDestroyOnLoad(rootObject);
        return rootObject;
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
