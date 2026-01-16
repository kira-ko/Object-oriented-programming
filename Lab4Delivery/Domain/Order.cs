using Lab4Delivery.Observers;
using Lab4Delivery.States;

namespace Lab4Delivery.Domain;

public class Order
{
    private readonly List<OrderItem> _items = new();
    private readonly List<IOrderObserver> _observers = new();

    private IOrderState _state;

    public Order(OrderType type, string? preferences = null)
    {
        Type = type;
        Preferences = preferences;
        _state = new PreparingState();
    }

    public Guid Id { get; } = Guid.NewGuid();
    public OrderType Type { get; }
    public string? Preferences { get; }

    public IReadOnlyList<OrderItem> Items => _items;
    public OrderStatus Status => _state.Status;

    public void AddItem(Dish dish, int quantity)
    {
        if (quantity <= 0) throw new ArgumentException("Quantity must be positive.", nameof(quantity));
        _items.Add(new OrderItem(dish, quantity));
    }

    public decimal ItemsSubtotal => _items.Sum(i => i.Total);

    public void MoveToNextStatus()
    {
        _state.MoveNext(this);
        NotifyStatusChanged();
    }

    internal void SetState(IOrderState state)
    {
        _state = state;
    }

    public void Subscribe(IOrderObserver observer)
    {
        _observers.Add(observer);
    }

    public void Unsubscribe(IOrderObserver observer)
    {
        _observers.Remove(observer);
    }

    private void NotifyStatusChanged()
    {
        foreach (var obs in _observers)
            obs.OnStatusChanged(this, Status);
    }
}
