using System.Collections.Generic;
using Lab2GameInventory.Items.Common;

namespace Lab2GameInventory.Inventory
{
    public interface IInventory
    {
        int Capacity { get; }

        bool AddItem(IItem item);
        bool RemoveItemById(string id);

        List<IItem> GetAllItems();

        bool EquipItem(string id);
        bool UnequipItem(string id);

        bool UseItem(string id);

        bool UpgradeItem(string id);

        string GetInventoryInfo();
    }
}
