namespace Lab3FoodDelivery.Strategies
{
    public class NoDiscountStrategy : IDiscountStrategy
    {
        public int GetDiscount(int itemsTotalPrice)
        {
            return 0;
        }
    }
}
