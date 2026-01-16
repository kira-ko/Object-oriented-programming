namespace Lab4Delivery.Pricing
{
    public class NoDiscountStrategy : IDiscountStrategy
    {
        public decimal CalculateDiscount(decimal itemsSubtotal) => 0m;
    }
}
