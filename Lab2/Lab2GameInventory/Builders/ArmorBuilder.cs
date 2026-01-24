using Lab2GameInventory.Items.Armor;

namespace Lab2GameInventory.Builders
{
    public class ArmorBuilder
    {
        private string _id;
        private string _name;
        private int _defense;
        private ArmorType _type;

        public ArmorBuilder SetId(string id)
        {
            _id = id;
            return this;
        }

        public ArmorBuilder SetName(string name)
        {
            if (name == null)
            {
                name = "Неизвестная броня";
            }

            _name = name;
            return this;
        }

        public ArmorBuilder SetDefense(int defense)
        {
            _defense = defense;
            return this;
        }

        public ArmorBuilder SetType(ArmorType type)
        {
            _type = type;
            return this;
        }

        public Armor Build()
        {
            if (_id == null || _name == null)
            {
                return null;
            }
            return new Armor(_id, _name, _defense, _type);
        }
    }
}
