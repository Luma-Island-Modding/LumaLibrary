using LumaLibrary.API;
using LumaLibrary.Patch;
using System;
using UnityEngine;
using LumaLibrary.Extension;

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

        public event Action<Shop> OnShopBenchPlaced;
        public event Action<Shop> OnShopInteract;

        public void TriggerOnPlaceEvent(Shop instance)
        {
            OnShopBenchPlaced?.SafeInvoke(instance);
        }

        public void TriggerOnInteractEvent(Shop instance)
        {
            OnShopInteract?.SafeInvoke(instance);
        }

        /// <summary>
        /// Get Shop component by shop name
        /// </summary>
        /// <param name="name">Shops - Constants</param>
        /// <returns></returns>
        public Shop GetShop(string name)
        {
            return GetShopGameObject(name).GetComponent<Shop>();
        }

        /// <summary>
        /// Get GameObject shop
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public GameObject GetShopGameObject(string name)
        {
            return GameObject.Find(name);
        }

        /// <summary>
        /// Get a GameObject bench
        /// </summary>
        /// <param name="name">Contstants -> Shops.*Bench*</param>
        /// <returns></returns>
        public GameObject GetShopBenchObject(string name)
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
