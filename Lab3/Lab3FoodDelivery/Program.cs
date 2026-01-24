using System;
using Lab3FoodDelivery.Menu;
using Lab3FoodDelivery.Orders;
using Lab3FoodDelivery.Builder;
using Lab3FoodDelivery.AbstractFactory;
using Lab3FoodDelivery.Observer;

namespace Lab3FoodDelivery
{
    public class Program
    {
        public static void Main()
        {
            Dish blini = new Dish("d1", "Блины", 440);
            Dish borsch = new Dish("d2", "Борщ", 550);
            Dish salat = new Dish("d3", "Салат", 370);

            Console.WriteLine("Меню:");
            Console.WriteLine("- " + blini.Name + " : " + blini.BasePrice);
            Console.WriteLine("- " + borsch.Name + " : " + borsch.BasePrice);
            Console.WriteLine("- " + salat.Name + " : " + salat.BasePrice);
            Console.WriteLine();

            IOrderConfigFactory standardFactory = new StandardOrderFactory();
            IOrderConfigFactory specialFactory = new SpecialOrderFactory(10, 5);

            ConsoleOrderObserver observer = new ConsoleOrderObserver();

            Order order1 = new OrderBuilder()
                .SetId("order-1")
                .SetType(OrderType.Standard)
                .SetFactory(standardFactory)
                .AddDish(blini, 1)
                .AddDish(borsch, 1)
                .Build();

            order1.Attach(observer);

            Console.WriteLine("Заказ 1 создан.");
            Console.WriteLine("Статус: " + order1.GetStatus());
            Console.WriteLine("Сумма блюд: " + order1.GetItemsTotalPrice());
            Console.WriteLine("Итого: " + order1.GetTotalPrice());
            Console.WriteLine();

            Order order2 = new OrderBuilder()
                .SetId("order-2")
                .SetType(OrderType.Special)
                .SetFactory(specialFactory)
                .AddDish(salat, 2)
                .Build();

            order2.Attach(observer);

            Console.WriteLine("Заказ 2 создан.");
            Console.WriteLine("Статус: " + order2.GetStatus());
            Console.WriteLine("Сумма блюд: " + order2.GetItemsTotalPrice());
            Console.WriteLine("Итого: " + order2.GetTotalPrice());
            Console.WriteLine();

            Console.WriteLine("Меняем состояние заказа 1:");
            order1.Process();
            Console.WriteLine("Текущий статус: " + order1.GetStatus());
            order1.MarkAsDelivered();
            Console.WriteLine("Текущий статус: " + order1.GetStatus());
            Console.WriteLine();

            Console.WriteLine("Меняем состояние заказа 2:");
            order2.Cancel();
            Console.WriteLine("Текущий статус: " + order2.GetStatus());
        }
    }
}
