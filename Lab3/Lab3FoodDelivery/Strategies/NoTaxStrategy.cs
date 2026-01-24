namespace Lab3FoodDelivery.Strategies
{
    public class NoTaxStrategy : ITaxStrategy
    {
        public int GetTax(int priceAfterDiscount)
        {
            return 0;
        }
    }
}
