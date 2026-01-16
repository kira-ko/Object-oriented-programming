using System.Collections.Generic;
using GameInventory.Items;

namespace Lab1University.Interfaces
{
    public interface IInventory
    {
        void Add(IItem item);

        IItem GetById(string id);

        void RemoveById(string id);

        List<IItem> GetAll();

        int Count { get; }
    }
}

