using System;

namespace Lab2GameInventory.Items.Quest
{
    public class QuestItem : IQuestItem
    {
        public string Id { get; }
        public string Name { get; }

        public string QuestName { get; }
        public QuestItemType Type { get; }

        public QuestItem(string id, string name, string questName, QuestItemType type)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id");
            }

            if (name == null)
            {
                throw new ArgumentNullException("name");
            }

            if (questName == null)
            {
                throw new ArgumentNullException("questName");
            }

            Id = id;
            Name = name;
            QuestName = questName;
            Type = type;
        }

        public string GetInfo()
        {
            return "Quest item: " + Name +
                   " | Type: " + Type +
                   " | Quest: " + QuestName;
        }
    }
}
