using System;
using Lab3FoodDelivery.Orders;

namespace Lab3FoodDelivery.State
{
    public class CancelledState : IOrderState
    {
        private Order _order;
        public CancelledState(Order order)
        {
            _order = order;
        }
        public void Process()
        {
            Console.WriteLine("Заказ " + _order.Id + " отменён.");
        }
        public void Cancel()
        {
            Console.WriteLine("Заказ " + _order.Id + " уже отменён.");
        }
        public void MarkAsDelivered()
        {
            Console.WriteLine("Заказ " + _order.Id + " отменён, доставка невозможна.");
        }
        public string GetStatus()
        {
            return "Отменён";
        }
    }
}
