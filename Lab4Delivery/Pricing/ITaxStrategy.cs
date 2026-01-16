namespace Lab4Delivery.Pricing
{
    public interface ITaxStrategy
    {
        decimal CalculateTax(decimal taxableAmount);
    }
}
