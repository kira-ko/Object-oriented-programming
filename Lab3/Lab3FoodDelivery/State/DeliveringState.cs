using System;
using Lab3FoodDelivery.Orders;

namespace Lab3FoodDelivery.State
{
    public class DeliveringState : IOrderState
    {
        private Order _order;
        public DeliveringState(Order order)
        {
            _order = order;
        }
        public void Process()
        {
            Console.WriteLine("Заказ " + _order.Id + " уже находится в доставке.");
        }
        public void Cancel()
        {
            Console.WriteLine("Заказ " + _order.Id + " отменён во время доставки.");
            _order.State = new CancelledState(_order);
        }
        public void MarkAsDelivered()
        {
            Console.WriteLine("Заказ " + _order.Id + " доставлен.");
            _order.State = new CompletedState(_order);
        }
        public string GetStatus()
        {
            return "В доставке";
        }
    }
}
