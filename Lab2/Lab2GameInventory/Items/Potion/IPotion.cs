using Lab2GameInventory.Items.Common;

namespace Lab2GameInventory.Items.Potion
{
    public interface IPotion : IItem, IUsable
    {
        int Power { get; }
        PotionType Type { get; }
    }
}
