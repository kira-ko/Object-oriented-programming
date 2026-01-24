namespace Lab3FoodDelivery.Strategies
{
    public interface IDiscountStrategy
    {
        int GetDiscount(int itemsTotalPrice);
    }
}
