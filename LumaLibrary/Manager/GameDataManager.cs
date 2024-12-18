﻿using LumaLibrary.API;
using LumaLibrary.Extension;
using LumaLibrary.Patch;
using System;

namespace LumaLibrary.Manager
{
    public class GameDataManager : IManager
    {
        private static GameDataManager _instance;

        public static GameDataManager Instance => _instance ??= new GameDataManager();

        private GameDataManager() { }

        static GameDataManager()
        {
            ((IManager)Instance).Init();
        }

        public event Action<bool> OnGameDataInitialized;

        public void TriggerOnGameInitialized(bool value)
        {
            OnGameDataInitialized?.SafeInvoke(value);
        }

        void IManager.Init()
        {
            Plugin.LogInit(nameof(GameDataManager));
            Plugin.Harmony.PatchAll(typeof(GameDataPatch));
        }
    }
}
