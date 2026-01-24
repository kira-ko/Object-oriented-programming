using System;
using System.Collections.Generic;

namespace Lab3FoodDelivery.Menu
{
    public class MenuCatalog
    {
        private List<Dish> _dishes;

        public MenuCatalog()
        {
            _dishes = new List<Dish>();
        }

        public bool AddDish(Dish dish)
        {
            if (dish == null)
            {
                return false;
            }
            if (GetDishById(dish.Id) != null)
            {
                return false;
            }
            _dishes.Add(dish);
            return true;
        }

        public Dish GetDishById(string id)
        {
            if (id == null)
            {
                return null;
            }
            for (int i = 0; i < _dishes.Count; i++)
            {
                if (_dishes[i].Id == id)
                {
                    return _dishes[i];
                }
            }
            return null;
        }

        public List<Dish> GetAllDishes()
        {
            List<Dish> result = new List<Dish>();

            for (int i = 0; i < _dishes.Count; i++)
            {
                result.Add(_dishes[i]);
            }
            return result;
        }
    }
}
