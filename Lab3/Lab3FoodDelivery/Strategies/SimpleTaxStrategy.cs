using System;

namespace Lab3FoodDelivery.Strategies
{
    public class SimpleTaxStrategy : ITaxStrategy
    {
        private int _percent;

        public SimpleTaxStrategy(int percent)
        {
            if (percent < 0)
            {
                throw new ArgumentException("Процент налога не может быть отрицательным.");
            }
            _percent = percent;
        }
        public int GetTax(int priceAfterDiscount)
        {
            int tax = priceAfterDiscount * _percent / 100;
            return tax;
        }
    }
}
