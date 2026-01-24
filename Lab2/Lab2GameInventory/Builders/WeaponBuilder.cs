using System;
using Lab2GameInventory.Items.Weapon;

namespace Lab2GameInventory.Builders
{
    public class WeaponBuilder
    {
        private string _id;
        private string _name;
        private int _damage;
        private WeaponType _type;

        public WeaponBuilder SetId(string id)
        {
            _id = id;
            return this;
        }

        public WeaponBuilder SetName(string name)
        {
            if (name == null)
            {
                name = "Неизвестное оружие";
            }
            _name = name;
            return this;
        }


        public WeaponBuilder SetDamage(int damage)
        {
            _damage = damage;
            return this;
        }

        public WeaponBuilder SetType(WeaponType type)
        {
            _type = type;
            return this;
        }

        public Weapon Build()
        {
            if (_id == null || _name == null)
            {
                return null;
            }
            return new Weapon(_id, _name, _damage, _type);
        }
    }
}
