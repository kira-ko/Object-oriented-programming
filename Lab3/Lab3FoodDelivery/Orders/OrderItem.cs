using System;
using Lab3FoodDelivery.Menu;

namespace Lab3FoodDelivery.Orders
{
    public class OrderItem
    {
        public Dish Dish { get; }
        public int Quantity { get; }
        public OrderItem(Dish dish, int quantity)
        {
            if (dish == null)
            {
                throw new ArgumentException("Введите блюдо, строка не может оставаться пустой.");
            }
            if (quantity <= 0)
            {
                throw new ArgumentException("Количество блюд должно быть больше нуля.");
            }

            Dish = dish;
            Quantity = quantity;
        }
        public int GetTotalPrice()
        {
            return Dish.BasePrice * Quantity;
        }
    }
}
