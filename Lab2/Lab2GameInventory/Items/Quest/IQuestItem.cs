using Lab2GameInventory.Items.Common;

namespace Lab2GameInventory.Items.Quest
{
    public interface IQuestItem : IItem
    {
        string QuestName { get; }
        QuestItemType Type { get; }
    }
}
