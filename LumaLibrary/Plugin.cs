using BepInEx;
using BepInEx.Logging;

namespace LumaLibrary;

[BepInPlugin(ModGUID, ModName, Version)]
public class Plugin : BaseUnityPlugin
{
    public const string ModGUID = "etc.shikaru.lumalib";
    public const string ModName = "LumaLibrary";
    public const string Version = "0.0.1";

    internal static new ManualLogSource Logger;
        
    private void Awake()
    {
        // Plugin startup logic
        Logger = base.Logger;
        Logger.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} is loaded!");
    }
}
