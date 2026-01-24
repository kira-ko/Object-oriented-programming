using Lab3FoodDelivery.Orders;

namespace Lab3FoodDelivery.Observer
{
    public interface IOrderObserver
    {
        void Update(Order order);
    }
}
