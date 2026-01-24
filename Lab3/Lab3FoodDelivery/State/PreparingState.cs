using System;
using Lab3FoodDelivery.Orders;

namespace Lab3FoodDelivery.State
{
    public class PreparingState : IOrderState
    {
        private Order _order;
        public PreparingState(Order order)
        {
            _order = order;
        }
        public void Process()
        {
            Console.WriteLine("Заказ " + _order.Id + " передан в доставку.");
            _order.State = new DeliveringState(_order);
        }
        public void Cancel()
        {
            Console.WriteLine("Заказ " + _order.Id + " отменён.");
            _order.State = new CancelledState(_order);
        }
        public void MarkAsDelivered()
        {
            Console.WriteLine("Заказ " + _order.Id + " не может быть отмечен как доставленный, пока готовится.");
        }
        public string GetStatus()
        {
            return "Готовится";
        }
    }
}
