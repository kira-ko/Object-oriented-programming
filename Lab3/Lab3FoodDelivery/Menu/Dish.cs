using System;

namespace Lab3FoodDelivery.Menu
{
    public class Dish
    {
        public string Id { get; }
        public string Name { get; }
        public int BasePrice { get; }

        public Dish(string id, string name, int basePrice)
        {
            if (id == null)
            {
                throw new ArgumentException("Id блюда не может быть пустым.");
            }
            if (name == null)
            {
                throw new ArgumentException("Введите название блюда, строка не может быть пустой.");
            }
            if (basePrice < 0)
            {
                throw new ArgumentException("Цена блюда не может быть отрицательной.");
            }

            Id = id;
            Name = name;
            BasePrice = basePrice;
        }
        public string GetInfo()
        {
            return Name + " (" + BasePrice + ")";
        }
    }
}
