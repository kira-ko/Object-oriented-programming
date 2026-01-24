namespace Lab3FoodDelivery.Strategies
{
    public interface IDeliveryFeeStrategy
    {
        int GetDeliveryFee(int itemsTotalPrice);
    }
}
