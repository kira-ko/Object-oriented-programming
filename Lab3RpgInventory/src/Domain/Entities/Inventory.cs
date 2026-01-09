using System.Collections.ObjectModel;

namespace RpgInventory.Domain.Entities;

public sealed class Inventory
{
    private readonly List<Item> _items = new();

    public IReadOnlyCollection<Item> Items => new ReadOnlyCollection<Item>(_items);

    public void Add(Item item)
    {
        if (item is null) throw new ArgumentNullException(nameof(item));
        _items.Add(item);
    }

    public bool Remove(Guid itemId)
    {
        var item = _items.FirstOrDefault(i => i.Id == itemId);
        if (item is null) return false;

        _items.Remove(item);
        return true;
    }

    public Item? Find(Guid itemId) => _items.FirstOrDefault(i => i.Id == itemId);

    public double TotalWeight() => _items.Sum(i => i.Weight);
}
