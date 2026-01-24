using System;

namespace Lab3FoodDelivery.Strategies
{
    public class PercentDiscountStrategy : IDiscountStrategy
    {
        private int _percent;

        public PercentDiscountStrategy(int percent)
        {
            if (percent < 0)
            {
                throw new ArgumentException("Процент скидки не может быть отрицательным.");
            }
            _percent = percent;
        }

        public int GetDiscount(int itemsTotalPrice)
        {
            int discount = itemsTotalPrice * _percent / 100;
            return discount;
        }
    }
}
