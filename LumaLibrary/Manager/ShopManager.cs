using LumaLibrary.API;
using UnityEngine;

namespace LumaLibrary.Manager
{
    internal class ShopManager : IManager
    {
        private static ShopManager _instance;

        public static ShopManager Instance => _instance ??= new ShopManager();

        private ShopManager() { }

        static ShopManager()
        {
            ((IManager)Instance).Init();
        }

        public GameObject GetShop(string name)
        {
            return GameObject.Find(name);
        }

        void IManager.Init()
        {
            // ...
        }
    }
}
