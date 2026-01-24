using System;
using Lab3FoodDelivery.Orders;

namespace Lab3FoodDelivery.Observer
{
    public class ConsoleOrderObserver : IOrderObserver
    {
        public void Update(Order order)
        {
            if (order == null)
            {
                return;
            }
            Console.WriteLine("Наблюдатель: заказ " + order.Id + " -> статус: " + order.GetStatus());
        }
    }
}
