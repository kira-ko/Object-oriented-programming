using System;
using Lab3FoodDelivery.Orders;

namespace Lab3FoodDelivery.State
{
    public class CompletedState : IOrderState
    {
        private Order _order;
        public CompletedState(Order order)
        {
            _order = order;
        }
        public void Process()
        {
            Console.WriteLine("Заказ " + _order.Id + " уже выполнен.");
        }
        public void Cancel()
        {
            Console.WriteLine("Заказ " + _order.Id + " уже выполнен, отмена невозможна.");
        }
        public void MarkAsDelivered()
        {
            Console.WriteLine("Заказ " + _order.Id + " уже доставлен.");
        }
        public string GetStatus()
        {
            return "Выполнен";
        }
    }
}
