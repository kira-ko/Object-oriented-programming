namespace Lab3FoodDelivery.Strategies
{
    public class ExpressDeliveryFeeStrategy : IDeliveryFeeStrategy
    {
        public int GetDeliveryFee(int itemsTotalPrice)
        {
            if (itemsTotalPrice >= 1000)
            {
                return 200;
            }
            return 400;
        }
    }
}
