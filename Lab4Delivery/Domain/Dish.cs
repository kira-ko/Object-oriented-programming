namespace Lab4Delivery.Domain;

public class Dish
{
    public Dish(string name, decimal price)
    {
        Name = name;
        Price = price;
    }

    public string Name { get; }
    public decimal Price { get; }
}
