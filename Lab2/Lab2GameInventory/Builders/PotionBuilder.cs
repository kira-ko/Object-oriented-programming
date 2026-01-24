using Lab2GameInventory.Items.Potion;

namespace Lab2GameInventory.Builders
{
    public class PotionBuilder
    {
        private string _id;
        private string _name;
        private int _power;
        private PotionType _type;

        public PotionBuilder SetId(string id)
        {
            _id = id;
            return this;
        }

        public PotionBuilder SetName(string name)
        {
            if (name == null)
            {
                name = "Неизвестное зелье";
            }
            _name = name;
            return this;
        }

        public PotionBuilder SetPower(int power)
        {
            _power = power;
            return this;
        }

        public PotionBuilder SetType(PotionType type)
        {
            _type = type;
            return this;
        }

        public Potion Build()
        {
            if (_id == null || _name == null)
            {
                return null;
            }
            return new Potion(_id, _name, _power, _type);
        }
    }
}
