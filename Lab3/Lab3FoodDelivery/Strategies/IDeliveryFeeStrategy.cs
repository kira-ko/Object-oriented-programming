namespace Lab3FoodDelivery.Strategies
{
    public class StandardDeliveryFeeStrategy : IDeliveryFeeStrategy
    {
        public int GetDeliveryFee(int itemsTotalPrice)
        {
            if (itemsTotalPrice >= 1000)
            {
                return 0;
            }
            return 200;
        }
    }
}
