namespace Lab4Delivery.Domain;

public class OrderItem
{
    public OrderItem(Dish dish, int quantity)
    {
        Dish = dish;
        Quantity = quantity;
    }

    public Dish Dish { get; }
    public int Quantity { get; }

    public decimal Total => Dish.Price * Quantity;
}
