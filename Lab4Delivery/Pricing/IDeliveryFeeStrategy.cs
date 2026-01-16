namespace Lab4Delivery.Pricing
{
    public interface IDeliveryFeeStrategy
    {
        decimal CalculateDeliveryFee(decimal itemsSubtotal);
    }
}
