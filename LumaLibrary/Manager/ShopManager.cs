using LumaLibrary.API;
using LumaLibrary.Patch;
using UnityEngine;

namespace LumaLibrary.Manager
{
    public class ShopManager : IManager
    {
        private static ShopManager _instance;

        public static ShopManager Instance => _instance ??= new ShopManager();

        private ShopManager() { }

        static ShopManager()
        {
            ((IManager)Instance).Init();
        }

        public delegate void ShopPlaceHandler(Shop instance);

        public event ShopPlaceHandler OnShopPlaced;

        public void TriggerOnPlaceEvent(Shop instance)
        {
            OnShopPlaced.Invoke(instance);
        }

        public GameObject GetShop(string name)
        {
            return GameObject.Find(name);
        }

        void IManager.Init()
        {
            Plugin.LogInit(nameof(ShopManager));
            Plugin.Harmony.PatchAll(typeof(ShopPatch));
        }
    }
}
