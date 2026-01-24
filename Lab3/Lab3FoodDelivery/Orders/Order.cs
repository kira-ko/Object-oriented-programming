using System;
using System.Collections.Generic;
using Lab3FoodDelivery.State;
using Lab3FoodDelivery.Observer;
using Lab3FoodDelivery.AbstractFactory;

namespace Lab3FoodDelivery.Orders
{
    public class Order
    {
        private List<OrderItem> _items;
        private List<IOrderObserver> _observers;
        public string Id { get; }
        public OrderType Type { get; }
        public IOrderState State { get; set; }

        public OrderPricingRules PricingRules { get; set; }
        public Order(string id, OrderType type)
        {
            if (id == null)
            {
                throw new ArgumentException("Id заказа не может быть пустым.");
            }

            Id = id;
            Type = type;

            _items = new List<OrderItem>();
            _observers = new List<IOrderObserver>();

            State = null;
            PricingRules = null;
        }

        public Order(string id, OrderType type, IOrderState startState)
        {
            if (id == null)
            {
                throw new ArgumentException("Id заказа не может быть пустым.");
            }
            if (startState == null)
            {
                throw new ArgumentException("Стартовое состояние не может быть пустым.");
            }
            Id = id;
            Type = type;

            _items = new List<OrderItem>();
            _observers = new List<IOrderObserver>();

            State = startState;
            PricingRules = null;
        }

        public bool AddItem(OrderItem item)
        {
            if (item == null)
            {
                return false;
            }
            _items.Add(item);
            return true;
        }

        public List<OrderItem> GetAllItems()
        {
            List<OrderItem> result = new List<OrderItem>();
            for (int i = 0; i < _items.Count; i++)
            {
                result.Add(_items[i]);
            }
            return result;
        }

        public int GetItemsTotalPrice()
        {
            int total = 0;
            for (int i = 0; i < _items.Count; i++)
            {
                total = total + _items[i].GetTotalPrice();
            }
            return total;
        }

        public int GetTotalPrice()
        {
            int itemsTotal = GetItemsTotalPrice();

            if (PricingRules == null)
            {
                return itemsTotal;
            }
            if (PricingRules.DiscountStrategy == null ||
                PricingRules.TaxStrategy == null ||
                PricingRules.DeliveryFeeStrategy == null)
            {
                return itemsTotal;
            }
            int discount = PricingRules.DiscountStrategy.GetDiscount(itemsTotal);

            int afterDiscount = itemsTotal - discount;
            if (afterDiscount < 0)
            {
                afterDiscount = 0;
            }
            int tax = PricingRules.TaxStrategy.GetTax(afterDiscount);
            int deliveryFee = PricingRules.DeliveryFeeStrategy.GetDeliveryFee(itemsTotal);

            int total = afterDiscount + tax + deliveryFee;
            return total;
        }

        public void Process()
        {
            if (State != null)
            {
                State.Process();
                Notify();
            }
        }
        public void Cancel()
        {
            if (State != null)
            {
                State.Cancel();
                Notify();
            }
        }
        public void MarkAsDelivered()
        {
            if (State != null)
            {
                State.MarkAsDelivered();
                Notify();
            }
        }
        public string GetStatus()
        {
            if (State == null)
            {
                return "Нет состояния";
            }
            return State.GetStatus();
        }

        public bool Attach(IOrderObserver observer)
        {
            if (observer == null)
            {
                return false;
            }
            _observers.Add(observer);
            return true;
        }
        private void Notify()
        {
            for (int i = 0; i < _observers.Count; i++)
            {
                _observers[i].Update(this);
            }
        }
    }
}
