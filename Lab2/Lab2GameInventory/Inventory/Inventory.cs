using System;
using System.Collections.Generic;
using Lab2GameInventory.Items.Common;

namespace Lab2GameInventory.Inventory
{
    public class Inventory : IInventory
    {
        private List<IItem> _items;
        public int Capacity { get; }
        public Inventory(int capacity)
        {
            if (capacity <= 0)
            {
                throw new ArgumentException("Емкость инвентаря должна быть больше нуля.");
            }
            Capacity = capacity;
            _items = new List<IItem>();
        }

        public bool AddItem(IItem item)
        {
            if (item == null)
            {
                return false;
            }
            if (_items.Count >= Capacity)
            {
                return false;
            }
            _items.Add(item);
            return true;
        }

        public bool RemoveItemById(string id)
        {
            if (id == null)
            {
                return false;
            }

            for (int i = 0; i < _items.Count; i++)
            {
                if (_items[i].Id == id)
                {
                    _items.RemoveAt(i);
                    return true;
                }
            }

            return false;
        }

        public List<IItem> GetAllItems()
        {
            List<IItem> result = new List<IItem>();

            for (int i = 0; i < _items.Count; i++)
            {
                result.Add(_items[i]);
            }

            return result;
        }

        public bool EquipItem(string id)
        {
            if (id == null)
            {
                return false;
            }
            for (int i = 0; i < _items.Count; i++)
            {
                IEquipable equipableItem = _items[i] as IEquipable;
                if (equipableItem != null && _items[i].Id == id)
                {
                    equipableItem.Equip();
                    return true;
                }
            }

            return false;
        }

        public bool UnequipItem(string id)
        {
            if (id == null)
            {
                return false;
            }

            for (int i = 0; i < _items.Count; i++)
            {
                IEquipable equipableItem = _items[i] as IEquipable;
                if (equipableItem != null && _items[i].Id == id)
                {
                    equipableItem.Unequip();
                    return true;
                }
            }

            return false;
        }

        public bool UseItem(string id)
        {
            if (id == null)
            {
                return false;
            }
            for (int i = 0; i < _items.Count; i++)
            {
                IUsable usableItem = _items[i] as IUsable;
                if (usableItem != null && _items[i].Id == id)
                {
                    usableItem.Use();
                    _items.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        public bool UpgradeItem(string id)
        {
            if (id == null)
            {
                return false;
            }
            for (int i = 0; i < _items.Count; i++)
            {
                IUpgradable upgradableItem = _items[i] as IUpgradable;
                if (upgradableItem != null && _items[i].Id == id)
                {
                    upgradableItem.Upgrade();
                    return true;
                }
            }
            return false;
        }

        public string GetInventoryInfo()
        {
            string info = "Инвентарь (" + _items.Count + "/" + Capacity + "):";

            for (int i = 0; i < _items.Count; i++)
            {
                info = info + "\n- " + _items[i].GetInfo();
            }

            return info;
        }
    }
}
