using System;
using System.Collections.Generic;
using Lab1University.Interfaces;
using GameInventory.Items;

namespace Lab1University.Models
{
    public class Inventory : IInventory
    {
        private readonly List<IItem> _items;

        public Inventory()
        {
            _items = new List<IItem>();
        }

        public int Count
        {
            get { return _items.Count; }
        }

        public void Add(IItem item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            _items.Add(item);
        }

        public IItem GetById(string id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            foreach (IItem item in _items)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }

            return null;
        }

        public void RemoveById(string id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            IItem itemToRemove = null;

            foreach (IItem item in _items)
            {
                if (item.Id == id)
                {
                    itemToRemove = item;
                    break;
                }
            }

            if (itemToRemove != null)
            {
                _items.Remove(itemToRemove);
            }
        }

        public List<IItem> GetAll()
        {
            List<IItem> copy = new List<IItem>();

            foreach (IItem item in _items)
            {
                copy.Add(item);
            }

            return copy;
        }
    }
}

