using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using UnityEngine;

namespace LumaLibrary;

[BepInPlugin(ModGUID, ModName, Version)]
public class Plugin : BaseUnityPlugin
{
    public const string ModGUID = "etc.shikaru.lumalib";
    public const string ModName = "LumaLibrary";
    public const string Version = "0.0.1";

    internal static new ManualLogSource Logger;

    private static GameObject rootObject;

    internal static GameObject RootObject => GetRootObject();

    internal static Harmony Harmony = new Harmony(ModGUID);


    private void Awake()
    {
        // Plugin startup logic
        Logger = base.Logger;
        Logger.LogInfo($"Plugin {ModGUID} is loaded!");

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
}
