using LumaLibrary.API;
using UnityEngine;

namespace LumaLibrary.Manager
{

    public class HouseManager : IManager
    {
        private static HouseManager _instance;

        public static HouseManager Instance => _instance ??= new HouseManager();

        private HouseManager() { }

        static HouseManager()
        {
            ((IManager)Instance).Init();
        }

        void IManager.Init()
        {
        }

        public GameObject GetHouse(string houseName)
        {
            return GameObject.Find(houseName);
        }
    }
}
