using LumaLibrary.API;
using LumaLibrary.Extension;
using System;

namespace LumaLibrary.Manager 
{
    public class ItemManager : IManager
    {
        private static ItemManager _instance;

        public static ItemManager Instance => _instance ??= new ItemManager();

        private ItemManager() { }

        public event Action OnItemsPatch;

        public void TriggerOnItemPatch()
        {
            OnItemsPatch?.SafeInvoke();
        }

        static ItemManager()
        {
            ((IManager)Instance).Init();
        }

        void IManager.Init()
        {
            // ...
        }

        public void UpdateBuyValue(string name, int newBuyValue)
        {
            var item = GameData.Instance.InventoryItemsDB.GetObjectByName(name);
            if(item != null)
            {
                item.Buyvalue = newBuyValue;
            }
        }

        public void UpdateSellValue(string name, int newSellValue)
        {
            var item = GameData.Instance.InventoryItemsDB.GetObjectByName(name);
            if (item != null)
            {
                item.Sellvalue = newSellValue;
            }
        }
    }
}
