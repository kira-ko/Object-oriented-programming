namespace Lab3FoodDelivery.Strategies
{
    public interface ITaxStrategy
    {
        int GetTax(int priceAfterDiscount);
    }
}
