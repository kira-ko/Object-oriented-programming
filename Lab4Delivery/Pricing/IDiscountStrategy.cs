namespace Lab4Delivery.Pricing
{
    public interface IDiscountStrategy
    {
        decimal CalculateDiscount(decimal itemsSubtotal);
    }
}
